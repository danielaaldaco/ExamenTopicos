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

        public FormDescuentos(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();

            this.Resize += FormDescuentos_Resize;
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
                        d.discounttype AS 'Tipo de descuento',
                        s.stor_name AS 'Nombre',
                        d.lowqty AS 'Cantidad Minima',
                        d.highqty AS 'Cantidad Maxima',
                        d.discount AS 'Descuento'
                    FROM discounts d
                    LEFT JOIN stores s ON d.stor_id = s.stor_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    dgvDescuentos.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                }
                else
                {
                    dgvDescuentos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            dgvDescuentos.Columns["Tipo de descuento"].HeaderText = "Tipo de descuento";
            dgvDescuentos.Columns["Nombre"].HeaderText = "Nombre";
            dgvDescuentos.Columns["Cantidad Minima"].HeaderText = "Cantidad Minima";
            dgvDescuentos.Columns["Cantidad Maxima"].HeaderText = "Cantidad Maxima";
            dgvDescuentos.Columns["Descuento"].HeaderText = "Descuento";

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, dgvDescuentos.Columns.Count);
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

                dgvDescuentos.Columns.Insert(posicion, columna);
            }
        }

        private void dgvDescuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvDescuentos.Columns[e.ColumnIndex].Name;
                var row = dgvDescuentos.Rows[e.RowIndex];
                string discountType = row.Cells["Tipo de descuento"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(discountType))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Eliminar")
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
                            string deleteQuery = @"
                                DELETE FROM discounts
                                WHERE discounttype = @discountType";

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
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (columnName == "Editar")
                {
                    using (var editarForm = new FormAgregarDescuentos(Operacion.Editar, discountType))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid();
                        }
                    }
                }
            }
        }

        private void FormDescuentos_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnasGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAgregarEmpleados(Operacion.Agregar))
            {
                if (agregarForm.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                    AjustarAnchoVentana();
                }
            }
        }
    }
}
