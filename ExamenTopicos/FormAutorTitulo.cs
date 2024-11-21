using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAutorTitulo : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private Dictionary<int, RowBackupData> rowBackups = new Dictionary<int, RowBackupData>();
        private bool isUpdatingGrid = false;

        public FormAutorTitulo(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();

            dgvAutoresTitulos.EditMode = DataGridViewEditMode.EditOnEnter;

            // Asignar manejadores de eventos correctamente
            dgvAutoresTitulos.CellBeginEdit += dgvAutoresTitulos_CellBeginEdit;
            dgvAutoresTitulos.RowValidating += dgvAutoresTitulos_RowValidating;
            dgvAutoresTitulos.EditingControlShowing += dgvAutoresTitulos_EditingControlShowing;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnAgregar.Click += btnAgregar_Click;
        }

        /// <summary>
        /// Configura la interfaz según el rol del usuario.
        /// </summary>
        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvAutoresTitulos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvAutoresTitulos.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvAutoresTitulos.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Actualiza el DataGridView con los datos de la base de datos.
        /// </summary>
        private void ActualizarGrid()
        {
            try
            {
                dgvAutoresTitulos.EndEdit(); // Completa cualquier edición pendiente.
                isUpdatingGrid = true;
                ds = datos.consulta("SELECT au_id, title_id, au_ord, royaltyper FROM titleauthor");

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    dgvAutoresTitulos.Refresh(); // Asegura que se actualice visualmente
                }
                else
                {
                    dgvAutoresTitulos.DataSource = null;
                }

                rowBackups.Clear();

                // Seleccionar la primera fila si existen registros
                if (dgvAutoresTitulos.Rows.Count > 0)
                {
                    dgvAutoresTitulos.ClearSelection();
                    dgvAutoresTitulos.Rows[0].Selected = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                // Manejo específico para errores de cambio de celdas.
                if (!isUpdatingGrid)
                {
                    MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isUpdatingGrid = false;
            }
        }

        /// <summary>
        /// Configura los encabezados y propiedades de las columnas del DataGridView.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            if (dgvAutoresTitulos.Columns.Contains("au_id"))
                dgvAutoresTitulos.Columns["au_id"].HeaderText = "ID Autor";

            if (dgvAutoresTitulos.Columns.Contains("title_id"))
                dgvAutoresTitulos.Columns["title_id"].HeaderText = "ID Título";

            if (dgvAutoresTitulos.Columns.Contains("au_ord"))
                dgvAutoresTitulos.Columns["au_ord"].HeaderText = "Orden";

            if (dgvAutoresTitulos.Columns.Contains("royaltyper"))
                dgvAutoresTitulos.Columns["royaltyper"].HeaderText = "Regalía (%)";

            if (dgvAutoresTitulos.Columns.Contains("au_id"))
                dgvAutoresTitulos.Columns["au_id"].ReadOnly = true;

            if (dgvAutoresTitulos.Columns.Contains("title_id"))
                dgvAutoresTitulos.Columns["title_id"].ReadOnly = true;
        }

        /// <summary>
        /// Maneja el evento cuando se comienza a editar una celda.
        /// </summary>
        private void dgvAutoresTitulos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!rowBackups.ContainsKey(e.RowIndex))
            {
                DataGridViewRow row = dgvAutoresTitulos.Rows[e.RowIndex];
                rowBackups[e.RowIndex] = new RowBackupData
                {
                    AutorId = row.Cells["au_id"].Value?.ToString(),
                    TituloId = row.Cells["title_id"].Value?.ToString(),
                    Orden = Convert.ToInt32(row.Cells["au_ord"].Value),
                    Regalía = Convert.ToInt32(row.Cells["royaltyper"].Value)
                };
            }
        }

        /// <summary>
        /// Valida la fila después de la edición.
        /// </summary>
        private void dgvAutoresTitulos_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (isUpdatingGrid || e.RowIndex < 0 || e.RowIndex >= dgvAutoresTitulos.Rows.Count)
                {
                    e.Cancel = true;
                    return;
                }

                DataGridViewRow row = dgvAutoresTitulos.Rows[e.RowIndex];
                string autorId = row.Cells["au_id"]?.Value?.ToString()?.Trim();
                string tituloId = row.Cells["title_id"]?.Value?.ToString()?.Trim();

                if (!rowBackups.ContainsKey(e.RowIndex))
                    return;

                RowBackupData originalData = rowBackups[e.RowIndex];
                string newOrdenStr = row.Cells["au_ord"].Value?.ToString()?.Trim();
                string newRoyaltyStr = row.Cells["royaltyper"].Value?.ToString()?.Trim();

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(autorId) || string.IsNullOrWhiteSpace(tituloId))
                {
                    MessageBox.Show("El ID del Autor y el Título son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (!int.TryParse(newOrdenStr, out int newOrden) || newOrden < 1)
                {
                    MessageBox.Show("El orden debe ser un número entero mayor o igual a 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (!int.TryParse(newRoyaltyStr, out int newRoyalty) || newRoyalty < 0 || newRoyalty > 100)
                {
                    MessageBox.Show("La regalía debe estar entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                // Verificar si hay cambios
                if (originalData.Orden != newOrden || originalData.Regalía != newRoyalty)
                {
                    StringBuilder cambios = new StringBuilder("¿Deseas guardar los siguientes cambios?\n");

                    if (originalData.Orden != newOrden)
                    {
                        cambios.AppendLine($"- Orden: {originalData.Orden} ➔ {newOrden}");
                    }

                    if (originalData.Regalía != newRoyalty)
                    {
                        cambios.AppendLine($"- Regalía: {originalData.Regalía} ➔ {newRoyalty}");
                    }

                    DialogResult result = MessageBox.Show(cambios.ToString(), "Confirmar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // **Recomendación:** Utilizar consultas parametrizadas para prevenir inyecciones SQL.
                            string query = $"UPDATE titleauthor SET au_ord = {newOrden}, royaltyper = {newRoyalty} " +
                                           $"WHERE au_id = '{autorId}' AND title_id = '{tituloId}'";
                            datos.ejecutarABC(query);

                            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualizarGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        dgvAutoresTitulos.CancelEdit();
                        ActualizarGrid();
                    }
                }

                rowBackups.Remove(e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en RowValidating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Maneja el evento de mostrar controles de edición en el DataGridView.
        /// </summary>
        private void dgvAutoresTitulos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= TextBox_KeyPress;
                tb.KeyPress += TextBox_KeyPress;
            }
        }

        /// <summary>
        /// Restringe la entrada de caracteres a solo dígitos para ciertas columnas.
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvAutoresTitulos.CurrentCell.ColumnIndex == dgvAutoresTitulos.Columns["au_ord"].Index ||
                dgvAutoresTitulos.CurrentCell.ColumnIndex == dgvAutoresTitulos.Columns["royaltyper"].Index)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de búsqueda.
        /// </summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    ActualizarGrid();
                    return;
                }

                // **Recomendación:** Utilizar consultas parametrizadas para prevenir inyecciones SQL.
                string query = $"SELECT au_id, title_id, au_ord, royaltyper FROM titleauthor " +
                               $"WHERE au_id LIKE '%{searchValue}%' OR title_id LIKE '%{searchValue}%'";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    dgvAutoresTitulos.Refresh(); // Asegura que se actualice visualmente
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

        /// <summary>
        /// Abre el formulario para agregar un nuevo registro.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)  
        {
            FormTitles agregar = new FormTitles(userRole);
            agregar.Show();
            agregar.FormClosed += (s, args) => ActualizarGrid();
        }
         
        /// <summary>
        /// Método dedicado exclusivamente a la eliminación de registros. 
        /// </summary>
        private void eliminarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAutoresTitulos.EndEdit(); // Asegura que no haya ediciones pendientes.

                if (dgvAutoresTitulos.SelectedRows.Count > 0)
                {
                    string autorId = dgvAutoresTitulos.SelectedRows[0].Cells["au_id"].Value?.ToString();
                    string tituloId = dgvAutoresTitulos.SelectedRows[0].Cells["title_id"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(autorId) || string.IsNullOrWhiteSpace(tituloId))
                    {
                        MessageBox.Show("No se pudo obtener el ID del Autor o del Título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult confirmResult = MessageBox.Show(
                        $"¿Eliminar el registro de Autor '{autorId}' y Título '{tituloId}'?",
                        "Eliminar Registro",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        EliminarRegistro(autorId, tituloId);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la eliminación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método encargado de eliminar un registro específico de la base de datos.
        /// </summary>
        /// <param name="autorId">ID del Autor.</param>
        /// <param name="tituloId">ID del Título.</param>
        private void EliminarRegistro(string autorId, string tituloId)
        {
            try
            {
                // Construir la consulta SQL de eliminación
                string query = $"DELETE FROM titleauthor WHERE au_id = '{autorId}' AND title_id = '{tituloId}'";

                // Ejecutar la consulta de eliminación
                bool exito = datos.ejecutarABC(query);

                if (exito)
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrid(); // Recargar toda la tabla
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Clase de respaldo de datos de fila para manejar actualizaciones.
    /// </summary>
    public class RowBackupData
    {
        public string AutorId { get; set; }
        public string TituloId { get; set; }
        public int Orden { get; set; }
        public int Regalía { get; set; }
    }
}
