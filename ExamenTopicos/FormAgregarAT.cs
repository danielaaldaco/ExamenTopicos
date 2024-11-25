// FormAgregarAT.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ExamenTopicos.Utils;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarAT : MetroForm
    {
        private Operacion operacion;
        private string autorId;
        private string tituloId;
        private Datos datos = new Datos();

        public FormAgregarAT(Operacion operacion, string autorId = null, string tituloId = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.autorId = autorId;
            this.tituloId = tituloId;

            CargarDatosComboBox();
            ConfigurarFormulario();

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Registro";
                btnAceptar.Text = "Actualizar";
                CargarDatosExistentes(autorId, tituloId);
            }
            else
            {
                this.Text = "Agregar Registro";
                btnAceptar.Text = "Agregar";
            }
        }

        private void CargarDatosComboBox()
        {
            try
            {
                var dsTitulos = datos.consulta("SELECT title AS Titulo FROM titles");
                cmbTitulo.DataSource = dsTitulos.Tables[0];
                cmbTitulo.DisplayMember = "Titulo";

                var dsAutores = datos.consulta("SELECT au_lname + ' ' + au_fname AS Autor FROM authors");
                cmbAutor.DataSource = dsAutores.Tables[0];
                cmbAutor.DisplayMember = "Autor";
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
                        t.title AS Titulo, 
                        a.au_lname + ' ' + a.au_fname AS Autor,
                        ta.au_ord, ta.royaltyper
                    FROM 
                        titleauthor ta
                    INNER JOIN 
                        titles t ON ta.title_id = t.title_id
                    INNER JOIN 
                        authors a ON ta.au_id = a.au_id
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
                    cmbTitulo.Text = row["Titulo"].ToString();
                    cmbAutor.Text = row["Autor"].ToString();
                    nudOrden.Value = Convert.ToDecimal(row["au_ord"]);
                    nudRegalias.Value = Convert.ToDecimal(row["royaltyper"]);

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
                string tituloSeleccionado = cmbTitulo.Text;
                string autorSeleccionado = cmbAutor.Text;

                // Obtener title_id
                string queryTitulo = "SELECT title_id FROM titles WHERE title = @titulo";
                SqlParameter[] parametrosTitulo = new SqlParameter[]
                {
                    new SqlParameter("@titulo", tituloSeleccionado)
                };
                DataSet dsTitulo = datos.consulta(queryTitulo, parametrosTitulo);
                if (dsTitulo == null || dsTitulo.Tables.Count == 0 || dsTitulo.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Título seleccionado no válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string tituloIdSeleccionado = dsTitulo.Tables[0].Rows[0]["title_id"].ToString();

                // Obtener au_id
                string queryAutor = "SELECT au_id FROM authors WHERE au_lname + ' ' + au_fname = @autor";
                SqlParameter[] parametrosAutor = new SqlParameter[]
                {
                    new SqlParameter("@autor", autorSeleccionado)
                };
                DataSet dsAutor = datos.consulta(queryAutor, parametrosAutor);
                if (dsAutor == null || dsAutor.Tables.Count == 0 || dsAutor.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Autor seleccionado no válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string autorIdSeleccionado = dsAutor.Tables[0].Rows[0]["au_id"].ToString();

                if (string.IsNullOrWhiteSpace(autorIdSeleccionado) || string.IsNullOrWhiteSpace(tituloIdSeleccionado))
                {
                    MessageBox.Show("Por favor, selecciona un autor y un título válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orden = (int)nudOrden.Value;
                int regalias = (int)nudRegalias.Value;

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
                        new SqlParameter("@regalias", regalias)
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
                        new SqlParameter("@regalias", regalias),
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

        private void cmbTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
