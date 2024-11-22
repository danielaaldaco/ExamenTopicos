using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
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
                            ta.au_id,
                            ta.title_id,
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
                            ta.au_id,
                            ta.title_id,
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

                    // Ocultar las columnas de IDs
                    if (dgvRegalias.Columns.Contains("au_id"))
                        dgvRegalias.Columns["au_id"].Visible = false;

                    if (dgvRegalias.Columns.Contains("title_id"))
                        dgvRegalias.Columns["title_id"].Visible = false;

                    AgregarColumnaIcono("Editar", Properties.Resources.edit, 30, 0);
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
                dgvRegalias.Columns["Regalía (%)"].HeaderText = "Regalía (%)";
        }

        private void AgregarColumnaIcono(string nombre, System.Drawing.Image imagen, int ancho, int posicion)
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

        private void dgvRegalias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvRegalias.Columns[e.ColumnIndex].Name;
                var row = dgvRegalias.Rows[e.RowIndex];
                string auId = row.Cells["au_id"]?.Value?.ToString() ?? string.Empty;
                string titleId = row.Cells["title_id"]?.Value?.ToString() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(auId) || string.IsNullOrWhiteSpace(titleId))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Eliminar")
                {
                    // Manejar eliminación
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar el siguiente registro?\n\nAutor ID: {auId}\nTítulo ID: {titleId}",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            string deleteQuery = @"
                                DELETE FROM titleauthor
                                WHERE au_id = @auId AND title_id = @titleId";

                            SqlParameter[] parametros = new SqlParameter[]
                            {
                                new SqlParameter("@auId", auId),
                                new SqlParameter("@titleId", titleId)
                            };

                            bool exito = datos.ejecutarABC(deleteQuery, parametros);

                            if (exito)
                            {
                                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarGrid();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el registro. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (columnName == "Editar")
                {
                    // Manejar edición
                    using (var editarForm = new FormAgregarRegalias(Operacion.Editar, auId, titleId))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                        }
                    }
                }
            }
        }

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
                        ta.au_id,
                        ta.title_id,
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

                    // Ocultar las columnas de IDs
                    if (dgvRegalias.Columns.Contains("au_id"))
                        dgvRegalias.Columns["au_id"].Visible = false;

                    if (dgvRegalias.Columns.Contains("title_id"))
                        dgvRegalias.Columns["title_id"].Visible = false;

                    AgregarColumnaIcono("Editar", Properties.Resources.edit, 30, 0);
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
