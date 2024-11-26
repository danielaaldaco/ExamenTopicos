using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAutorTitulo : MetroForm
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por ID, Autor, Título...";

        public FormAutorTitulo(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            activarPlaceholders(txtBuscar, placeholder);
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            eliminarToolStripMenuItem.Visible = false;
            dgvAutoresTitulos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvAutoresTitulos.ReadOnly = true;
                    break;
                case UserRole.Empleado:
                    dgvAutoresTitulos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;
                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    eliminarToolStripMenuItem.Visible = true;
                    dgvAutoresTitulos.ReadOnly = false;
                    break;
                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;
            }
        }

        private void ActualizarGrid(string searchValue = null)
        {
            try
            {
                string query;
                SqlParameter[] parametros = null;

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    query = @"
                        SELECT 
                            a.au_id AS 'ID Autor',
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title_id AS 'ID Título',
                            t.title AS 'Título',
                            ta.au_ord AS 'Orden',
                            ta.royaltyper AS 'Regalía (%)'
                        FROM 
                            titleauthor ta
                        INNER JOIN 
                            authors a ON ta.au_id = a.au_id
                        INNER JOIN 
                            titles t ON ta.title_id = t.title_id";
                }
                else
                {
                    query = @"
                        SELECT 
                            a.au_id AS 'ID Autor',
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                            t.title_id AS 'ID Título',
                            t.title AS 'Título',
                            ta.au_ord AS 'Orden',
                            ta.royaltyper AS 'Regalía (%)'
                        FROM 
                            titleauthor ta
                        INNER JOIN 
                            authors a ON ta.au_id = a.au_id
                        INNER JOIN 
                            titles t ON ta.title_id = t.title_id
                        WHERE 
                            a.au_lname + ' ' + a.au_fname LIKE @searchValue 
                            OR t.title LIKE @searchValue";
                    parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };
                }

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    AgregarColumnasPersonalizadas();
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
            emptyTable.Columns.Add("ID Autor");
            emptyTable.Columns.Add("Nombre Autor");
            emptyTable.Columns.Add("ID Título");
            emptyTable.Columns.Add("Título");
            emptyTable.Columns.Add("Orden");
            emptyTable.Columns.Add("Regalía (%)");
            dgvAutoresTitulos.DataSource = emptyTable;
            ConfigurarColumnasGrid();
            AgregarColumnasPersonalizadas();
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvAutoresTitulos.Columns.Contains("ID Autor"))
                dgvAutoresTitulos.Columns["ID Autor"].HeaderText = "ID Autor";
            if (dgvAutoresTitulos.Columns.Contains("Nombre Autor"))
                dgvAutoresTitulos.Columns["Nombre Autor"].HeaderText = "Autor";
            if (dgvAutoresTitulos.Columns.Contains("ID Título"))
                dgvAutoresTitulos.Columns["ID Título"].HeaderText = "ID Título";
            if (dgvAutoresTitulos.Columns.Contains("Título"))
                dgvAutoresTitulos.Columns["Título"].HeaderText = "Título";
            if (dgvAutoresTitulos.Columns.Contains("Orden"))
                dgvAutoresTitulos.Columns["Orden"].HeaderText = "Orden";
            if (dgvAutoresTitulos.Columns.Contains("Regalía (%)"))
                dgvAutoresTitulos.Columns["Regalía (%)"].HeaderText = "Regalía (%)";
        }

        private void AgregarColumnasPersonalizadas()
        {
            if (!dgvAutoresTitulos.Columns.Contains("Editar") && userRole != UserRole.Cliente && userRole != UserRole.Empleado)
            {
                var lapizColumn = new DataGridViewImageColumn
                {
                    Name = "Editar",
                    HeaderText = "",
                    Image = Properties.Resources.lapiz,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = ActionColumnWidth
                };
                dgvAutoresTitulos.Columns.Insert(0, lapizColumn);
            }

            if (!dgvAutoresTitulos.Columns.Contains("Eliminar") && userRole == UserRole.Administrador)
            {
                var eliminarColumn = new DataGridViewImageColumn
                {
                    Name = "Eliminar",
                    HeaderText = "",
                    Image = Properties.Resources.mdi__garbage,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = ActionColumnWidth
                };
                dgvAutoresTitulos.Columns.Add(eliminarColumn);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvAutoresTitulos.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvAutoresTitulos.RowHeadersVisible ? dgvAutoresTitulos.RowHeadersWidth : 0;
            int extraWidth = Width - dgvAutoresTitulos.ClientSize.Width;
            Width = totalColumnWidth + rowHeaderWidth + extraWidth + 20;
        }

        private void dgvAutoresTitulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvAutoresTitulos.Columns[e.ColumnIndex].Name;
                var row = dgvAutoresTitulos.Rows[e.RowIndex];
                string auId = row.Cells["ID Autor"]?.Value?.ToString();
                string titleId = row.Cells["ID Título"]?.Value?.ToString();

                if (columnName == "Eliminar")
                {
                    var parametrosYValores = new Dictionary<string, object>
                    {
                        { "ID Autor", auId },
                        { "ID Título", titleId },
                        { "Nombre Autor", row.Cells["Nombre Autor"]?.Value?.ToString() },
                        { "Título", row.Cells["Título"]?.Value?.ToString() },
                        { "Orden", row.Cells["Orden"]?.Value?.ToString() },
                        { "Regalía (%)", row.Cells["Regalía (%)"]?.Value?.ToString() }
                    };

                    bool confirmado = Utils.confirmarEliminacion(parametrosYValores);

                    if (confirmado)
                    {
                        EliminarRegistro(auId, titleId);
                    }
                }
                else if (columnName == "Editar")
                {
                    using (var editarForm = new FormAgregarAT(Operacion.Editar, auId, titleId))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                            ActualizarGrid();
                    }
                }
            }
        }


        private void EliminarRegistro(string auId, string titleId)
        {
            try
            {
                string deleteQuery = "DELETE FROM titleauthor WHERE au_id = @auId AND title_id = @titleId";
                SqlParameter[] parametros = {
                    new SqlParameter("@auId", auId),
                    new SqlParameter("@titleId", titleId)
                };

                if (datos.ejecutarABC(deleteQuery, parametros))
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarAT(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                    ActualizarGrid();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text.Trim();
                string query;

                if (placeholderActivo(txtBuscar.Text, placeholder))
                {
                    query = @"
                SELECT 
                    a.au_id AS 'ID Autor',
                    a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                    t.title_id AS 'ID Título',
                    t.title AS 'Título',
                    ta.au_ord AS 'Orden',
                    ta.royaltyper AS 'Regalía (%)'
                FROM 
                    titleauthor ta
                INNER JOIN 
                    authors a ON ta.au_id = a.au_id
                INNER JOIN 
                    titles t ON ta.title_id = t.title_id";
                }
                else
                {
                    query = @"
                SELECT 
                    a.au_id AS 'ID Autor',
                    a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
                    t.title_id AS 'ID Título',
                    t.title AS 'Título',
                    ta.au_ord AS 'Orden',
                    ta.royaltyper AS 'Regalía (%)'
                FROM 
                    titleauthor ta
                INNER JOIN 
                    authors a ON ta.au_id = a.au_id
                INNER JOIN 
                    titles t ON ta.title_id = t.title_id
                WHERE 
                    a.au_id LIKE @searchValue
                    OR a.au_lname LIKE @searchValue
                    OR a.au_fname LIKE @searchValue
                    OR t.title_id LIKE @searchValue
                    OR t.title LIKE @searchValue
                    OR CAST(ta.au_ord AS NVARCHAR) LIKE @searchValue
                    OR CAST(ta.royaltyper AS NVARCHAR) LIKE @searchValue";
                }

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvAutoresTitulos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    AgregarColumnasPersonalizadas();
                }
                else
                {
                    MostrarEncabezadoVacio();
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

        private void FormAutorTitulo_Load(object sender, EventArgs e)
        {

        }
    }
}