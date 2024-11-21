using System;
using System.Data;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarAT : Form
    {
        private string operation;
        private string autorId;
        private string tituloId;
        private Datos datos = new Datos();

        public FormAgregarAT(string operation, string autorId = null, string tituloId = null)
        {
            InitializeComponent();
            this.operation = operation;
            this.autorId = autorId;
            this.tituloId = tituloId;

            CargarDatosComboBox();

            if (operation == "Editar")
            {
                CargarDatosExistentes(autorId, tituloId);
                btnAceptar.Text = "Actualizar";
            }
            else
            {
                btnAceptar.Text = "Agregar";
            }

            btnAceptar.Click += btnAceptar_Click;
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
                string query = $@"
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
                        ta.au_id = '{autorId}' AND ta.title_id = '{tituloId}'";

                var ds = datos.consulta(query);

                if (ds.Tables[0].Rows.Count > 0)
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

                string queryTitulo = $"SELECT title_id FROM titles WHERE title = '{tituloSeleccionado}'";
                string tituloIdSeleccionado = datos.consulta(queryTitulo).Tables[0].Rows[0]["title_id"].ToString();

                string queryAutor = $"SELECT au_id FROM authors WHERE au_lname + ' ' + au_fname = '{autorSeleccionado}'";
                string autorIdSeleccionado = datos.consulta(queryAutor).Tables[0].Rows[0]["au_id"].ToString();

                if (string.IsNullOrWhiteSpace(autorIdSeleccionado) || string.IsNullOrWhiteSpace(tituloIdSeleccionado))
                {
                    MessageBox.Show("Por favor, selecciona un autor y un título válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orden = (int)nudOrden.Value;
                int regalias = (int)nudRegalias.Value;

                string query;

                if (operation == "Agregar")
                {
                    query = $@"
                        INSERT INTO titleauthor (au_id, title_id, au_ord, royaltyper)
                        VALUES ('{autorIdSeleccionado}', '{tituloIdSeleccionado}', {orden}, {regalias})";
                }
                else if (operation == "Editar")
                {
                    query = $@"
                        UPDATE titleauthor
                        SET au_ord = {orden}, royaltyper = {regalias}
                        WHERE au_id = '{autorId}' AND title_id = '{tituloId}'";
                }
                else
                {
                    throw new InvalidOperationException("Operación no reconocida.");
                }

                if (datos.ejecutarABC(query))
                {
                    MessageBox.Show($"Registro {(operation == "Agregar" ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"No se pudo {(operation == "Agregar" ? "agregar" : "actualizar")} el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
