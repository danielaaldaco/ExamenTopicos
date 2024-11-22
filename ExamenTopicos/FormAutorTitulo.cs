// FormAutorTitulo.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAutorTitulo : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        // Tamaño fijo para las columnas de acción
        private const int ActionColumnWidth = 30;

        public FormAutorTitulo(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();

            // Suscribirse al evento Resize para ajustar las columnas dinámicas proporcionalmente
            this.Resize += FormAutorTitulo_Resize;
        }

        /// <summary>
        /// Configura el acceso a funcionalidades según el rol del usuario.
        /// </summary>
        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            eliminarToolStripMenuItem.Visible = false;
            dgvAutoresTitulos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvAutoresTitulos.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    dgvAutoresTitulos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvAutoresTitulos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    eliminarToolStripMenuItem.Visible = true;
                    dgvAutoresTitulos.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
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
                        a.au_id AS 'ID Autor',
                        a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                        t.title_id AS 'ID Título',
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
                    ConfigurarColumnas();
                }
                else
                {
                    dgvAutoresTitulos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura los encabezados de las columnas del DataGridView.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            if (dgvAutoresTitulos.Columns.Contains("ID Autor"))
                dgvAutoresTitulos.Columns["ID Autor"].HeaderText = "ID Autor";

            if (dgvAutoresTitulos.Columns.Contains("Nombre Autor"))
                dgvAutoresTitulos.Columns["Nombre Autor"].HeaderText = "Autor";

            if (dgvAutoresTitulos.Columns.Contains("ID Título"))
                dgvAutoresTitulos.Columns["ID Título"].HeaderText = "ID Título";

            if (dgvAutoresTitulos.Columns.Contains("Título"))
                dgvAutoresTitulos.Columns["Título"].HeaderText = "Título";

            if (dgvAutoresTitulos.Columns.Contains("Orden"))
                dgvAutoresTitulos.Columns["Orden"].HeaderText = "Orden";

            if (dgvAutoresTitulos.Columns.Contains("Regalía (%)"))
                dgvAutoresTitulos.Columns["Regalía (%)"].HeaderText = "Regalía (%)";
        }

        /// <summary>
        /// Configura las columnas adicionales del DataGridView (Editar y Eliminar).
        /// </summary>
        private void ConfigurarColumnas()
        {
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvAutoresTitulos.Columns.Count);

            foreach (DataGridViewColumn col in dgvAutoresTitulos.Columns)
            {
                if (col.Name == "Editar" || col.Name == "Eliminar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            dgvAutoresTitulos.RowTemplate.Height = ActionColumnWidth;
        }

        /// <summary>
        /// Agrega una columna de icono al DataGridView.
        /// </summary>
        /// <param name="nombre">Nombre de la columna.</param>
        /// <param name="imagen">Imagen a mostrar.</param>
        /// <param name="ancho">Ancho de la columna.</param>
        /// <param name="posicion">Posición donde insertar la columna.</param>
        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvAutoresTitulos.Columns.Contains(nombre))
            {
                var columna = new DataGridViewImageColumn
                {
                    Name = nombre,
                    HeaderText = "",
                    Image = imagen,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = ancho,
                    Resizable = DataGridViewTriState.False
                };

                if (posicion >= 0 && posicion < dgvAutoresTitulos.Columns.Count)
                    dgvAutoresTitulos.Columns.Insert(posicion, columna);
                else
                    dgvAutoresTitulos.Columns.Add(columna);
            }
        }

        /// <summary>
        /// Ajusta el ancho de la ventana según las columnas del DataGridView.
        /// </summary>
        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvAutoresTitulos.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvAutoresTitulos.RowHeadersVisible ? dgvAutoresTitulos.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvAutoresTitulos.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20; // Ajustar según sea necesario

            ConfigurarColumnas();
        }

        /// <summary>
        /// Evento que se dispara cuando cambia el tamaño de la ventana.
        /// </summary>
        private void FormAutorTitulo_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón "Agregar".
        /// Abre el formulario para agregar un nuevo registro.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarAT(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en una celda del DataGridView.
        /// Maneja la eliminación y edición de registros cuando se hace clic en los botones correspondientes.
        /// </summary>
        private void dgvAutoresTitulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila y columna sean válidas
            if (e.RowIndex >= 0)
            {
                string columnName = dgvAutoresTitulos.Columns[e.ColumnIndex].Name;

                var row = dgvAutoresTitulos.Rows[e.RowIndex];
                string auId = row.Cells["ID Autor"]?.Value?.ToString();
                string titleId = row.Cells["ID Título"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(auId) || string.IsNullOrWhiteSpace(titleId))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Eliminar")
                {
                    // Manejar eliminación
                    string nombreAutor = row.Cells["Nombre Autor"]?.Value?.ToString() ?? "Desconocido";
                    string titulo = row.Cells["Título"]?.Value?.ToString() ?? "Desconocido";

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
                            SqlParameter[] parametros = new SqlParameter[] {
                                new SqlParameter("@auId", auId),
                                new SqlParameter("@titleId", titleId)
                            };

                            bool exito = datos.ejecutarABC(deleteQuery, parametros);

                            if (exito)
                            {
                                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarGrid();
                                AjustarAnchoVentana();
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
                    using (var editarForm = new FormAgregarAT(Operacion.Editar, auId, titleId))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                            AjustarAnchoVentana();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el elemento del menú "Eliminar".
        /// </summary>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAutoresTitulos.CurrentRow != null)
            {
                int columnIndex = dgvAutoresTitulos.Columns["Eliminar"].Index;
                int rowIndex = dgvAutoresTitulos.CurrentRow.Index;
                dgvAutoresTitulos_CellContentClick(sender, new DataGridViewCellEventArgs(columnIndex, rowIndex));
            }
        }

        /// <summary>
        /// Evento que se dispara cuando cambia el texto en el cuadro de búsqueda.
        /// Filtra los datos mostrados en el DataGridView.
        /// </summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = System.Text.RegularExpressions.Regex.Replace(txtBuscar.Text.Trim(), @"\s+", " ");
                string query = string.IsNullOrWhiteSpace(searchValue)
                            ? @"
                        SELECT 
                            a.au_id AS 'ID Autor',
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title_id AS 'ID Título',
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
                            a.au_id AS 'ID Autor',
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title_id AS 'ID Título',
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

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();

                    // Ocultar las columnas de IDs
                    if (dgvAutoresTitulos.Columns.Contains("ID Autor"))
                        dgvAutoresTitulos.Columns["ID Autor"].Visible = false;

                    if (dgvAutoresTitulos.Columns.Contains("ID Título"))
                        dgvAutoresTitulos.Columns["ID Título"].Visible = false;

                    // Asegurar que la columna "Editar" esté presente
                    if (!dgvAutoresTitulos.Columns.Contains("Editar"))
                    {
                        DataGridViewImageColumn lapizColumn = new DataGridViewImageColumn
                        {
                            Name = "Editar",
                            HeaderText = "", // Sin encabezado
                            Image = Properties.Resources.lapiz, // Asegúrate de que pencil2.png esté en tus recursos
                            ImageLayout = DataGridViewImageCellLayout.Zoom,
                            Width = 30
                        };
                        dgvAutoresTitulos.Columns.Insert(0, lapizColumn);
                    }

                    // Asegurar que la columna "Eliminar" esté presente
                    if (!dgvAutoresTitulos.Columns.Contains("Eliminar"))
                    {
                        DataGridViewImageColumn eliminarColumn = new DataGridViewImageColumn
                        {
                            Name = "Eliminar",
                            HeaderText = "", // Sin encabezado
                            Image = Properties.Resources.mdi__garbage, // Asegúrate de que garbage.png esté en tus recursos
                            ImageLayout = DataGridViewImageCellLayout.Zoom,
                            Width = 30
                        };
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
    }
}