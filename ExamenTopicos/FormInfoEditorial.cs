using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormInfoEditorial : MetroForm
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por ID Editorial, Nombre, Información...";
        private UserRole userRole;
        public FormInfoEditorial(UserRole rol)
        {
            this.userRole = rol;
            InitializeComponent();
            ActualizarGrid();
            this.Resize += FormInfoEditorial_Resize;
            this.dgvInfoEdi.CellContentClick += dgvInfoEdi_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
            activarPlaceholders(txtBuscar, placeholder);

        }

        private void ActualizarGrid()
        {
            string query = @"
                SELECT 
                    p.pub_id AS 'ID Editorial',
                    pu.pub_name AS 'Nombre Editorial',
                    p.logo AS 'Logo',
                    p.pr_info AS 'Información'
                FROM pub_info p
                INNER JOIN publishers pu ON p.pub_id = pu.pub_id";
            ds = datos.consulta(query);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Procesar la columna de información
                DataTable table = ds.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    if (row["Información"] != DBNull.Value)
                    {
                        string info = row["Información"].ToString();
                        string[] partes = info.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        row["Información"] = partes.Length > 0 ? partes[0] : info;
                    }
                }

                dgvInfoEdi.DataSource = table;
                dgvInfoEdi.AllowUserToAddRows = false;
                dgvInfoEdi.ClearSelection();
                dgvInfoEdi.CurrentCell = null;
                ConfigurarColumnas();
            }
            else
            {
                MostrarEncabezadoVacio();
            }
        }

        private void MostrarEncabezadoVacio()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("ID Editorial");
            emptyTable.Columns.Add("Nombre Editorial");
            emptyTable.Columns.Add("Logo");
            emptyTable.Columns.Add("Información");
            dgvInfoEdi.DataSource = emptyTable;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            if (!dgvInfoEdi.Columns.Contains("Editar") && userRole == UserRole.Administrador || userRole == UserRole.Administrador)
            {
                AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            }
            foreach (DataGridViewColumn col in dgvInfoEdi.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                    col.ReadOnly = false;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (col.Name == "Nombre Editorial")
                {
                    col.HeaderText = "Nombre de la Editorial";
                }
                if (col.Name == "Información")
                {
                    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                }
            }
            dgvInfoEdi.RowTemplate.Height = 100;
        }


        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvInfoEdi.Columns.Contains(nombre))
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
                if (posicion >= 0 && posicion <= dgvInfoEdi.Columns.Count)
                    dgvInfoEdi.Columns.Insert(posicion, columna);
                else
                    dgvInfoEdi.Columns.Add(columna);
            }
        }

        private void FormInfoEditorial_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void dgvInfoEdi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvInfoEdi.Columns[e.ColumnIndex].Name;
                var row = dgvInfoEdi.Rows[e.RowIndex];
                if (columnName == "Editar")
                {
                    string pubId = row.Cells["ID Editorial"]?.Value?.ToString();
                    using (var editarForm = new FormAgregarInfo(pubId))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                        }
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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
                        p.pub_id AS 'ID Editorial',
                        pu.pub_name AS 'Nombre Editorial',
                        p.logo AS 'Logo',
                        p.pr_info AS 'Información'
                    FROM pub_info p
                    INNER JOIN publishers pu ON p.pub_id = pu.pub_id
                    WHERE 
                        p.pub_id LIKE @searchValue OR
                        pu.pub_name LIKE @searchValue OR
                        p.pr_info LIKE @searchValue";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };
                ds = datos.consulta(query, parametros);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvInfoEdi.DataSource = ds.Tables[0];
                    dgvInfoEdi.ClearSelection();
                    dgvInfoEdi.CurrentCell = null;
                    ConfigurarColumnas();
                }
                else
                {
                    MostrarEncabezadoVacio();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarInfo())
            {
                try
                {
                    if (agregarForm.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarGrid();
                    }
                }
                catch (Exception)
                {
                }
                
            }
        }
    }
}