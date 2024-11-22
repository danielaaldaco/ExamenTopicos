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

            // Suscribirse al evento Resize para ajustar las columnas dinámicas proporcionalmente
            this.Resize += FormEmpleados_Resize;
        }

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
                    ConfigurarColumnas();
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

        private void ConfigurarColumnasGrid()
        {
            dgvEmpleados.Columns["ID Empleado"].HeaderText = "ID Empleado";
            dgvEmpleados.Columns["Nombre"].HeaderText = "Nombre";
            dgvEmpleados.Columns["Inicial"].HeaderText = "Inicial";
            dgvEmpleados.Columns["Apellido"].HeaderText = "Apellido";
            dgvEmpleados.Columns["Puesto"].HeaderText = "Puesto";
            dgvEmpleados.Columns["Nivel Puesto"].HeaderText = "Nivel Puesto";
            dgvEmpleados.Columns["Publicador"].HeaderText = "Publicador";
            dgvEmpleados.Columns["Fecha Contratación"].HeaderText = "Fecha de Contratación";
        }

        private void ConfigurarColumnas()
        {
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvEmpleados.Columns.Count);

            foreach (DataGridViewColumn col in dgvEmpleados.Columns)
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

            dgvEmpleados.RowTemplate.Height = ActionColumnWidth;
        }

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

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvEmpleados.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvEmpleados.RowHeadersVisible ? dgvEmpleados.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvEmpleados.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + this.Width - dgvEmpleados.Width + 20;

            ConfigurarColumnas();
        }

        private void FormEmpleados_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                int columnIndex = dgvEmpleados.Columns["Eliminar"].Index;
                int rowIndex = dgvEmpleados.CurrentRow.Index;
                dgvEmpleados_CellContentClick(sender, new DataGridViewCellEventArgs(columnIndex, rowIndex));
            }
        }

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
                    ConfigurarColumnas();
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

        private void FormEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}