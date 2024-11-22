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
        private const int ActionColumnWidth = 30; // Ancho fijo para las columnas de acción

        public FormDescuentos(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
            ActualizarGrid();

            // Ajustar las columnas dinámicas al redimensionar el formulario
            this.Resize += FormDescuentos_Resize;

            // Asociar el evento de clic en las celdas
            this.dgvDescuentos.CellContentClick += dgvDescuentos_CellContentClick;
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
                        d.lowqty AS 'Cantidad Mínima',
                        d.highqty AS 'Cantidad Máxima',
                        d.discount AS 'Descuento'
                    FROM discounts d
                    LEFT JOIN stores s ON d.stor_id = s.stor_id";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    dgvDescuentos.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
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

        private void ConfigurarColumnas()
        {
            // Agregar columna de edición al principio
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);

            // Agregar columna de eliminación al final
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvDescuentos.Columns.Count);

            foreach (DataGridViewColumn col in dgvDescuentos.Columns)
            {
                if (col.Name == "Editar" || col.Name == "Eliminar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                    col.ReadOnly = false; // Asegurarse de que no sean de solo lectura
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Validar que se selecciona una fila y columna válidas
            {
                string columnName = dgvDescuentos.Columns[e.ColumnIndex].Name; // Nombre de la columna clickeada
                var row = dgvDescuentos.Rows[e.RowIndex];
                string discountType = row.Cells["Tipo de descuento"]?.Value?.ToString(); // Obtiene el tipo de descuento

                // Validar que el valor existe
                if (string.IsNullOrWhiteSpace(discountType))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar") // Si se presionó el ícono de "Editar"
                {
                    // Obtener los valores necesarios
                    string storId = row.Cells["Nombre"]?.Value?.ToString();
                    int lowQty = row.Cells["Cantidad Mínima"]?.Value == DBNull.Value
                        ? 0
                        : Convert.ToInt32(row.Cells["Cantidad Mínima"]?.Value);
                    int highQty = row.Cells["Cantidad Máxima"]?.Value == DBNull.Value
                        ? 0
                        : Convert.ToInt32(row.Cells["Cantidad Máxima"]?.Value);
                    decimal discount = row.Cells["Descuento"]?.Value == DBNull.Value
                        ? 0
                        : Convert.ToDecimal(row.Cells["Descuento"]?.Value);

                    // Abrir el formulario de edición
                    using (var editarForm = new FormAgregarDescuentos(Operacion.Editar, discountType, storId, lowQty, highQty, discount))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid(); // Refrescar la tabla
                        }
                    }
                }
                else if (columnName == "Eliminar") // Si se presionó el ícono de "Eliminar"
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
                                ActualizarGrid(); // Refrescar la tabla
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
            }
        }
    }
}
