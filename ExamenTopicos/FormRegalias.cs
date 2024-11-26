using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormRegalias : MetroForm
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();

        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por Autor, Título, Orden, Regalía...";
        private bool columnsConfigured = false;

        public FormRegalias(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            activarPlaceholders(txtBuscar, placeholder);
            ConfigurarAccesoPorRol();
            ConfigurarEventos();
            ActualizarGrid();
            AjustarAnchoVentana();
        }

        private void ConfigurarEventos()
        {
            this.Resize += FormRegalias_Resize;
            this.btnAgregar.Click += btnAgregar_Click;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormRegalias_Resize(object sender, EventArgs e)
        {
            AjustarAnchoVentana();
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvRegalias.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvRegalias.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    btnAgregar.Visible = true;
                    dgvRegalias.ReadOnly = true;
                    break;

                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvRegalias.ReadOnly = false;
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
                            ta.au_id AS 'ID Autor',
                            ta.title_id AS 'ID Título',
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
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
                            ta.au_id AS 'ID Autor', 
                            ta.title_id AS 'ID Título', 
                            a.au_lname + ' ' + a.au_fname AS 'Nombre Autor',
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
                            OR t.title LIKE @searchValue
                            OR CAST(ta.au_ord AS NVARCHAR) LIKE @searchValue
                            OR CAST(ta.royaltyper AS NVARCHAR) LIKE @searchValue";
                    parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };
                }

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvRegalias.DataSource = ds.Tables[0];
                    dgvRegalias.AllowUserToAddRows = false;
                    dgvRegalias.RowHeadersVisible = false;
                    ConfigurarColumnasGrid();

                    if (!columnsConfigured)
                    {
                        AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
                        if (userRole == UserRole.Administrador)
                        AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvRegalias.Columns.Count);
                        columnsConfigured = true;
                    }

                    dgvRegalias.ClearSelection();
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
            emptyTable.Columns.Add("Nombre Autor");
            emptyTable.Columns.Add("Título");
            emptyTable.Columns.Add("Orden");
            emptyTable.Columns.Add("Regalía (%)");
            dgvRegalias.DataSource = emptyTable;
            ConfigurarColumnasGrid();

            if (!columnsConfigured)
            {
                AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
                AgregarColumnaIcono("Eliminar", Properties.Resources.garbage, ActionColumnWidth, dgvRegalias.Columns.Count);
                columnsConfigured = true;
            }
        }

        private void ConfigurarColumnasGrid()
        {
            foreach (DataGridViewColumn col in dgvRegalias.Columns)
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

            dgvRegalias.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvRegalias.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion <= dgvRegalias.Columns.Count)
                    dgvRegalias.Columns.Insert(posicion, columna);
                else
                    dgvRegalias.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvRegalias.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvRegalias.RowHeadersVisible ? dgvRegalias.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvRegalias.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;
        }

        private void dgvRegalias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvRegalias.Columns[e.ColumnIndex].Name;
                var row = dgvRegalias.Rows[e.RowIndex];

                string auId = row.Cells["ID Autor"]?.Value?.ToString();
                string titleId = row.Cells["ID Título"]?.Value?.ToString();
                string nombreAutor = row.Cells["Nombre Autor"]?.Value?.ToString();
                string titulo = row.Cells["Título"]?.Value?.ToString();
                string orden = row.Cells["Orden"]?.Value?.ToString();
                string regalía = row.Cells["Regalía (%)"]?.Value?.ToString();

                if (columnName == "Eliminar")
                {
                    var parametrosYValores = new Dictionary<string, object>
                    {
                        { "ID Autor", auId },
                        { "ID Título", titleId },
                        { "Nombre Autor", nombreAutor },
                        { "Título", titulo },
                        { "Orden", orden },
                        { "Regalía (%)", regalía }
                    };

                    bool confirmado = Utils.confirmarEliminacion(parametrosYValores);

                    if (confirmado)
                    {
                        EliminarRegalia(auId, titleId);
                    }
                }
                else if (columnName == "Editar")
                {
                    EditarRegalia(auId, titleId);
                }
            }
        }


        private void EliminarRegalia(string auId, string titleId)
        {
            try
            {
                string query = @"
                    DELETE FROM titleauthor
                    WHERE au_id = @auId AND title_id = @titleId";
                SqlParameter[] parametros = {
                    new SqlParameter("@auId", auId),
                    new SqlParameter("@titleId", titleId)
                };

                if (datos.ejecutarABC(query, parametros))
                {
                    MessageBox.Show("Regalía eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la regalía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la regalía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarRegalia(string auId, string titleId)
        {
            using (var editarForm = new FormAgregarRegalias(Operacion.Editar, auId, titleId))
            {
                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarRegalias(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(searchValue) || searchValue == placeholder)
            {
                ActualizarGrid();
            }
            else
            {
                ActualizarGrid(searchValue);
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