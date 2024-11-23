using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAgregarDescuentos : Form
    {
        private Operacion operacion;
        private string discountType; // ID del descuento
        private Datos datos = new Datos();

        // Constructor original
        public FormAgregarDescuentos(Operacion operacion, string discountType = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.discountType = discountType;
            ConfigurarFormulario();
            CargarComboTienda();

            if (operacion == Operacion.Editar)
            {
                CargarDatosDescuento(discountType);
            }
        }

        // Constructor adicional para inicializar con valores
        public FormAgregarDescuentos(Operacion operacion, string discountType, string storId, decimal lowQty, decimal highQty, decimal discount)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.discountType = discountType;

            ConfigurarFormulario();
            CargarComboTienda();

            // Establecer valores iniciales en los campos
            txtDescripcion.Text = discountType;
            txtDescripcion.ReadOnly = true; // Solo lectura en modo edición
            cmbIdTienda.SelectedValue = storId;
            nudMin.Value = AjustarValorDentroRango(nudMin, lowQty);
            nudMax.Value = AjustarValorDentroRango(nudMax, highQty);
            nudDescuento.Value = AjustarValorDentroRango(nudDescuento, discount);
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Descuento";
                btnAceptar.Text = "Actualizar";
            }
            else
            {
                this.Text = "Agregar Descuento";
                btnAceptar.Text = "Agregar";
            }
        }

        private void CargarComboTienda()
        {
            try
            {
                string query = "SELECT stor_id, stor_name FROM stores";
                DataSet ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    cmbIdTienda.DataSource = ds.Tables[0];
                    cmbIdTienda.DisplayMember = "stor_name";
                    cmbIdTienda.ValueMember = "stor_id";
                    cmbIdTienda.SelectedIndex = -1; // Sin selección inicial
                }
                else
                {
                    MessageBox.Show("No se encontraron tiendas disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las tiendas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDescuento(string discountType)
        {
            try
            {
                string query = @"
                    SELECT discounttype, stor_id, lowqty, highqty, discount
                    FROM discounts
                    WHERE discounttype = @discountType";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@discountType", discountType)
                };

                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtDescripcion.Text = row["discounttype"].ToString();
                    cmbIdTienda.SelectedValue = row["stor_id"].ToString();

                    nudMin.Value = AjustarValorDentroRango(nudMin, Convert.ToDecimal(row["lowqty"]));
                    nudMax.Value = AjustarValorDentroRango(nudMax, Convert.ToDecimal(row["highqty"]));
                    nudDescuento.Value = AjustarValorDentroRango(nudDescuento, Convert.ToDecimal(row["discount"]));

                    txtDescripcion.ReadOnly = true; // No se permite cambiar el discountType en modo edición
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los datos del descuento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del descuento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del descuento es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbIdTienda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una tienda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudMin.Value > nudMax.Value)
            {
                MessageBox.Show("La cantidad mínima no puede ser mayor que la cantidad máxima.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private SqlParameter[] ObtenerParametros(bool incluirId)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@storId", cmbIdTienda.SelectedValue ?? (object)DBNull.Value),
                new SqlParameter("@lowQty", nudMin.Value),
                new SqlParameter("@highQty", nudMax.Value),
                new SqlParameter("@discount", nudDescuento.Value)
            };

            if (incluirId || operacion == Operacion.Agregar)
            {
                parametros.Insert(0, new SqlParameter("@discountType", txtDescripcion.Text.Trim()));
            }

            return parametros.ToArray();
        }

        private decimal AjustarValorDentroRango(NumericUpDown control, decimal valor)
        {
            if (valor < control.Minimum)
                return control.Minimum;
            if (valor > control.Maximum)
                return control.Maximum;
            return valor;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            try
            {
                string query;
                SqlParameter[] parametros;

                if (operacion == Operacion.Agregar)
                {
                    query = @"
                        INSERT INTO discounts (discounttype, stor_id, lowqty, highqty, discount)
                        VALUES (@discountType, @storId, @lowQty, @highQty, @discount)";
                    parametros = ObtenerParametros(false);
                }
                else
                {
                    query = @"
                        UPDATE discounts
                        SET stor_id = @storId,
                            lowqty = @lowQty,
                            highqty = @highQty,
                            discount = @discount
                        WHERE discounttype = @discountType";
                    parametros = ObtenerParametros(true);
                }

                bool resultado = datos.ejecutarABC(query, parametros);

                if (resultado)
                {
                    MessageBox.Show($"Descuento {(operacion == Operacion.Agregar ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"No se pudo {(operacion == Operacion.Agregar ? "agregar" : "actualizar")} el descuento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
