using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormDescuentos : Form
    {
        private DataSet ds;
        private UserRole userRole;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private const string placeholder = "Buscar por Tipo de descuento, Nombre, Cantidad...";

        public FormDescuentos(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();
            AjustarAnchoVentana();
            this.Resize += FormDescuentos_Resize;
            activarPlaceholders(txtBuscar, placeholder);
            this.Load += FormDescuentos_Load;
            this.PreviewKeyDown += FormDescuentos_PreviewKeyDown;
            this.dgvDescuentos.CellContentClick += dgvDescuentos_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormDescuentos_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void FormDescuentos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
            dgvDescuentos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvDescuentos.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    dgvDescuentos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvDescuentos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvDescuentos.ReadOnly = false;
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
                        d.discounttype AS 'Tipo de descuento',
                        s.stor_name AS 'Nombre',
                        d.lowqty AS 'Cantidad Mínima',
                        d.highqty AS 'Cantidad Máxima',
                        d.discount AS 'Descuento'
                    FROM discounts d
                    LEFT JOIN stores s ON d.stor_id = s.stor_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvDescuentos.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    crearHeader(dgvDescuentos,
                        "Tipo de descuento",
                        "Nombre",
                        "Cantidad Mínima",
                        "Cantidad Máxima",
                        "Descuento");
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
            if (dgvDescuentos.Columns.Contains("Editar"))
            {
                dgvDescuentos.Columns.Remove("Editar");
            }

            if (dgvDescuentos.Columns.Contains("Eliminar"))
            {
                dgvDescuentos.Columns.Remove("Eliminar");
            }

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvDescuentos.Columns.Count);

            foreach (DataGridViewColumn col in dgvDescuentos.Columns)
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

            dgvDescuentos.RowTemplate.Height = ActionColumnWidth;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvDescuentos.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion <= dgvDescuentos.Columns.Count)
                    dgvDescuentos.Columns.Insert(posicion, columna);
                else
                    dgvDescuentos.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvDescuentos.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvDescuentos.RowHeadersVisible ? dgvDescuentos.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvDescuentos.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            ConfigurarColumnas();
        }

        private void FormDescuentos_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarDescuentos(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void dgvDescuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvDescuentos.Columns[e.ColumnIndex].Name;
                var row = dgvDescuentos.Rows[e.RowIndex];
                string discountType = row.Cells["Tipo de descuento"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(discountType))
                {
                    crearHeader(dgvDescuentos,
                        "Tipo de descuento",
                        "Nombre",
                        "Cantidad Mínima",
                        "Cantidad Máxima",
                        "Descuento");
                    ConfigurarColumnas();
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar")
                {
                    string storName = row.Cells["Nombre"]?.Value?.ToString();
                    int lowQty = row.Cells["Cantidad Mínima"]?.Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["Cantidad Mínima"]?.Value);
                    int highQty = row.Cells["Cantidad Máxima"]?.Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["Cantidad Máxima"]?.Value);
                    decimal discount = row.Cells["Descuento"]?.Value == DBNull.Value ? 0 : Convert.ToDecimal(row.Cells["Descuento"]?.Value);

                    using (var editarForm = new FormAgregarDescuentos(Operacion.Editar, discountType, storName, lowQty, highQty, discount))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                        }
                    }
                }
                else if (columnName == "Eliminar")
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar el descuento de tipo: {discountType}?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            string deleteQuery = "DELETE FROM discounts WHERE discounttype = @discountType";

                            SqlParameter[] parametros = new SqlParameter[]
                            {
                                new SqlParameter("@discountType", discountType)
                            };

                            bool exito = datos.ejecutarABC(deleteQuery, parametros);

                            if (exito)
                            {
                                MessageBox.Show("Descuento eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarGrid();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el registro. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            d.discounttype AS 'Tipo de descuento',
                            s.stor_name AS 'Nombre',
                            d.lowqty AS 'Cantidad Mínima',
                            d.highqty AS 'Cantidad Máxima',
                            d.discount AS 'Descuento'
                        FROM discounts d
                        LEFT JOIN stores s ON d.stor_id = s.stor_id
                        WHERE 
                            d.discounttype LIKE @searchValue OR
                            s.stor_name LIKE @searchValue OR
                            CAST(d.lowqty AS NVARCHAR) LIKE @searchValue OR
                            CAST(d.highqty AS NVARCHAR) LIKE @searchValue OR
                            CAST(d.discount AS NVARCHAR) LIKE @searchValue";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@searchValue", $"%{searchValue}%")
                    };

                    ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvDescuentos.DataSource = ds.Tables[0];
                        ConfigurarColumnas();
                    }
                    else
                    {
                        crearHeader(dgvDescuentos,
                            "Tipo de descuento",
                            "Nombre",
                            "Cantidad Mínima",
                            "Cantidad Máxima",
                            "Descuento");
                        ConfigurarColumnas();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
