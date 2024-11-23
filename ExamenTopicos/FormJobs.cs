using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormJobs : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30; // Ancho fijo para la columna de acción

        public FormJobs(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();

            // Ajustar las columnas dinámicas al redimensionar el formulario
            this.Resize += FormJobs_Resize;

            // Asegurar que el evento esté asociado
            this.dgvPuestos.CellContentClick += dgvPuestos_CellContentClick;
        }


        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvPuestos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvPuestos.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    dgvPuestos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvPuestos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvPuestos.ReadOnly = false;
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
                string query = "SELECT job_id AS 'ID Puesto', job_desc AS 'Descripción', min_lvl AS 'Nivel Mínimo', max_lvl AS 'Nivel Máximo' FROM jobs";
                ds = datos.consulta(query);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    dgvPuestos.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    dgvPuestos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            // Solo agregar columna de edición
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);

            foreach (DataGridViewColumn col in dgvPuestos.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                    col.ReadOnly = false; // Asegurarse de que no sea de solo lectura
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    // La propiedad ReadOnly se manejará en ConfigurarAccesoPorRol
                }
            }

            dgvPuestos.RowTemplate.Height = ActionColumnWidth;
        }


        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvPuestos.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvPuestos.Columns.Count)
                    dgvPuestos.Columns.Insert(posicion, columna);
                else
                    dgvPuestos.Columns.Add(columna);
            }
        }

        private void FormJobs_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarJob(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void dgvPuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Validar que se selecciona una fila y columna válidas
            {
                string columnName = dgvPuestos.Columns[e.ColumnIndex].Name; // Nombre de la columna clickeada
                var row = dgvPuestos.Rows[e.RowIndex];
                string jobId = row.Cells["ID Puesto"]?.Value?.ToString(); // Obtiene el ID del puesto

                // Depuración
                Console.WriteLine($"Clic en columna: {columnName}, Job ID: {jobId}");

                if (string.IsNullOrWhiteSpace(jobId)) // Verifica si el ID del puesto es válido
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar") // Si se presionó el ícono de "Editar"
                {
                    // Abre el formulario de edición
                    using (var editarForm = new FormAgregarJob(Operacion.Editar, jobId)) // Pasar el ID del puesto al formulario
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK) // Si se confirma la edición
                        {
                            ActualizarGrid(); // Refresca el DataGridView
                            ConfigurarColumnas(); // Ajusta las columnas si es necesario
                        }
                    }
                }
            }
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text.Trim();
                string query = @"
                    SELECT 
                        job_id AS 'ID Puesto', 
                        job_desc AS 'Descripción', 
                        min_lvl AS 'Nivel Mínimo', 
                        max_lvl AS 'Nivel Máximo'
                    FROM jobs
                    WHERE CAST(job_id AS VARCHAR) LIKE @searchValue OR 
                          job_desc LIKE @searchValue";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPuestos.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    dgvPuestos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
