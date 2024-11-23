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
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
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
                    btnEliminar.Visible = true;
                    dgvVentas.ReadOnly = false;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    btnEliminar.Visible = true;
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

            this.Width = newWidth + this.Width - dgvVentas.Width + 20;

            ConfigurarColumnas();
        }

        private void FormVentas_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Implementación para agregar ventas
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Implementación para eliminar ventas
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Implementación para búsqueda dinámica
        }
    }
}