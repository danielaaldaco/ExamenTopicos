using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormTitles : MetroForm
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por Título, Tipo, Editorial, Precio...";

        public FormTitles(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormTitles_Resize;
            activarPlaceholders(txtBuscar, placeholder);
            this.Load += FormTitles_Load;
            this.PreviewKeyDown += FormTitles_PreviewKeyDown;
        }

        private void FormTitles_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void FormTitles_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && !e.Shift)
            {
                txtBuscar.Focus();
                e.IsInputKey = true;
            }
        }

        private void ConfigurarAccesoPorRol()
        {
            if (userRole == UserRole.Cliente)
            {
                btnAgregar.Visible = false;
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        t.title_id AS 'ID Título',
                        t.title AS 'Título',
                        t.type AS 'Tipo',
                        p.pub_name AS 'Editorial',
                        t.price AS 'Precio',
                        t.advance AS 'Anticipo',
                        t.royalty AS 'Regalías',
                        t.ytd_sales AS 'Ventas Totales',
                        t.notes AS 'Notas',
                        t.pubdate AS 'Fecha de Publicación'
                    FROM 
                        titles t
                    LEFT JOIN 
                        publishers p ON t.pub_id = p.pub_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvTitles.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();
                }
                else
                {
                    crearHeader(dgvTitles,
                        "ID Título",
                        "Título",
                        "Tipo",
                        "Editorial",
                        "Precio",
                        "Anticipo",
                        "Regalías",
                        "Ventas Totales",
                        "Notas",
                        "Fecha de Publicación");
                    ConfigurarColumnas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvTitles.Columns.Contains("ID Título"))
                dgvTitles.Columns["ID Título"].HeaderText = "ID Título";

            if (dgvTitles.Columns.Contains("Título"))
                dgvTitles.Columns["Título"].HeaderText = "Título";

            if (dgvTitles.Columns.Contains("Tipo"))
                dgvTitles.Columns["Tipo"].HeaderText = "Tipo";

            if (dgvTitles.Columns.Contains("Editorial"))
                dgvTitles.Columns["Editorial"].HeaderText = "Editorial";

            if (dgvTitles.Columns.Contains("Precio"))
                dgvTitles.Columns["Precio"].HeaderText = "Precio";

            if (dgvTitles.Columns.Contains("Anticipo"))
                dgvTitles.Columns["Anticipo"].HeaderText = "Anticipo";

            if (dgvTitles.Columns.Contains("Regalías"))
                dgvTitles.Columns["Regalías"].HeaderText = "Regalías";

            if (dgvTitles.Columns.Contains("Ventas Totales"))
                dgvTitles.Columns["Ventas Totales"].HeaderText = "Ventas Totales";

            if (dgvTitles.Columns.Contains("Notas"))
                dgvTitles.Columns["Notas"].HeaderText = "Notas";

            if (dgvTitles.Columns.Contains("Fecha de Publicación"))
                dgvTitles.Columns["Fecha de Publicación"].HeaderText = "Fecha de Publicación";
        }

        private void ConfigurarColumnas()
        {
            if (dgvTitles.Columns.Contains("Editar"))
            {
                dgvTitles.Columns.Remove("Editar");
            }

            if (userRole == UserRole.GerenteVentas || userRole == UserRole.Administrador)
            {
                AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            }

            foreach (DataGridViewColumn col in dgvTitles.Columns)
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

            dgvTitles.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvTitles.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvTitles.Columns.Count)
                    dgvTitles.Columns.Insert(posicion, columna);
                else
                    dgvTitles.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvTitles.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvTitles.RowHeadersVisible ? dgvTitles.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvTitles.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            ConfigurarColumnas();
        }

        private void FormTitles_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAddEditTitle(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
            }
        }

        private void dgvTitles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvTitles.Columns[e.ColumnIndex].Name;

                if (columnName == "Editar")
                {
                    string titleId = dgvTitles.Rows[e.RowIndex].Cells["ID Título"].Value?.ToString();

                    if (!string.IsNullOrEmpty(titleId))
                    {
                        using (var editarForm = new FormAddEditTitle(Operacion.Editar, titleId))
                        {
                            if (editarForm.ShowDialog() == DialogResult.OK)
                            {
                                ActualizarGrid();
                                AjustarAnchoVentana();
                            }
                        }
                    }
                    else
                    {
                        crearHeader(dgvTitles,
                            "ID Título",
                            "Título",
                            "Tipo",
                            "Editorial",
                            "Precio",
                            "Anticipo",
                            "Regalías",
                            "Ventas Totales",
                            "Notas",
                            "Fecha de Publicación");
                        ConfigurarColumnas();
                        MessageBox.Show("No se pudo obtener el ID del título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            t.title_id AS 'ID Título',
                            t.title AS 'Título',
                            t.type AS 'Tipo',
                            p.pub_name AS 'Editorial',
                            t.price AS 'Precio',
                            t.advance AS 'Anticipo',
                            t.royalty AS 'Regalías',
                            t.ytd_sales AS 'Ventas Totales',
                            t.notes AS 'Notas',
                            t.pubdate AS 'Fecha de Publicación'
                        FROM 
                            titles t
                        LEFT JOIN 
                            publishers p ON t.pub_id = p.pub_id
                        WHERE 
                            t.title LIKE @searchValue 
                            OR t.title_id LIKE @searchValue
                            OR t.type LIKE @searchValue
                            OR p.pub_name LIKE @searchValue
                            OR CAST(t.price AS NVARCHAR) LIKE @searchValue
                            OR CAST(t.advance AS NVARCHAR) LIKE @searchValue
                            OR CAST(t.royalty AS NVARCHAR) LIKE @searchValue
                            OR CAST(t.ytd_sales AS NVARCHAR) LIKE @searchValue
                            OR t.notes LIKE @searchValue
                            OR CAST(t.pubdate AS NVARCHAR) LIKE @searchValue";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvTitles.DataSource = ds.Tables[0];
                        ConfigurarColumnasGrid();
                        ConfigurarColumnas();
                    }
                    else
                    {
                        crearHeader(dgvTitles,
                            "ID Título",
                            "Título",
                            "Tipo",
                            "Editorial",
                            "Precio",
                            "Anticipo",
                            "Regalías",
                            "Ventas Totales",
                            "Notas",
                            "Fecha de Publicación");
                        ConfigurarColumnas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
