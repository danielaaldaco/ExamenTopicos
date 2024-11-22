using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormEmpleados : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        // Tamaño fijo para las columnas de acción
        private const int ActionColumnWidth = 30;

        public FormEmpleados(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
        }

        /// <summary>
        /// Configura la interfaz y los permisos según el rol del usuario.
        /// </summary>
        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            eliminarToolStripMenuItem.Visible = false;
            dgvEmpleados.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvEmpleados.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    dgvEmpleados.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvEmpleados.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    eliminarToolStripMenuItem.Visible = true;
                    dgvEmpleados.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Actualiza el DataGridView con los datos de empleados.
        /// </summary>
        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        e.emp_id AS 'ID Empleado', 
                        e.fname AS 'Nombre', 
                        e.minit AS 'Inicial', 
                        e.lname AS 'Apellido', 
                        j.job_desc AS 'Puesto', 
                        e.job_lvl AS 'Nivel Puesto', 
                        p.pub_name AS 'Publicador', 
                        e.hire_date AS 'Fecha Contratación'
                    FROM employee e
                    INNER JOIN jobs j ON e.job_id = j.job_id
                    INNER JOIN publishers p ON e.pub_id = p.pub_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvEmpleados.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    // Desactivar el ajuste automático global
                    dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // Configurar cada columna
                    foreach (DataGridViewColumn col in dgvEmpleados.Columns)
                    {
                        if (col.Name == "Editar" || col.Name == "Eliminar")
                        {
                            // Establecer ancho fijo para columnas de acciones
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.Width = ActionColumnWidth;
                        }
                        else
                        {
                            // Ajustar automáticamente al contenido para columnas de datos
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            col.Width = Math.Max(0, ActionColumnWidth);
                        }
                    }

                    // Agregar columnas de iconos si no existen
                    AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
                    AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvEmpleados.Columns.Count);

                    // Opcional: Ajustar la altura de las filas para mostrar los iconos correctamente
                    dgvEmpleados.RowTemplate.Height = ActionColumnWidth;
                }
                else
                {
                    dgvEmpleados.DataSource = null;
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
            // Personalizar los encabezados si es necesario
            dgvEmpleados.Columns["ID Empleado"].HeaderText = "ID Empleado";
            dgvEmpleados.Columns["Nombre"].HeaderText = "Nombre";
            dgvEmpleados.Columns["Inicial"].HeaderText = "Inicial";
            dgvEmpleados.Columns["Apellido"].HeaderText = "Apellido";
            dgvEmpleados.Columns["Puesto"].HeaderText = "Puesto";
            dgvEmpleados.Columns["Nivel Puesto"].HeaderText = "Nivel Puesto";
            dgvEmpleados.Columns["Publicador"].HeaderText = "Publicador";
            dgvEmpleados.Columns["Fecha Contratación"].HeaderText = "Fecha de Contratación";
        }

        /// <summary>
        /// Agrega una columna de imagen (icono) al DataGridView.
        /// </summary>
        /// <param name="nombre">Nombre de la columna.</param>
        /// <param name="imagen">Imagen a mostrar en la columna.</param>
        /// <param name="ancho">Ancho fijo de la columna.</param>
        /// <param name="posicion">Posición donde insertar la columna.</param>
        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvEmpleados.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvEmpleados.Columns.Count)
                    dgvEmpleados.Columns.Insert(posicion, columna);
                else
                    dgvEmpleados.Columns.Add(columna);
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
                string query = @"
                    SELECT 
                        e.emp_id AS 'ID Empleado', 
                        e.fname AS 'Nombre', 
                        e.minit AS 'Inicial', 
                        e.lname AS 'Apellido', 
                        j.job_desc AS 'Puesto', 
                        e.job_lvl AS 'Nivel Puesto', 
                        p.pub_name AS 'Publicador', 
                        e.hire_date AS 'Fecha Contratación'
                    FROM employee e
                    INNER JOIN jobs j ON e.job_id = j.job_id
                    INNER JOIN publishers p ON e.pub_id = p.pub_id
                    WHERE CAST(e.emp_id AS NVARCHAR) LIKE @searchValue OR 
                          e.fname LIKE @searchValue OR 
                          e.lname LIKE @searchValue OR 
                          j.job_desc LIKE @searchValue OR 
                          p.pub_name LIKE @searchValue";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvEmpleados.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();

                    // Reaplicar el ajuste de columnas
                    foreach (DataGridViewColumn col in dgvEmpleados.Columns)
                    {
                        if (col.Name == "Editar" || col.Name == "Eliminar")
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.Width = ActionColumnWidth;
                        }
                        else
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                    }

                    // Reagregar columnas de iconos si es necesario
                    AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
                    AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvEmpleados.Columns.Count);
                }
                else
                {
                    dgvEmpleados.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en las celdas del DataGridView.
        /// </summary>
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvEmpleados.Columns[e.ColumnIndex].Name;
                var row = dgvEmpleados.Rows[e.RowIndex];
                string empId = row.Cells["ID Empleado"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(empId))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Eliminar")
                {
                    // Manejar eliminación
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar al empleado con ID: {empId}?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            string deleteQuery = @"
                                DELETE FROM employee
                                WHERE emp_id = @empId";

                            SqlParameter[] parametros = new SqlParameter[]
                            {
                                new SqlParameter("@empId", empId)
                            };

                            bool exito = datos.ejecutarABC(deleteQuery, parametros);

                            if (exito)
                            {
                                MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarGrid();
                                AjustarAnchoVentana();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el registro. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    using (var editarForm = new FormAgregarEmpleados(Operacion.Editar, empId))
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
        /// Maneja el evento de clic en el botón Agregar.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarEmpleados(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el menú de eliminar.
        /// </summary>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                int columnIndex = dgvEmpleados.Columns["Eliminar"].Index;
                int rowIndex = dgvEmpleados.CurrentRow.Index;
                dgvEmpleados_CellContentClick(sender, new DataGridViewCellEventArgs(columnIndex, rowIndex));
            }
        }

        /// <summary>
        /// Ajusta el tamaño de la ventana para acomodar el DataGridView.
        /// </summary>
        private void AjustarAnchoVentana()
        {
            // Calcular el ancho total de todas las columnas visibles
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvEmpleados.Columns)
            {
                totalColumnWidth += col.Width;
            }

            // Sumar el ancho de los encabezados de fila si están visibles
            int rowHeaderWidth = dgvEmpleados.RowHeadersVisible ? dgvEmpleados.RowHeadersWidth : 0;

            // Calcular el espacio adicional necesario (bordes, márgenes, etc.)
            int extraWidth = this.Width - dgvEmpleados.ClientSize.Width;

            // Establecer el ancho exacto del formulario para eliminar espacio gris
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            // Aplicar el nuevo tamaño al formulario sin modificar la altura
            this.Width = newWidth + this.Width - dgvEmpleados.Width + 20;

            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}