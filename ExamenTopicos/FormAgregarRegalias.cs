// FormAgregarRegalias.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAgregarRegalias : Form
    {
        private Operacion operacion;
        private string autorId;
        private string tituloId;
        private Datos datos = new Datos();

        public FormAgregarRegalias(Operacion operacion, string autorId = null, string tituloId = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.autorId = autorId;
            this.tituloId = tituloId;

            CargarDatosComboBox();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Registro de Regalías";
                btnAceptar.Text = "Actualizar";
                CargarDatosExistentes(autorId, tituloId);
            }
            else
            {
                this.Text = "Agregar Registro de Regalías";
                btnAceptar.Text = "Agregar";
            }
        }

        private void CargarDatosComboBox()
        {
            try
            {
                // Cargar Títulos
                var dsTitulos = datos.consulta("SELECT title_id, title AS Titulo FROM titles");
                if (dsTitulos != null && dsTitulos.Tables.Count > 0)
                {
                    cmbTitulo.DataSource = dsTitulos.Tables[0];
                    cmbTitulo.DisplayMember = "Titulo";
                    cmbTitulo.ValueMember = "title_id";
                    cmbTitulo.SelectedIndex = -1; // Sin selección inicial
                }

                // Cargar Autores
                var dsAutores = datos.consulta("SELECT au_id, au_lname + ' ' + au_fname AS Autor FROM authors");
                if (dsAutores != null && dsAutores.Tables.Count > 0)
                {
                    cmbAutor.DataSource = dsAutores.Tables[0];
                    cmbAutor.DisplayMember = "Autor";
                    cmbAutor.ValueMember = "au_id";
                    cmbAutor.SelectedIndex = -1; // Sin selección inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosExistentes(string autorId, string tituloId)
        {
            try
            {
                string query = @"
                    SELECT 
                        ta.au_ord, 
                        ta.royaltyper
                    FROM 
                        titleauthor ta
                    WHERE 
                        ta.au_id = @autorId AND ta.title_id = @tituloId";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@autorId", autorId),
                    new SqlParameter("@tituloId", tituloId)
                };

                var ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    nudOrden.Value = Convert.ToDecimal(row["au_ord"]);
                    nudRegalias.Value = Convert.ToDecimal(row["royaltyper"]);

                    // Seleccionar los valores en los ComboBox basándose en los IDs
                    cmbTitulo.SelectedValue = tituloId;
                    cmbAutor.SelectedValue = autorId;

                    // Deshabilitar los ComboBox para evitar cambios en las claves foráneas
                    cmbAutor.Enabled = false;
                    cmbTitulo.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para cargar en la edición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos existentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string tituloIdSeleccionado = cmbTitulo.SelectedValue?.ToString();
                string autorIdSeleccionado = cmbAutor.SelectedValue?.ToString();

                if (operacion == Operacion.Agregar)
                {
                    if (string.IsNullOrWhiteSpace(tituloIdSeleccionado) || string.IsNullOrWhiteSpace(autorIdSeleccionado))
                    {
                        MessageBox.Show("Por favor, selecciona un autor y un título válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int orden = (int)nudOrden.Value;
                int regalías = (int)nudRegalias.Value;

                string query;
                SqlParameter[] parametrosOperacion;

                if (operacion == Operacion.Agregar)
                {
                    query = @"
                        INSERT INTO titleauthor (au_id, title_id, au_ord, royaltyper)
                        VALUES (@autorId, @tituloId, @orden, @regalias)";
                    parametrosOperacion = new SqlParameter[]
                    {
                        new SqlParameter("@autorId", autorIdSeleccionado),
                        new SqlParameter("@tituloId", tituloIdSeleccionado),
                        new SqlParameter("@orden", orden),
                        new SqlParameter("@regalias", regalías)
                    };
                }
                else // Operacion.Editar
                {
                    query = @"
                        UPDATE titleauthor
                        SET au_ord = @orden, royaltyper = @regalias
                        WHERE au_id = @autorId AND title_id = @tituloId";
                    parametrosOperacion = new SqlParameter[]
                    {
                        new SqlParameter("@orden", orden),
                        new SqlParameter("@regalias", regalías),
                        new SqlParameter("@autorId", autorId),
                        new SqlParameter("@tituloId", tituloId)
                    };
                }

                bool exito = datos.ejecutarABC(query, parametrosOperacion);
                if (exito)
                {
                    MessageBox.Show($"Registro {(operacion == Operacion.Agregar ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show($"No se pudo {(operacion == Operacion.Agregar ? "agregar" : "actualizar")} el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
