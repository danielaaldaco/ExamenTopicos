// FormRegalias.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormRegalias : Form
    {
        private DataSet ds;
        private Datos datos = new Datos();

        public FormRegalias()
        {
            InitializeComponent();
            ActualizarGrid();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = System.Text.RegularExpressions.Regex.Replace(txtBuscar.Text.Trim(), @"\s+", " ");
                string query = string.IsNullOrWhiteSpace(searchValue)
                    ? @"
                        SELECT 
                            a.au_id,
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title AS 'Título',
                            ta.au_ord AS 'Orden',
                            ta.royaltyper AS 'Regalía (%)'
                        FROM 
                            titleauthor ta
                        INNER JOIN 
                            authors a ON ta.au_id = a.au_id
                        INNER JOIN 
                            titles t ON ta.title_id = t.title_id"
                    : @"
                        SELECT 
                            a.au_id,
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title AS 'Título',
                            ta.au_ord AS 'Orden',
                            ta.royaltyper AS 'Regalía (%)'
                        FROM 
                            titleauthor ta
                        INNER JOIN 
                            authors a ON ta.au_id = a.au_id
                        INNER JOIN 
                            titles t ON ta.title_id = t.title_id
                        WHERE 
                            a.au_lname + ' ' + a.au_fname LIKE @searchValue 
                            OR t.title LIKE @searchValue";

                SqlParameter[] parametros = string.IsNullOrWhiteSpace(searchValue) ? null : new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvRegalias.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    if (dgvRegalias.Columns.Contains("au_id"))
                        dgvRegalias.Columns["au_id"].Visible = false;

                    AgregarColumnaIcono("Editar", Properties.Resources.pencil2, 30, 0);
                    AgregarColumnaIcono("Eliminar", Properties.Resources.garbage, 30, dgvRegalias.Columns.Count);
                }
                else
                {
                    dgvRegalias.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Error en la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvRegalias.Columns.Contains("Nombre Autor"))
                dgvRegalias.Columns["Nombre Autor"].HeaderText = "Autor";

            if (dgvRegalias.Columns.Contains("Título"))
                dgvRegalias.Columns["Título"].HeaderText = "Título";

            if (dgvRegalias.Columns.Contains("Orden"))
                dgvRegalias.Columns["Orden"].HeaderText = "Orden";

            if (dgvRegalias.Columns.Contains("Regalía (%)"))
                dgvRegalias.Columns["Regalía (%)"].HeaderText = "Regalías(%)";
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvRegalias.Columns.Contains(nombre))
            {
                var columna = new DataGridViewImageColumn
                {
                    Name = nombre,
                    HeaderText = "",
                    Image = imagen,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = ancho
                };
                if (posicion >= 0 && posicion < dgvRegalias.Columns.Count)
                    dgvRegalias.Columns.Insert(posicion, columna);
                else
                    dgvRegalias.Columns.Add(columna);
            }
        }

        // FormRegalias.cs (Método dgvRegalias_CellContentClick)
        private void dgvRegalias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvRegalias.Columns[e.ColumnIndex].Name;
                var row = dgvRegalias.Rows[e.RowIndex];
                string auId = row.Cells["au_id"]?.Value?.ToString() ?? string.Empty;
                string title = row.Cells["Título"]?.Value?.ToString() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(auId) || string.IsNullOrWhiteSpace(title))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Eliminar")
                {
                    // Manejar eliminación (código existente)
                }
                else if (columnName == "Editar")
                {
                    using (var editarForm = new FormAgregarRegalias(Operacion.Editar, auId, title))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                        }
                    }
                }
            }
        }

        // FormRegalias.cs (Método btnAgregar_Click_1)
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            using (var formAgregarRegalias = new FormAgregarRegalias(Operacion.Agregar))
            {
                if (formAgregarRegalias.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }


        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        a.au_id,
                        a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                        t.title AS 'Título',
                        ta.au_ord AS 'Orden',
                        ta.royaltyper AS 'Regalía (%)'
                    FROM 
                        titleauthor ta
                    INNER JOIN 
                        authors a ON ta.au_id = a.au_id
                    INNER JOIN 
                        titles t ON ta.title_id = t.title_id";

                ds = datos.consulta(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvRegalias.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    if (dgvRegalias.Columns.Contains("au_id"))
                        dgvRegalias.Columns["au_id"].Visible = false;

                    AgregarColumnaIcono("Editar", Properties.Resources.pencil2, 30, 0);
                    AgregarColumnaIcono("Eliminar", Properties.Resources.garbage, 30, dgvRegalias.Columns.Count);
                }
                else
                {
                    dgvRegalias.DataSource = null;
                }

                if (dgvRegalias.Rows.Count > 0)
                {
                    dgvRegalias.ClearSelection();
                    dgvRegalias.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}