using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAutores : Form
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30; // Ancho fijo para la columna de acción

        public FormAutores()
        {
            InitializeComponent();
            ActualizarGrid();

            // Ajustar las columnas dinámicas al redimensionar el formulario
            this.Resize += FormAutores_Resize;

            // Asociar el evento de clic en las celdas
            this.dgvAutores.CellContentClick += dgvAutores_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged; // Asegurar que el evento esté asociado
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

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    dgvAutores.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    dgvAutores.DataSource = null;
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

            foreach (DataGridViewColumn col in dgvAutores.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                    col.ReadOnly = false; // Asegurarse de que no sea de solo lectura
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

                if (posicion >= 0 && posicion <= dgvAutores.Columns.Count)
                    dgvAutores.Columns.Insert(posicion, columna);
                else
                    dgvAutores.Columns.Add(columna);
            }
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Validar que se selecciona una fila y columna válidas
            {
                string columnName = dgvAutores.Columns[e.ColumnIndex].Name; // Nombre de la columna clickeada
                var row = dgvAutores.Rows[e.RowIndex];
                string auId = row.Cells["ID Autor"]?.Value?.ToString(); // Obtiene el ID del autor

                if (string.IsNullOrWhiteSpace(auId))
                {
                    MessageBox.Show("No se pudo obtener la información del registro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "Editar") // Si se presionó el ícono de "Editar"
                {
                    // Obtener los valores necesarios
                    string auLname = row.Cells["Apellido"]?.Value?.ToString();
                    string auFname = row.Cells["Nombre"]?.Value?.ToString();
                    string phone = row.Cells["Teléfono"]?.Value?.ToString();
                    string address = row.Cells["Dirección"]?.Value?.ToString();
                    string city = row.Cells["Ciudad"]?.Value?.ToString();
                    string state = row.Cells["Estado"]?.Value?.ToString();
                    string zip = row.Cells["Código Postal"]?.Value?.ToString();
                    bool contract = Convert.ToBoolean(row.Cells["Contrato"]?.Value);

                    // Abrir el formulario de edición
                    using (var editarForm = new FormAgregarAutores("Editar", auId, auLname, auFname, phone, address, city, state, zip, contract))
                    {
                        if (editarForm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarGrid(); // Refrescar la tabla
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
                        zip LIKE @searchValue";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvAutores.DataSource = ds.Tables[0];
                    ConfigurarColumnas();
                }
                else
                {
                    dgvAutores.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
