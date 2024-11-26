using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormCarrito : MetroForm
    {
        private DataTable carritoDataTable;
        private Datos datos = new Datos();

        public FormCarrito()
        {
            InitializeComponent();
            ConfigurarTablaCarrito();
            CargarDatosComboBox();
        }

        private void ConfigurarTablaCarrito()
        {
            carritoDataTable = new DataTable();

            // Definir columnas del DataTable
            DataColumn idTituloColumn = carritoDataTable.Columns.Add("ID Título", typeof(string));
            carritoDataTable.Columns.Add("Título", typeof(string));
            carritoDataTable.Columns.Add("Cantidad", typeof(int));

            // Configurar la columna "ID Título" como clave primaria
            carritoDataTable.PrimaryKey = new DataColumn[] { idTituloColumn };

            // Asignar el DataTable como fuente del DataGridView
            dgvCarrito.DataSource = carritoDataTable;
        }


        private void CargarDatosComboBox()
        {
            try
            {
                string queryTitulos = "SELECT title_id, title FROM titles";
                DataSet dsTitulos = datos.consulta(queryTitulos);

                if (dsTitulos != null && dsTitulos.Tables.Count > 0 && dsTitulos.Tables[0].Rows.Count > 0)
                {
                    cmbTitulo.DataSource = dsTitulos.Tables[0];
                    cmbTitulo.DisplayMember = "title";  // Mostrar el nombre del título
                    cmbTitulo.ValueMember = "title_id"; // Asociar el ID del título
                    cmbTitulo.SelectedIndex = -1;       // Ningún elemento seleccionado al inicio
                }
                else
                {
                    MessageBox.Show("No hay títulos disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los títulos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTerminarCompra_Click(object sender, EventArgs e)
        {
           
        }

        private Dictionary<string, object> CrearResumenPedido()
        {
            Dictionary<string, object> resumenPedido = new Dictionary<string, object>();
            resumenPedido.Add("Articulo", "   Cantidad");
            foreach (DataRow row in carritoDataTable.Rows)
            {
                string titulo = row["Título"].ToString();
                string cantidad = "   " + row["Cantidad"].ToString();
                resumenPedido.Add(titulo, cantidad);
            }

            return resumenPedido;
        }


        private void LimpiarCampos()
        {
            cmbTitulo.SelectedIndex = -1;
            txtCantidad.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Método para obtener los datos del carrito como una lista de diccionarios.
        /// </summary>
        /// <returns>Lista de diccionarios con los datos del carrito.</returns>
        public List<Dictionary<string, object>> ObtenerDatosCarrito()
        {
            var datosCarrito = new List<Dictionary<string, object>>();

            foreach (DataRow row in carritoDataTable.Rows)
            {
                datosCarrito.Add(new Dictionary<string, object>
                {
                    { "ID Título", row["ID Título"] },
                    { "Título", row["Título"] },
                    { "Cantidad", row["Cantidad"] }
                });
            }

            return datosCarrito;
        }

        private void btnAgregarCarrito_Click_1(object sender, EventArgs e)
        {
                try
                {
                    // Validar datos antes de agregar al carrito
                    if (cmbTitulo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor selecciona un título.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Por favor ingresa una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Obtener datos del título seleccionado
                    string titulo = cmbTitulo.Text;
                    string titleId = cmbTitulo.SelectedValue.ToString();

                    // Verificar si ya existe en el carrito
                    DataRow filaExistente = carritoDataTable.Rows.Find(titleId); // Buscar por la clave primaria
                    if (filaExistente != null)
                    {
                        // Si ya existe, sumar la cantidad
                        filaExistente["Cantidad"] = Convert.ToInt32(filaExistente["Cantidad"]) + cantidad;
                    }
                    else
                    {
                        // Agregar un nuevo pedido al carrito
                        DataRow newRow = carritoDataTable.NewRow();
                        newRow["ID Título"] = titleId;
                        newRow["Título"] = titulo;
                        newRow["Cantidad"] = cantidad;
                        carritoDataTable.Rows.Add(newRow);
                    }

                    // Limpiar campos después de agregar
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar al carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            private void btnTerminarCompra_Click_1(object sender, EventArgs e) {
            if (carritoDataTable.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agrega al menos un artículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parametrosYValores =  CrearResumenPedido();

            using (var formConfirmacion = new FormConfirmacion(parametrosYValores, "Resumen de compra"))
            {
                if (formConfirmacion.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
