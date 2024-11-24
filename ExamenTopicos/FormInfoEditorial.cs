using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormInfoEditorial : Form
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30; // Ancho fijo para la columna de acción

        public FormInfoEditorial()
        {
            InitializeComponent();
            ActualizarGrid();

            // Ajustar las columnas dinámicas al redimensionar el formulario
            this.Resize += FormInfoEditorial_Resize;

            // Asociar eventos
            this.dgvInfoEdi.CellContentClick += dgvInfoEdi_CellContentClick;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged; // Evento para la barra de búsqueda
        }

        private void ActualizarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.pub_id AS 'ID Editorial',
                        p.logo AS 'Logo',
                        p.pr_info AS 'Información'
                    FROM pub_info p";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvInfoEdi.DataSource = ds.Tables[0];
                    dgvInfoEdi.ClearSelection(); // Quita la selección predeterminada
                    dgvInfoEdi.CurrentCell = null; // Evita que una celda esté seleccionada
                    ConfigurarColumnas();
                }
                else
                {
                    dgvInfoEdi.DataSource = null;
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

            // Ajustar las demás columnas
            foreach (DataGridViewColumn col in dgvInfoEdi.Columns)
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

            dgvInfoEdi.RowTemplate.Height = 100; // Ajustar el alto de las filas para mostrar las imágenes correctamente
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvInfoEdi.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion <= dgvInfoEdi.Columns.Count)
                    dgvInfoEdi.Columns.Insert(posicion, columna);
                else
                    dgvInfoEdi.Columns.Add(columna);
            }
        }

        private void FormInfoEditorial_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void dgvInfoEdi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Validar que se selecciona una fila y columna válidas
            {
                string columnName = dgvInfoEdi.Columns[e.ColumnIndex].Name; // Nombre de la columna clickeada
                var row = dgvInfoEdi.Rows[e.RowIndex];

                if (columnName == "Editar") // Si se presionó el ícono de "Editar"
                {
                    string pubId = row.Cells["ID Editorial"]?.Value?.ToString();
                    string informacion = row.Cells["Información"]?.Value?.ToString();
                    byte[] logo = row.Cells["Logo"].Value as byte[];

                    using (var editarForm = new FormAgregarInfo("Editar", pubId, informacion, logo))
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
                        p.pub_id AS 'ID Editorial',
                        p.logo AS 'Logo',
                        p.pr_info AS 'Información'
                    FROM pub_info p
                    WHERE 
                        p.pub_id LIKE @searchValue OR
                        p.pr_info LIKE @searchValue";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvInfoEdi.DataSource = ds.Tables[0];
                    dgvInfoEdi.ClearSelection(); // Quita la selección predeterminada
                    dgvInfoEdi.CurrentCell = null; // Evita que una celda esté seleccionada
                    ConfigurarColumnas();
                }
                else
                {
                    dgvInfoEdi.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia de FormAgregarInfo
            var agregarForm = new FormAgregarInfo("Agregar");

            // Si el formulario se cerró automáticamente por falta de editoriales, no continuar
            if (!agregarForm.IsHandleCreated)
            {
                return; // Salir del evento sin hacer nada
            }

            // Mostrar el formulario si hay editoriales disponibles
            if (agregarForm.ShowDialog() == DialogResult.OK)
            {
                ActualizarGrid(); // Refrescar la tabla después de agregar
            }
        }

    }
}
