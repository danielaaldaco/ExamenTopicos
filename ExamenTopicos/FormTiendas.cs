using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormTiendas : MetroForm
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por Nombre, Ciudad, Estado...";

        public FormTiendas(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormTiendas_Resize;
            activarPlaceholders(txtBuscar, placeholder);
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvTiendas.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvTiendas.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    btnAgregar.Visible = true;
                    dgvTiendas.ReadOnly = true;
                    break;

                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvTiendas.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        stor_id AS 'ID Tienda',
                        stor_name AS 'Nombre Tienda',
                        stor_address AS 'Dirección',
                        city AS 'Ciudad',
                        state AS 'Estado',
                        zip AS 'Código Postal'
                    FROM stores";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvTiendas.DataSource = ds.Tables[0];
                    dgvTiendas.AllowUserToAddRows = false;
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();
                }
                else
                {
                    MostrarEncabezadoVacio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEncabezadoVacio()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("ID Tienda");
            emptyTable.Columns.Add("Nombre Tienda");
            emptyTable.Columns.Add("Dirección");
            emptyTable.Columns.Add("Ciudad");
            emptyTable.Columns.Add("Estado");
            emptyTable.Columns.Add("Código Postal");
            dgvTiendas.DataSource = emptyTable;
        }

        private void ConfigurarColumnasGrid()
        {
            dgvTiendas.Columns["ID Tienda"].HeaderText = "ID Tienda";
            dgvTiendas.Columns["Nombre Tienda"].HeaderText = "Nombre de la Tienda";
            dgvTiendas.Columns["Dirección"].HeaderText = "Dirección";
            dgvTiendas.Columns["Ciudad"].HeaderText = "Ciudad";
            dgvTiendas.Columns["Estado"].HeaderText = "Estado";
            dgvTiendas.Columns["Código Postal"].HeaderText = "Código Postal";
        }

        private void ConfigurarColumnas()
        {
            if (userRole != UserRole.Empleado)
            {
                AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            }

            if (userRole == UserRole.Administrador)
            {
                AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvTiendas.Columns.Count);
            }

            foreach (DataGridViewColumn col in dgvTiendas.Columns)
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

            dgvTiendas.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvTiendas.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvTiendas.Columns.Count)
                    dgvTiendas.Columns.Insert(posicion, columna);
                else
                    dgvTiendas.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvTiendas.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvTiendas.RowHeadersVisible ? dgvTiendas.RowHeadersWidth : 0;
            int extraWidth = Width - dgvTiendas.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            Width = newWidth + 20;
        }

        private void FormTiendas_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarTienda())
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
                if (placeholderActivo(searchValue, placeholder))
                {
                    ActualizarGrid();
                }
                else
                {
                    string query = @"
                        SELECT 
                            stor_id AS 'ID Tienda',
                            stor_name AS 'Nombre Tienda',
                            stor_address AS 'Dirección',
                            city AS 'Ciudad',
                            state AS 'Estado',
                            zip AS 'Código Postal'
                        FROM stores
                        WHERE 
                            (stor_id LIKE @searchValue)
                            OR (stor_name LIKE @searchValue)
                            OR (stor_address LIKE @searchValue)
                            OR (city LIKE @searchValue)
                            OR (state LIKE @searchValue)
                            OR (zip LIKE @searchValue)";

                    SqlParameter[] parametros = {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvTiendas.DataSource = ds.Tables[0];
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

        private void dgvTiendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvTiendas.Columns[e.ColumnIndex].Name;
                var row = dgvTiendas.Rows[e.RowIndex];

                string storId = row.Cells["ID Tienda"]?.Value?.ToString();
                string storName = row.Cells["Nombre Tienda"]?.Value?.ToString();

                if (columnName == "Eliminar")
                {
                    var parametrosYValores = new Dictionary<string, object>
                    {
                        { "ID Tienda", storId },
                        { "Nombre de la Tienda", storName }
                    };

                    bool confirmado = confirmarPedido(parametrosYValores);

                    if (confirmado)
                    {
                        EliminarTienda(storId);
                    }
                }
                else if (columnName == "Editar")
                {
                    EditarTienda(storId);
                }
            }
        }

        private void EliminarTienda(string storId)
        {
            try
            {
                string query = "DELETE FROM stores WHERE stor_id = @storId";
                SqlParameter[] parametros = {
                    new SqlParameter("@storId", storId)
                };

                if (datos.ejecutarABC(query, parametros))
                {
                    MessageBox.Show("Tienda eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la tienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la tienda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarTienda(string storId)
        {
            using (var editarForm = new FormAgregarTienda(storId))
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
