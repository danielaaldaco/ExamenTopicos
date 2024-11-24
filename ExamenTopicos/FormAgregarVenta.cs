using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarVenta : Form
    {
        private Datos datos = new Datos();
        private string ordNum;

        public FormAgregarVenta(string id = null)
        {
            InitializeComponent();
            this.ordNum = id;
            CargarDatosComboBox();
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            this.Shown += FormAgregarVenta_Shown;

            if (string.IsNullOrEmpty(id))
            {
                this.Text = "Agregar Venta";
                btnAceptar.Text = "Agregar";
                GenerarIdAleatorio();
                desbloquearCampos();
                cmbTienda.Focus();
            }
            else
            {
                this.Text = "Editar Venta";
                btnAceptar.Text = "Actualizar";
                CargarDatosVenta(id);
                bloquearCampos();
            }
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

                string queryTitulos = "SELECT title_id, title FROM titles";
                DataSet dsTitulos = datos.consulta(queryTitulos);
                if (dsTitulos != null && dsTitulos.Tables.Count > 0)
                {
                    cmbTitulo.DataSource = dsTitulos.Tables[0];
                    cmbTitulo.DisplayMember = "title";
                    cmbTitulo.ValueMember = "title_id";
                }

                cmbPago.Items.Add("Contado");
                cmbPago.Items.Add("Crédito");
                cmbPago.Items.Add("Transferencia bancaria");
                cmbPago.Items.Add("Tarjeta de crédito");
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
                string query = "SELECT ord_num, stor_id, title_id, qty, payterms, ord_date FROM sales WHERE ord_num = @ordNum";
                SqlParameter[] parametros = { new SqlParameter("@ordNum", id) };
                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtOrden.Text = row["ord_num"].ToString();
                    cmbTienda.SelectedValue = row["stor_id"];
                    cmbTitulo.SelectedValue = row["title_id"];
                    txtCantidad.Text = row["qty"].ToString();
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

        private void bloquearCampos()
        {
            txtOrden.ReadOnly = true;
            txtOrden.TabStop = false;
            cmbTienda.Enabled = false;
            cmbTitulo.Enabled = false;
            dtpFecha.Enabled = false;
        }

        private void desbloquearCampos()
        {
            txtOrden.ReadOnly = true;
            txtOrden.TabStop = false;
            cmbTienda.Enabled = true;
            cmbTitulo.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void GenerarIdAleatorio()
        {
            txtOrden.Text = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                MessageBox.Show("El campo 'N° de Orden' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || int.Parse(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("La 'Cantidad' debe ser un número mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTienda.SelectedIndex == -1)
            {
                MessageBox.Show("El campo 'ID Tienda' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTitulo.SelectedIndex == -1)
            {
                MessageBox.Show("El campo 'ID Titulo' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string query;
                    SqlParameter[] parametros;

                    if (string.IsNullOrEmpty(ordNum))
                    {
                        query = @"
                            INSERT INTO sales (ord_num, stor_id, title_id, qty, payterms, ord_date)
                            VALUES (@ordNum, @storId, @titleId, @qty, @payterms, @ordDate)";
                        parametros = new SqlParameter[]
                        {
                            new SqlParameter("@ordNum", txtOrden.Text),
                            new SqlParameter("@storId", cmbTienda.SelectedValue),
                            new SqlParameter("@titleId", cmbTitulo.SelectedValue),
                            new SqlParameter("@qty", int.Parse(txtCantidad.Text)),
                            new SqlParameter("@payterms", cmbPago.SelectedItem),
                            new SqlParameter("@ordDate", dtpFecha.Value)
                        };
                    }
                    else
                    {
                        query = @"
                            UPDATE sales
                            SET stor_id = @storId, title_id = @titleId, qty = @qty, payterms = @payterms, ord_date = @ordDate
                            WHERE ord_num = @ordNum";
                        parametros = new SqlParameter[]
                        {
                            new SqlParameter("@storId", cmbTienda.SelectedValue),
                            new SqlParameter("@titleId", cmbTitulo.SelectedValue),
                            new SqlParameter("@qty", int.Parse(txtCantidad.Text)),
                            new SqlParameter("@payterms", cmbPago.SelectedItem),
                            new SqlParameter("@ordDate", dtpFecha.Value),
                            new SqlParameter("@ordNum", txtOrden.Text)
                        };
                    }

                    bool resultado = datos.ejecutarABC(query, parametros);

                    if (resultado)
                    {
                        MessageBox.Show($"Venta {(string.IsNullOrEmpty(ordNum) ? "agregada" : "actualizada")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarVenta_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ordNum))
            {
                cmbTienda.Focus();
            }
        }
    }
}