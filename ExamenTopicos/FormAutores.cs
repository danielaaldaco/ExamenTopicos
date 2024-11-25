using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormAutores : MetroForm
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por ID, Apellido, Nombre...";

        public FormAutores()
        {
            InitializeComponent();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormAutores_Resize;
            activarPlaceholders(txtBuscar, placeholder);
            this.Load += FormAutores_Load;
            this.PreviewKeyDown += FormAutores_PreviewKeyDown;
            this.dgvAutores.CellContentClick += dgvAutores_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormAutores_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void FormAutores_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && !e.Shift)
            {
                txtBuscar.Focus();
                e.IsInputKey = true;
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        au_id AS 'ID Autor',
                        au_lname AS 'Apellido',
                        au_fname AS 'Nombre',
                        phone AS 'Teléfono',
                        address AS 'Dirección',
                        city AS 'Ciudad',
                        state AS 'Estado',
                        zip AS 'Código Postal',
                        contract AS 'Contrato'
                    FROM authors";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvAutores.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    crearHeader(dgvAutores,
                        "ID Autor",
                        "Apellido",
                        "Nombre",
                        "Teléfono",
                        "Dirección",
                        "Ciudad",
                        "Estado",
                        "Código Postal",
                        "Contrato");
                    ConfigurarColumnas();
                }
            }
            catch
            {
                MessageBox.Show("Error al actualizar la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvAutores.Columns.Contains("Editar"))
            {
                dgvAutores.Columns.Remove("Editar");
            }

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);

            foreach (DataGridViewColumn col in dgvAutores.Columns)
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

            dgvAutores.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvAutores.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvAutores.Columns.Count)
                    dgvAutores.Columns.Insert(posicion, columna);
                else
                    dgvAutores.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvAutores.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvAutores.RowHeadersVisible ? dgvAutores.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvAutores.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            ConfigurarColumnas();
        }

        private void FormAutores_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarAutores("Agregar"))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvAutores.Columns[e.ColumnIndex].Name;
                var row = dgvAutores.Rows[e.RowIndex];
                string auId = row.Cells["ID Autor"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(auId))
                {
                    crearHeader(dgvAutores,
                        "ID Autor",
                        "Apellido",
                        "Nombre",
                        "Teléfono",
                        "Dirección",
                        "Ciudad",
                        "Estado",
                        "Código Postal",
                        "Contrato");
                    ConfigurarColumnas();
                    MessageBox.Show("No se pudo obtener el ID del autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar")
                {
                    string auLname = row.Cells["Apellido"]?.Value?.ToString();
                    string auFname = row.Cells["Nombre"]?.Value?.ToString();
                    string phone = row.Cells["Teléfono"]?.Value?.ToString();
                    string address = row.Cells["Dirección"]?.Value?.ToString();
                    string city = row.Cells["Ciudad"]?.Value?.ToString();
                    string state = row.Cells["Estado"]?.Value?.ToString();
                    string zip = row.Cells["Código Postal"]?.Value?.ToString();
                    bool contract = Convert.ToBoolean(row.Cells["Contrato"]?.Value);

                    using (var editarForm = new FormAgregarAutores("Editar", auId, auLname, auFname, phone, address, city, state, zip, contract))
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
                            au_id AS 'ID Autor',
                            au_lname AS 'Apellido',
                            au_fname AS 'Nombre',
                            phone AS 'Teléfono',
                            address AS 'Dirección',
                            city AS 'Ciudad',
                            state AS 'Estado',
                            zip AS 'Código Postal',
                            contract AS 'Contrato'
                        FROM authors
                        WHERE 
                            au_id LIKE @searchValue OR
                            au_lname LIKE @searchValue OR
                            au_fname LIKE @searchValue OR
                            phone LIKE @searchValue OR
                            address LIKE @searchValue OR
                            city LIKE @searchValue OR
                            state LIKE @searchValue OR
                            zip LIKE @searchValue OR
                            CAST(contract AS NVARCHAR) LIKE @searchValue";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvAutores.DataSource = ds.Tables[0];
                        ConfigurarColumnas();
                    }
                    else
                    {
                        crearHeader(dgvAutores,
                            "ID Autor",
                            "Apellido",
                            "Nombre",
                            "Teléfono",
                            "Dirección",
                            "Ciudad",
                            "Estado",
                            "Código Postal",
                            "Contrato");
                        ConfigurarColumnas();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarPlaceholders(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
