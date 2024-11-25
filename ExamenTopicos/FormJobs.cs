using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormJobs : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por ID, Descripción, Nivel...";

        public FormJobs(UserRole role)
        {
            InitializeComponent();
            activarPlaceholders(txtBuscar, placeholder);
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormJobs_Resize;
            this.Load += FormJobs_Load;
            this.PreviewKeyDown += FormJobs_PreviewKeyDown;
            this.dgvPuestos.CellContentClick += dgvPuestos_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
            this.Width = 600;
        }

        private void FormJobs_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void FormJobs_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && !e.Shift)
            {
                txtBuscar.Focus();
                e.IsInputKey = true;
            }
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
                case UserRole.Administrador:
                    dgvPuestos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                default:
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
                        job_id AS 'ID Puesto',
                        job_desc AS 'Descripción',
                        min_lvl AS 'Nivel Mínimo',
                        max_lvl AS 'Nivel Máximo'
                    FROM jobs";
                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvPuestos.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    crearHeader(dgvPuestos,
                        "ID Puesto",
                        "Descripción",
                        "Nivel Mínimo",
                        "Nivel Máximo");
                    ConfigurarColumnas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvPuestos.Columns.Contains("Editar"))
            {
                dgvPuestos.Columns.Remove("Editar");
            }

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);

            foreach (DataGridViewColumn col in dgvPuestos.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvPuestos.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvPuestos.RowHeadersVisible ? dgvPuestos.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvPuestos.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            ConfigurarColumnas();
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvPuestos.Columns[e.ColumnIndex].Name;
                var row = dgvPuestos.Rows[e.RowIndex];
                string jobId = row.Cells["ID Puesto"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(jobId))
                {
                    crearHeader(dgvPuestos,
                        "ID Puesto",
                        "Descripción",
                        "Nivel Mínimo",
                        "Nivel Máximo");
                    ConfigurarColumnas();
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar")
                {
                    using (var editarForm = new FormAgregarJob(Operacion.Editar, jobId))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                            ConfigurarColumnas();
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
                if (placeholderActivo(searchValue, placeholder))
                {
                    ActualizarGrid();
                }
                else
                {
                    string query = @"
                        SELECT 
                            job_id AS 'ID Puesto', 
                            job_desc AS 'Descripción', 
                            min_lvl AS 'Nivel Mínimo', 
                            max_lvl AS 'Nivel Máximo'
                        FROM jobs
                        WHERE CAST(job_id AS VARCHAR) LIKE @searchValue OR 
                              job_desc LIKE @searchValue OR
                              CAST(min_lvl AS VARCHAR) LIKE @searchValue OR
                              CAST(max_lvl AS VARCHAR) LIKE @searchValue";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvPuestos.DataSource = ds.Tables[0];
                        ConfigurarColumnas();
                    }
                    else
                    {
                        crearHeader(dgvPuestos,
                            "ID Puesto",
                            "Descripción",
                            "Nivel Mínimo",
                            "Nivel Máximo");
                        ConfigurarColumnas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}