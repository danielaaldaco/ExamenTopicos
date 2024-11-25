using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormEditoriales : MetroForm
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por ID, Nombre, Ciudad, País...";

        public FormEditoriales(UserRole role)
        {
            InitializeComponent();
            ConfigurarAccesoPorRol(role);
            this.Load += FormEditoriales_Load;
            activarPlaceholders(txtBuscar, placeholder);
        }

        private void FormEditoriales_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void ConfigurarAccesoPorRol(UserRole role)
        {
            dgvEditoriales.ReadOnly = true;

            switch (role)
            {
                case UserRole.Empleado:
                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    break;

                default:
                    Close();
                    break;
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        pub_id AS 'ID Editorial',
                        pub_name AS 'Nombre',
                        city AS 'Ciudad',
                        state AS 'Estado',
                        country AS 'País'
                    FROM publishers";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvEditoriales.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                }
                else
                {
                    MostrarEncabezadoVacio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEncabezadoVacio()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("ID Editorial");
            emptyTable.Columns.Add("Nombre");
            emptyTable.Columns.Add("Ciudad");
            emptyTable.Columns.Add("Estado");
            emptyTable.Columns.Add("País");
            dgvEditoriales.DataSource = emptyTable;
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvEditoriales.Columns.Contains("ID Editorial"))
                dgvEditoriales.Columns["ID Editorial"].HeaderText = "ID Editorial";

            if (dgvEditoriales.Columns.Contains("Nombre"))
                dgvEditoriales.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvEditoriales.Columns.Contains("Ciudad"))
                dgvEditoriales.Columns["Ciudad"].HeaderText = "Ciudad";

            if (dgvEditoriales.Columns.Contains("Estado"))
                dgvEditoriales.Columns["Estado"].HeaderText = "Estado";

            if (dgvEditoriales.Columns.Contains("País"))
                dgvEditoriales.Columns["País"].HeaderText = "País";

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            foreach (DataGridViewColumn col in dgvEditoriales.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                }
                else if (col.Name == "Nombre")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvEditoriales.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvEditoriales.Columns.Count)
                    dgvEditoriales.Columns.Insert(posicion, columna);
                else
                    dgvEditoriales.Columns.Add(columna);
            }
        }

        private void dgvEditoriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvEditoriales.Columns[e.ColumnIndex].Name;

                if (columnName == "Editar")
                {
                    string editorialId = dgvEditoriales.Rows[e.RowIndex].Cells["ID Editorial"].Value?.ToString();

                    if (!string.IsNullOrEmpty(editorialId))
                    {
                        using (var editarForm = new FormAddEditEditorial(Operacion.Editar, editorialId))
                        {
                            editarForm.ShowDialog();
                            if (placeholderActivo(txtBuscar.Text, placeholder))
                            {
                                ActualizarGrid();
                            }
                            else
                            {
                                txtBuscar_TextChanged(txtBuscar, EventArgs.Empty);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID de la editorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            pub_id AS 'ID Editorial',
                            pub_name AS 'Nombre',
                            city AS 'Ciudad',
                            state AS 'Estado',
                            country AS 'País'
                        FROM publishers
                        WHERE 
                            pub_name LIKE @searchValue OR 
                            pub_id LIKE @searchValue OR
                            city LIKE @searchValue OR
                            state LIKE @searchValue OR
                            country LIKE @searchValue";

                    SqlParameter[] parametros = {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvEditoriales.DataSource = ds.Tables[0];
                        ConfigurarColumnasGrid();
                    }
                    else
                    {
                        MostrarEncabezadoVacio();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAddEditEditorial(Operacion.Agregar))
            {
                agregarForm.ShowDialog();
                ActualizarGrid();
            }
        }

        private string ObtenerNuevoIdDisponible()
        {
            try
            {
                string query = @"
                    SELECT MIN(CAST(pub_id AS INT) + 1) AS NuevoId
                    FROM publishers
                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM publishers AS p2
                        WHERE CAST(p2.pub_id AS INT) = CAST(publishers.pub_id AS INT) + 1)";

                DataSet ds = datos.consulta(query);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["NuevoId"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nuevo ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "0000";
        }
    }
}