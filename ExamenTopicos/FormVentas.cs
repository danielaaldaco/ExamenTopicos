using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormVentas : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        private const int ActionColumnWidth = 30;

        public FormVentas(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormVentas_Resize;
            activarPlaceholders(txtBuscar, "Buscar por Tienda, Orden, Título...");
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvVentas.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvVentas.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    btnAgregar.Visible = true;
                    dgvVentas.ReadOnly = true;
                    break;

                case UserRole.GerenteVentas:
                    btnAgregar.Visible = true;
                    dgvVentas.ReadOnly = false;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvVentas.ReadOnly = false;
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
                        s.stor_id AS 'ID Tienda',
                        st.stor_name AS 'Nombre Tienda',
                        s.ord_num AS 'Número de Orden',
                        s.ord_date AS 'Fecha Orden',
                        s.qty AS 'Cantidad',
                        s.payterms AS 'Condiciones de Pago',
                        t.title AS 'Título de Venta'
                    FROM sales s
                    INNER JOIN stores st ON s.stor_id = st.stor_id
                    INNER JOIN titles t ON s.title_id = t.title_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvVentas.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();
                }
                else
                {
                    dgvVentas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            dgvVentas.Columns["ID Tienda"].HeaderText = "ID Tienda";
            dgvVentas.Columns["Nombre Tienda"].HeaderText = "Nombre de la Tienda";
            dgvVentas.Columns["Número de Orden"].HeaderText = "Número de Orden";
            dgvVentas.Columns["Fecha Orden"].HeaderText = "Fecha de la Orden";
            dgvVentas.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvVentas.Columns["Condiciones de Pago"].HeaderText = "Condiciones de Pago";
            dgvVentas.Columns["Título de Venta"].HeaderText = "Título de Venta";
        }

        private void ConfigurarColumnas()
        {
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvVentas.Columns.Count);

            foreach (DataGridViewColumn col in dgvVentas.Columns)
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

            dgvVentas.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvVentas.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvVentas.Columns.Count)
                    dgvVentas.Columns.Insert(posicion, columna);
                else
                    dgvVentas.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvVentas.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvVentas.RowHeadersVisible ? dgvVentas.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvVentas.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            ConfigurarColumnas();
        }

        private void FormVentas_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarVenta())
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchValue) || searchValue == "Buscar por Tienda, Orden, Título...")
                {
                    string query = @"
                        SELECT 
                            s.stor_id AS 'ID Tienda',
                            st.stor_name AS 'Nombre Tienda',
                            s.ord_num AS 'Número de Orden',
                            s.ord_date AS 'Fecha Orden',
                            s.qty AS 'Cantidad',
                            s.payterms AS 'Condiciones de Pago',
                            t.title AS 'Título de Venta'
                        FROM sales s
                        INNER JOIN stores st ON s.stor_id = st.stor_id
                        INNER JOIN titles t ON s.title_id = t.title_id";

                    ds = datos.consulta(query);
                }
                else
                {
                    string query = @"
                        SELECT 
                            s.stor_id AS 'ID Tienda',
                            st.stor_name AS 'Nombre Tienda',
                            s.ord_num AS 'Número de Orden',
                            s.ord_date AS 'Fecha Orden',
                            s.qty AS 'Cantidad',
                            s.payterms AS 'Condiciones de Pago',
                            t.title AS 'Título de Venta'
                        FROM sales s
                        INNER JOIN stores st ON s.stor_id = st.stor_id
                        INNER JOIN titles t ON s.title_id = t.title_id
                        WHERE 
                            (st.stor_name LIKE @searchValue
                            OR s.ord_num LIKE @searchValue
                            OR s.stor_id LIKE @searchValue
                            OR t.title LIKE @searchValue
                            OR s.ord_date LIKE @searchValue
                            OR CAST(s.qty AS VARCHAR) LIKE @searchValue
                            OR s.payterms LIKE @searchValue)";

                    SqlParameter[] parametros = new SqlParameter[] {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);
                }

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvVentas.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    AgregarColumnasPersonalizadas();
                }
                else
                {
                    dgvVentas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnasPersonalizadas()
        {
            if (!dgvVentas.Columns.Contains("Editar"))
            {
                DataGridViewImageColumn lapizColumn = new DataGridViewImageColumn
                {
                    Name = "Editar",
                    HeaderText = "",
                    Image = Properties.Resources.lapiz,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 30
                };
                dgvVentas.Columns.Insert(0, lapizColumn);
            }

            if (!dgvVentas.Columns.Contains("Eliminar"))
            {
                DataGridViewImageColumn eliminarColumn = new DataGridViewImageColumn
                {
                    Name = "Eliminar",
                    HeaderText = "",
                    Image = Properties.Resources.mdi__garbage,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 30
                };
                dgvVentas.Columns.Add(eliminarColumn);
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvVentas.Columns[e.ColumnIndex].Name;
                var row = dgvVentas.Rows[e.RowIndex];

                string ordNum = row.Cells["Número de Orden"]?.Value?.ToString();
                string storName = row.Cells["Nombre Tienda"]?.Value?.ToString();
                string title = row.Cells["Título de Venta"]?.Value?.ToString();
                string ordDate = row.Cells["Fecha Orden"]?.Value?.ToString();
                string qty = row.Cells["Cantidad"]?.Value?.ToString();
                string payTerms = row.Cells["Condiciones de Pago"]?.Value?.ToString();

                if (columnName == "Eliminar")
                {
                    var parametrosYValores = new Dictionary<string, object>
            {
                { "Número de Orden", ordNum },
                { "Nombre de la Tienda", storName },
                { "Título de Venta", title },
                { "Fecha de la Orden", ordDate },
                { "Cantidad", qty },
                { "Condiciones de Pago", payTerms }
            };

                    bool confirmado = Utils.confirmarEliminacion(parametrosYValores);

                    if (confirmado)
                    {
                        EliminarVenta(ordNum);
                    }
                }
                else if (columnName == "Editar")
                {
                    EditarVenta(ordNum);
                }
            }
        }

        private void EliminarVenta(string ordNum)
        {
            try
            {
                string query = "DELETE FROM sales WHERE ord_num = @ordNum";
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@ordNum", ordNum)
                };

                bool exito = datos.ejecutarABC(query, parametros);

                if (exito)
                {
                    MessageBox.Show("Venta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarVenta(string ordNum)
        {
            using (var editarForm = new FormAgregarVenta(ordNum))
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