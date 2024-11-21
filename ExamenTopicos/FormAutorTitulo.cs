using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAutorTitulo : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        public FormAutorTitulo(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        /// <summary>
        /// Configura el acceso a funcionalidades según el rol del usuario.
        /// </summary>
        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvAutoresTitulos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    break;
                case UserRole.Empleado:
                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    break;
                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Actualiza el contenido del DataGridView con los datos de la base de datos.
        /// </summary>
        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        a.au_id,
                        a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                        t.title_id,
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
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    // Ocultar las columnas de IDs
                    if (dgvAutoresTitulos.Columns.Contains("au_id"))
                        dgvAutoresTitulos.Columns["au_id"].Visible = false;

                    if (dgvAutoresTitulos.Columns.Contains("title_id"))
                        dgvAutoresTitulos.Columns["title_id"].Visible = false;

                    // Agregar la columna "Editar" si no existe
                    if (!dgvAutoresTitulos.Columns.Contains("Editar"))
                    {
                        DataGridViewButtonColumn editarColumn = new DataGridViewButtonColumn();
                        editarColumn.Name = "Editar";
                        editarColumn.HeaderText = "Editar";
                        editarColumn.Text = "Editar";
                        editarColumn.UseColumnTextForButtonValue = true;
                        dgvAutoresTitulos.Columns.Add(editarColumn);
                    }

                    // Agregar la columna "Eliminar" si no existe
                    if (!dgvAutoresTitulos.Columns.Contains("Eliminar"))
                    {
                        DataGridViewButtonColumn eliminarColumn = new DataGridViewButtonColumn();
                        eliminarColumn.Name = "Eliminar";
                        eliminarColumn.HeaderText = "Eliminar";
                        eliminarColumn.Text = "Eliminar";
                        eliminarColumn.UseColumnTextForButtonValue = true;
                        dgvAutoresTitulos.Columns.Add(eliminarColumn);
                    }
                }
                else
                {
                    dgvAutoresTitulos.DataSource = null;
                }

                if (dgvAutoresTitulos.Rows.Count > 0)
                {
                    dgvAutoresTitulos.ClearSelection();
                    dgvAutoresTitulos.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvAutoresTitulos.Columns.Contains("Nombre Autor"))
                dgvAutoresTitulos.Columns["Nombre Autor"].HeaderText = "Autor";

            if (dgvAutoresTitulos.Columns.Contains("Título"))
                dgvAutoresTitulos.Columns["Título"].HeaderText = "Título";

            if (dgvAutoresTitulos.Columns.Contains("Orden"))
                dgvAutoresTitulos.Columns["Orden"].HeaderText = "Orden";

            if (dgvAutoresTitulos.Columns.Contains("Regalía (%)"))
                dgvAutoresTitulos.Columns["Regalía (%)"].HeaderText = "Regalía (%)";
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
                            t.title_id,
                            t.title AS 'Título',
                            ta.au_ord AS 'Orden',
                            ta.royaltyper AS 'Regalía (%)'
                        FROM 
                            titleauthor ta
                        INNER JOIN 
                            authors a ON ta.au_id = a.au_id
                        INNER JOIN 
                            titles t ON ta.title_id = t.title_id"
                            : $@"
                        SELECT 
                            a.au_id,
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title_id,
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
                            a.au_lname + ' ' + a.au_fname LIKE '%{searchValue}%' 
                            OR t.title LIKE '%{searchValue}%'";

                ds = datos.consulta(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    // Ocultar las columnas de IDs
                    if (dgvAutoresTitulos.Columns.Contains("au_id"))
                        dgvAutoresTitulos.Columns["au_id"].Visible = false;

                    if (dgvAutoresTitulos.Columns.Contains("title_id"))
                        dgvAutoresTitulos.Columns["title_id"].Visible = false;

                    // Asegurar que la columna "Editar" esté presente
                    if (!dgvAutoresTitulos.Columns.Contains("Editar"))
                    {
                        DataGridViewButtonColumn editarColumn = new DataGridViewButtonColumn();
                        editarColumn.Name = "Editar";
                        editarColumn.HeaderText = "Editar";
                        editarColumn.Text = "Editar";
                        editarColumn.UseColumnTextForButtonValue = true;
                        dgvAutoresTitulos.Columns.Add(editarColumn);
                    }

                    // Asegurar que la columna "Eliminar" esté presente
                    if (!dgvAutoresTitulos.Columns.Contains("Eliminar"))
                    {
                        DataGridViewButtonColumn eliminarColumn = new DataGridViewButtonColumn();
                        eliminarColumn.Name = "Eliminar";
                        eliminarColumn.HeaderText = "Eliminar";
                        eliminarColumn.Text = "Eliminar";
                        eliminarColumn.UseColumnTextForButtonValue = true;
                        dgvAutoresTitulos.Columns.Add(eliminarColumn);
                    }
                }
                else
                {
                    dgvAutoresTitulos.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Error en la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregar = new FormAgregarAT("Agregar"))
            {
                agregar.ShowDialog();
            }
            ActualizarGrid();
        }

        private void dgvAutoresTitulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila y columna sean válidas
            if (e.RowIndex >= 0)
            {
                string columnName = dgvAutoresTitulos.Columns[e.ColumnIndex].Name;

                if (columnName == "Eliminar")
                {
                    // Manejar eliminación
                    var row = dgvAutoresTitulos.Rows[e.RowIndex];
                    string auId = row.Cells["au_id"]?.Value?.ToString() ?? string.Empty;
                    string titleId = row.Cells["title_id"]?.Value?.ToString() ?? string.Empty;
                    string nombreAutor = row.Cells["Nombre Autor"]?.Value?.ToString() ?? "Desconocido";
                    string titulo = row.Cells["Título"]?.Value?.ToString() ?? "Desconocido";

                    if (string.IsNullOrWhiteSpace(auId) || string.IsNullOrWhiteSpace(titleId))
                    {
                        MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar el siguiente registro?\n\nID Autor: {auId}\nAutor: {nombreAutor}\nTítulo: {titulo}",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Realizar la eliminación
                        try
                        {
                            string deleteQuery = @"
                                DELETE FROM titleauthor
                                WHERE au_id = @auId AND title_id = @titleId";

                            // Crear parámetros para la consulta
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
                    var row = dgvAutoresTitulos.Rows[e.RowIndex];
                    string auId = row.Cells["au_id"]?.Value?.ToString() ?? string.Empty;
                    string titleId = row.Cells["title_id"]?.Value?.ToString() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(auId) || string.IsNullOrWhiteSpace(titleId))
                    {
                        MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Abrir el formulario de edición, pasando los IDs
                    using (var editarForm = new FormAgregarAT("Editar", auId, titleId))
                    {
                        editarForm.ShowDialog();
                    }

                    // Actualizar el DataGridView después de la edición
                    ActualizarGrid();
                }
            }
        }
    }
}