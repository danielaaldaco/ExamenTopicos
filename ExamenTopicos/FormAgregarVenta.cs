using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarVenta : MetroForm
    {
        public Action OnGridUpdate;
        private Datos datos = new Datos();
        private string ordNum;
        private List<Dictionary<string, object>> carrito = new List<Dictionary<string, object>>();

        public FormAgregarVenta(string id = null)
        {
            InitializeComponent();
            this.ordNum = id;
            CargarDatosComboBox();
            ConfigurarControles();
            this.Shown += FormAgregarVenta_Shown;

            if (string.IsNullOrEmpty(id))
            {
                this.Text = "Agregar Venta";
                btnAceptar.Text = "Agregar";
                GenerarIdAleatorio();
                DesbloquearCampos();
                cmbTienda.Focus();
            }
            else
            {
                this.Text = "Editar Venta";
                btnAceptar.Text = "Actualizar";
                CargarDatosVenta(id);
                BloquearCampos();
            }
        }

        private void ConfigurarControles()
        {
            cmbTienda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
        }

        private void CargarDatosComboBox()
        {
            try
            {
                string queryTiendas = "SELECT stor_id, stor_name FROM stores";
                DataSet dsTiendas = datos.consulta(queryTiendas);
                if (dsTiendas != null && dsTiendas.Tables.Count > 0)
                {
                    cmbTienda.DataSource = dsTiendas.Tables[0];
                    cmbTienda.DisplayMember = "stor_name";
                    cmbTienda.ValueMember = "stor_id";
                }

                cmbPago.Items.Add("Contado");
                cmbPago.Items.Add("Crédito");
                cmbPago.Items.Add("Net 30");
                cmbPago.Items.Add("Net 60");
                cmbPago.Items.Add("SPEI");
                cmbPago.Items.Add("Tarjeta");
                cmbPago.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosVenta(string id)
        {
            try
            {
                string query = "SELECT ord_num, stor_id, payterms, ord_date FROM sales WHERE ord_num = @ordNum";
                SqlParameter[] parametros = { new SqlParameter("@ordNum", id) };
                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtOrden.Text = row["ord_num"].ToString();
                    cmbTienda.SelectedValue = row["stor_id"];
                    cmbPago.SelectedItem = row["payterms"];
                    dtpFecha.Value = Convert.ToDateTime(row["ord_date"]);
                }
                else
                {
                    MessageBox.Show("Venta no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearCampos()
        {
            txtOrden.ReadOnly = true;
            txtOrden.TabStop = false;
            cmbTienda.Enabled = false;
            dtpFecha.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            txtOrden.ReadOnly = true;
            txtOrden.TabStop = false;
            cmbTienda.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void GenerarIdAleatorio()
        {
            txtOrden.Text = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                MessageBox.Show("El campo 'N° de Orden' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTienda.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecciona una tienda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecciona un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                string storeId = cmbTienda.SelectedValue.ToString();
                string paymentTerms = cmbPago.SelectedItem.ToString();
                string ordNum = txtOrden.Text;

                if (string.IsNullOrEmpty(this.ordNum))
                {
                    var datosVenta = new List<Dictionary<string, object>>();

                    foreach (var item in carrito)
                    {
                        datosVenta.Add(new Dictionary<string, object>
                        {
                            { "StoreID", storeId },
                            { "OrderNumber", ordNum },
                            { "OrderDate", dtpFecha.Value },
                            { "TitleID", item["ID Título"] },
                            { "Quantity", item["Cantidad"] },
                            { "PaymentTerms", paymentTerms }
                        });
                    }

                    GuardarDatosEnBaseDeDatos(datosVenta);

                    MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnGridUpdate?.Invoke();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Código para editar la venta
                    MessageBox.Show("Funcionalidad de edición no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarDatosEnBaseDeDatos(List<Dictionary<string, object>> datosVenta)
        {
            foreach (var venta in datosVenta)
            {
                string query = @"
                INSERT INTO sales (stor_id, ord_num, ord_date, qty, payterms, title_id)
                VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@stor_id", venta["StoreID"]),
                    new SqlParameter("@ord_num", venta["OrderNumber"]),
                    new SqlParameter("@ord_date", venta["OrderDate"]),
                    new SqlParameter("@qty", venta["Quantity"]),
                    new SqlParameter("@payterms", venta["PaymentTerms"]),
                    new SqlParameter("@title_id", venta["TitleID"])
                };

                datos.ejecutarABC(query, parametros);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            using (var formCarrito = new FormCarrito())
            {
                if (formCarrito.ShowDialog() == DialogResult.OK)
                {
                    var carritoItems = formCarrito.ObtenerDatosCarrito();
                    carrito.AddRange(carritoItems);
                    MessageBox.Show("Artículos añadidos al pedido.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormAgregarVenta_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ordNum))
            {
                cmbTienda.Focus();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}