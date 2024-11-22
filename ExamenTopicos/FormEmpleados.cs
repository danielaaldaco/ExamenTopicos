using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormEmpleados : Form
    {
        DataSet ds;
        UserRole userRole;
        Datos datos = new Datos();

        public FormEmpleados(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

            dgvEmpleados.EditMode = DataGridViewEditMode.EditOnEnter;

            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void ConfigurarAccesoPorRol()
        {

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
                    contextMenuStrip1.Items["eliminarToolStripMenuItem"].Visible = true;
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
            ds = datos.consulta("SELECT emp_id, fname, minit, lname, job_desc, job_lvl, pub_id, hire_date FROM employee, jobs");

            if (ds != null)
            {
                dgvEmpleados.DataSource = ds.Tables[0];

                dgvEmpleados.Columns["emp_id"].HeaderText = "ID Empleado";
                dgvEmpleados.Columns["fname"].HeaderText = "Nombre";
                dgvEmpleados.Columns["minit"].HeaderText = "Inicial";
                dgvEmpleados.Columns["lname"].HeaderText = "Apellido";
                dgvEmpleados.Columns["job_desc"].HeaderText = "ID Puesto";
                dgvEmpleados.Columns["job_lvl"].HeaderText = "Nivel Puesto";
                dgvEmpleados.Columns["pub_id"].HeaderText = "ID Publicador";
                dgvEmpleados.Columns["hire_date"].HeaderText = "Fecha de Contratación";

                dgvEmpleados.Columns["emp_id"].ReadOnly = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text;

                string query = $@"
                    SELECT emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date
                    FROM employee
                    WHERE CAST(emp_id AS VARCHAR) LIKE '%{searchValue}%' OR 
                          fname LIKE '%{searchValue}%' OR 
                          lname LIKE '%{searchValue}%'";
                ds = datos.consulta(query);

                if (ds != null)
                {
                    dgvEmpleados.DataSource = ds.Tables[0];
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarEmpleados agregar = new FormAgregarEmpleados();
            agregar.Show();
            agregar.FormClosed += (s, args) => ActualizarGrid();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userRole != UserRole.Administrador)
            {
                MessageBox.Show("Solo un administrador puede eliminar empleados.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (dgvEmpleados.SelectedRows.Count > 0)
                {
                    string id = dgvEmpleados.SelectedRows[0].Cells["emp_id"].Value.ToString();
                    string nombre = dgvEmpleados.SelectedRows[0].Cells["fname"].Value.ToString();

                    if (MessageBox.Show($"¿Deseas eliminar al empleado '{nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool resultado = datos.ejecutarABC("DELETE FROM employee WHERE emp_id='" + id + "'");

                        if (resultado)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualizarGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro. Verifique que no esté siendo utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormAgregarEmpleados agregar = new FormAgregarEmpleados();
            agregar.Show();
            agregar.FormClosed += (s, args) => ActualizarGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (dgvEmpleados.SelectedRows.Count > 0)
                {
                    try
                    {
                        FormAgregarEmpleados editar = new FormAgregarEmpleados(
                            dgvEmpleados[0, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            dgvEmpleados[1, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            dgvEmpleados[2, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            dgvEmpleados[3, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            dgvEmpleados[4, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            Convert.ToInt32(dgvEmpleados[5, dgvEmpleados.SelectedRows[0].Index].Value ?? 0),
                            dgvEmpleados[6, dgvEmpleados.SelectedRows[0].Index].Value?.ToString() ?? "",
                            Convert.ToDateTime(dgvEmpleados[7, dgvEmpleados.SelectedRows[0].Index].Value ?? DateTime.Now)
                        );

                        editar.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

        
    }


}
