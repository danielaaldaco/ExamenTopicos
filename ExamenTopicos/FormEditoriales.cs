using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormEditoriales : Form
    {
        private DataSet ds;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;

        public FormEditoriales(UserRole role)
        {
            InitializeComponent();
            ConfigurarAccesoPorRol(role);
            this.Resize += FormEditoriales_Resize;
            this.Load += FormEditoriales_Load; // Usar el evento Load para aplicar ajustes de tamaño
            this.btnAgregar.Visible = false;
        }

        private void FormEditoriales_Load(object sender, EventArgs e)
        {
            // Actualizar la tabla y ajustar el tamaño una vez que todo está listo
            ActualizarGrid();
            AjustarAnchoVentana();
            AjustarAlturaVentana();

            // Cambiar el tamaño de la ventana al valor deseado
            this.Height = 400; // Cambia esto al valor que necesites
        }


        private void ConfigurarAccesoPorRol(UserRole role)
        {
            btnAgregar.Visible = false;
            dgvEditoriales.ReadOnly = true;

            switch (role)
            {
                case UserRole.Empleado:
                case UserRole.GerenteVentas:
                case UserRole.Administrador:
                    btnAgregar.Visible = true;
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
                        pub_id AS 'ID Editorial',
                        pub_name AS 'Nombre',
                        city AS 'Ciudad',
                        state AS 'Estado',
                        country AS 'País'
                    FROM publishers";

                ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvEditoriales.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();
                }
                else
                {
                    dgvEditoriales.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvEditoriales.Columns.Contains("ID Editorial"))
                dgvEditoriales.Columns["ID Editorial"].HeaderText = "ID Editorial";

            if (dgvEditoriales.Columns.Contains("Nombre"))
                dgvEditoriales.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvEditoriales.Columns.Contains("Ciudad"))
                dgvEditoriales.Columns["Ciudad"].HeaderText = "Ciudad";

            if (dgvEditoriales.Columns.Contains("Estado"))
                dgvEditoriales.Columns["Estado"].HeaderText = "Estado";

            if (dgvEditoriales.Columns.Contains("País"))
                dgvEditoriales.Columns["País"].HeaderText = "País";

            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);
        }

        private void ConfigurarColumnas()
        {
            foreach (DataGridViewColumn col in dgvEditoriales.Columns)
            {
                if (col.Name == "Editar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 30;
                }
                else if (col.Name == "Nombre")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Ajusta al contenido mostrado
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Las demás columnas llenan el espacio restante
                }
            }
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvEditoriales.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion < dgvEditoriales.Columns.Count)
                    dgvEditoriales.Columns.Insert(posicion, columna);
                else
                    dgvEditoriales.Columns.Add(columna);
            }
        }

        private void AjustarAnchoVentana()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dgvEditoriales.Columns)
            {
                totalColumnWidth += col.Width;
            }

            int rowHeaderWidth = dgvEditoriales.RowHeadersVisible ? dgvEditoriales.RowHeadersWidth : 0;
            int extraWidth = this.Width - dgvEditoriales.ClientSize.Width;
            int newWidth = totalColumnWidth + rowHeaderWidth + extraWidth;

            this.Width = newWidth + 20;

            // Ajustar la altura
            AjustarAlturaVentana();

            ConfigurarColumnas();
        }

        private void AjustarAlturaVentana()
        {
            // Calcular el número de filas visibles, excluyendo la fila de "nueva entrada" si está habilitada
            int rowCount = dgvEditoriales.Rows.Count;
            if (dgvEditoriales.AllowUserToAddRows)
            {
                rowCount -= 1; // Excluir la fila de nueva entrada
            }

            // Calcular la altura total de las filas
            int rowHeight = rowCount * dgvEditoriales.RowTemplate.Height;

            // Obtener la altura del encabezado de las columnas
            int headerHeight = dgvEditoriales.ColumnHeadersHeight;

            // Calcular la altura total requerida para el DataGridView
            int totalDgvHeight = rowHeight + headerHeight;

            // Calcular la altura adicional del formulario (bordes, título, etc.)
            int extraHeight = this.Height - this.ClientSize.Height;

            // Calcular la altura total requerida para el formulario
            int totalHeight = totalDgvHeight + extraHeight;

            // Ajustar el formulario para no exceder la altura máxima (600 píxeles)
            if (totalHeight > 600)
            {
                this.Height = 600;
                dgvEditoriales.Height = 600 - extraHeight; // Ajustar el DataGridView para usar la barra de desplazamiento
            }
            else
            {
                this.Height = totalHeight; // Ajustar el formulario exactamente a las filas visibles
                dgvEditoriales.Height = totalDgvHeight; // Ajustar el DataGridView para que no haya espacios vacíos
            }
        }




        private void FormEditoriales_Resize(object sender, EventArgs e)
        {
            ConfigurarColumnas();
        }

        private void dgvEditoriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvEditoriales.Columns[e.ColumnIndex].Name;

                if (columnName == "Editar")
                {
                    string editorialId = dgvEditoriales.Rows[e.RowIndex].Cells["ID Editorial"].Value?.ToString();

                    if (!string.IsNullOrEmpty(editorialId))
                    {
                        using (var editarForm = new FormAddEditEditorial(Operacion.Editar, editorialId))
                        {
                            if (editarForm.ShowDialog() == DialogResult.OK)
                            {
                                ActualizarGrid();
                                AjustarAnchoVentana();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID de la editorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            ActualizarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new FormAddEditEditorial(Operacion.Agregar))
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
                string query = @"
                    SELECT 
                        pub_id AS 'ID Editorial',
                        pub_name AS 'Nombre',
                        city AS 'Ciudad',
                        state AS 'Estado',
                        country AS 'País'
                    FROM publishers
                    WHERE 
                        pub_name LIKE @searchValue OR 
                        pub_id LIKE @searchValue";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@searchValue", $"%{searchValue}%")
                };

                ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvEditoriales.DataSource = ds.Tables[0];
                    ConfigurarColumnasGrid();
                    ConfigurarColumnas();
                }
                else
                {
                    dgvEditoriales.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}