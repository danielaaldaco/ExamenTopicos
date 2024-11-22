using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAgregarJob : Form
    {
        private Operacion operacion;  // Define si es agregar o editar
        private string jobId;         // ID del puesto para editar (opcional en agregar)
        private Datos datos = new Datos();

        public FormAgregarJob(Operacion operacion, string jobId = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.jobId = jobId;

            ConfigurarFormulario();
            if (operacion == Operacion.Editar && jobId != null)
            {
                CargarDatosPuesto(jobId);
            }

            // Validaciones en tiempo real
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            txtDescripcion.Validating += txtDescripcion_Validating;

            this.AcceptButton = btnAceptar; // Asocia Enter al botón Aceptar
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Puesto";
                btnAceptar.Text = "Actualizar";
                ConfigurarCamposEdicion();
            }
            else
            {
                this.Text = "Agregar Puesto";
                btnAceptar.Text = "Agregar";
                ConfigurarCamposAgregar();
            }
        }

        private void ConfigurarCamposEdicion()
        {
            txtDescripcion.ReadOnly = true; // La descripción no es editable en edición
            nudMin.Enabled = true;
            nudMax.Enabled = true;
        }

        private void ConfigurarCamposAgregar()
        {
            txtDescripcion.ReadOnly = false; // La descripción se puede ingresar
            nudMin.Value = 10;
            nudMax.Value = 15;
        }

        private void CargarDatosPuesto(string jobId)
        {
            try
            {
                string query = "SELECT job_desc, min_lvl, max_lvl FROM jobs WHERE job_id = @jobId";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@jobId", jobId)
                };

                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtDescripcion.Text = row["job_desc"].ToString();
                    nudMin.Value = Convert.ToInt32(row["min_lvl"]);
                    nudMax.Value = Convert.ToInt32(row["max_lvl"]);
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el puesto especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del puesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Los datos son correctos?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string descripcion = LimpiarDescripcion(txtDescripcion.Text);
                    if (descripcion == null)
                    {
                        return;
                    }

                    try
                    {
                        string query;
                        SqlParameter[] parametros;

                        if (operacion == Operacion.Agregar)
                        {
                            query = @"
                                INSERT INTO jobs (job_desc, min_lvl, max_lvl)
                                VALUES (@jobDesc, @minLvl, @maxLvl)";
                            parametros = ObtenerParametros();
                        }
                        else
                        {
                            query = @"
                                UPDATE jobs
                                SET min_lvl = @minLvl, max_lvl = @maxLvl
                                WHERE job_desc = @jobDesc";
                            parametros = ObtenerParametros();
                        }

                        bool resultado = datos.ejecutarABC(query, parametros);

                        if (resultado)
                        {
                            MessageBox.Show($"Puesto {(operacion == Operacion.Agregar ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el puesto. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string LimpiarDescripcion(string descripcion)
        {
            descripcion = descripcion.Trim();
            descripcion = Regex.Replace(descripcion, @"\s+", " ");
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            descripcion = textInfo.ToTitleCase(descripcion.ToLower());

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("La descripción no puede estar vacía después de limpiar los espacios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return descripcion;
        }

        private SqlParameter[] ObtenerParametros()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@jobDesc", txtDescripcion.Text.Trim()),
                new SqlParameter("@minLvl", nudMin.Value),
                new SqlParameter("@maxLvl", nudMax.Value)
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudMin.Value < 10 || nudMax.Value > 250 || nudMin.Value > nudMax.Value)
            {
                MessageBox.Show("El nivel mínimo debe ser al menos 10, el nivel máximo no puede exceder 250, y el nivel mínimo no puede ser mayor al máximo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\b]$"))
            {
                e.Handled = true;
            }

            if (char.IsWhiteSpace(e.KeyChar))
            {
                TextBox tb = sender as TextBox;
                int selectionStart = tb.SelectionStart;
                if (selectionStart > 0 && char.IsWhiteSpace(tb.Text[selectionStart - 1]))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider2.SetError(txtDescripcion, "Por favor, ingresa la descripción.");
                e.Cancel = true;
            }
            else
            {
                errorProvider2.SetError(txtDescripcion, string.Empty);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

