using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormEditarV : MetroForm
    {
        private DataTable carritoDataTable;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;
        private string ordNum;
        private string storId;
        private string currentPayTerms; // Variable para almacenar el método de pago actual

        public FormEditarV(string ordNum, string storId)
        {
            InitializeComponent();
            this.ordNum = ordNum;
            this.storId = storId;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Mostrar el número de orden en lblOrden
            lblOrden.Text = "Orden: " + ordNum;

            ConfigurarTablaCarrito();
            ConfigurarDataGridView();
            CargarDatosComboBox(); // Cargar formas de pago
            CargarDatosOrden();    // Cargar el método de pago actual
            CargarDatosEnTabla();
        }

        private void ConfigurarTablaCarrito()
        {
            carritoDataTable = new DataTable();

            DataColumn idTituloColumn = carritoDataTable.Columns.Add("ID Título", typeof(string));
            carritoDataTable.Columns.Add("Título", typeof(string));
            carritoDataTable.Columns.Add("Cantidad", typeof(int));

            carritoDataTable.PrimaryKey = new DataColumn[] { idTituloColumn };

            dgvCarrito.DataSource = carritoDataTable;
        }

        private void ConfigurarDataGridView()
        {
            dgvCarrito.AutoGenerateColumns = false;
            dgvCarrito.RowHeadersVisible = false;

            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.ColumnHeaderMouseClick += (sender, e) =>
            {
                dgvCarrito.ClearSelection();
            };
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor;

            // Limpiar y configurar columnas
            dgvCarrito.Columns.Clear();

            // Agregar columna de edición
            AgregarColumnaIcono("Editar", Properties.Resources.lapiz, ActionColumnWidth, 0);

            // Agregar columnas de datos
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ID Título",
                HeaderText = "ID Título",
                Name = "ID Título",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Título",
                HeaderText = "Título",
                Name = "Título",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Agregar columna de eliminación
            AgregarColumnaIcono("Eliminar", Properties.Resources.mdi__garbage, ActionColumnWidth, dgvCarrito.Columns.Count);

            foreach (DataGridViewColumn col in dgvCarrito.Columns)
            {
                if (col.Name == "Editar" || col.Name == "Eliminar")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = ActionColumnWidth;
                }
            }

            dgvCarrito.RowTemplate.Height = ActionColumnWidth;

            dgvCarrito.CellContentClick += dgvCarrito_CellContentClick;
        }

        private void AgregarColumnaIcono(string nombre, Image imagen, int ancho, int posicion)
        {
            if (!dgvCarrito.Columns.Contains(nombre))
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

                if (posicion >= 0 && posicion <= dgvCarrito.Columns.Count)
                    dgvCarrito.Columns.Insert(posicion, columna);
                else
                    dgvCarrito.Columns.Add(columna);
            }
        }

        private void CargarDatosEnTabla()
        {
            try
            {
                // Consulta para obtener los detalles de la orden
                string query = @"SELECT s.title_id AS [ID Título], t.title AS [Título], s.qty AS [Cantidad]
                                 FROM sales s
                                 INNER JOIN titles t ON s.title_id = t.title_id
                                 WHERE s.ord_num = @ordNum AND s.stor_id = @storId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ordNum", ordNum),
                    new SqlParameter("@storId", storId)
                };

                DataSet ds = datos.consulta(query, parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    carritoDataTable = ds.Tables[0];
                    carritoDataTable.PrimaryKey = new DataColumn[] { carritoDataTable.Columns["ID Título"] };
                    dgvCarrito.DataSource = carritoDataTable;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el número de orden proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvCarrito.Columns[e.ColumnIndex].Name;
                var row = dgvCarrito.Rows[e.RowIndex];

                string titleId = row.Cells["ID Título"].Value.ToString();

                if (columnName == "Eliminar")
                {
                    DataRow dataRow = carritoDataTable.Rows.Find(titleId);
                    if (dataRow != null)
                    {
                        dataRow.Delete(); // Marcamos la fila como eliminada
                    }
                }
                else if (columnName == "Editar")
                {
                    DataRow dataRow = carritoDataTable.Rows.Find(titleId);
                    if (dataRow != null)
                    {
                        string currentCantidad = dataRow["Cantidad"].ToString();
                        // Puedes pasar un mensaje más largo aquí sin preocuparte
                        string input = PromptForInput("Ingrese la nueva cantidad para el título seleccionado:", "Editar Cantidad", currentCantidad);
                        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int nuevaCantidad) && nuevaCantidad > 0)
                        {
                            dataRow["Cantidad"] = nuevaCantidad;
                        }
                        else
                        {
                            MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private string PromptForInput(string text, string caption, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 250, // Aumentamos la altura para dar más espacio
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };

            // Configuración del Label con ajuste automático y espaciado correcto
            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(340, 0) // Ancho máximo y altura ajustable
            };

            // TextBox centrado y con espacio suficiente, colocado más abajo
            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = textLabel.Bottom + 30, // Espaciamos más debajo del Label
                Width = 340,
                Text = defaultValue
            };

            // Botón de confirmación estilizado y posicionado correctamente, más abajo
            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 280,
                Width = 80,
                Top = textBox.Bottom + 30, // Más espacio debajo del TextBox
                DialogResult = DialogResult.OK
            };

            // Botón de cancelación, alineado al lado izquierdo del botón de OK
            Button cancelButton = new Button()
            {
                Text = "Cancelar",
                Left = 180,
                Width = 80,
                Top = textBox.Bottom + 30, // Igual que el botón de OK
                DialogResult = DialogResult.Cancel
            };

            // Agregar controles al formulario
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelButton);

            // Configurar propiedades para aceptar o cancelar con teclado
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelButton;

            // Ajustar el tamaño del formulario dinámicamente según el contenido
            prompt.ClientSize = new Size(380, confirmation.Bottom + 20); // Más espacio dinámico al final

            // Mostrar el formulario y devolver el texto ingresado
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }


        private void btnTerminarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos los cambios realizados en el DataTable
                DataTable cambios = carritoDataTable.GetChanges();

                if (cambios == null && cmbPago.SelectedItem.ToString() == currentPayTerms)
                {
                    MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Procesamos las filas eliminadas
                DataTable deletedRowsTable = carritoDataTable.GetChanges(DataRowState.Deleted);
                if (deletedRowsTable != null)
                {
                    foreach (DataRow row in deletedRowsTable.Rows)
                    {
                        string titleId = row["ID Título", DataRowVersion.Original].ToString();

                        // Eliminamos el detalle de la venta en la base de datos
                        string deleteQuery = @"DELETE FROM sales
                                               WHERE ord_num = @ordNum AND title_id = @titleId AND stor_id = @storId";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@ordNum", ordNum),
                            new SqlParameter("@titleId", titleId),
                            new SqlParameter("@storId", storId)
                        };

                        datos.ejecutarABC(deleteQuery, parameters);
                    }
                }

                // Procesamos las filas modificadas
                DataTable modifiedRowsTable = carritoDataTable.GetChanges(DataRowState.Modified);
                if (modifiedRowsTable != null)
                {
                    foreach (DataRow row in modifiedRowsTable.Rows)
                    {
                        string titleId = row["ID Título"].ToString();
                        int cantidad = Convert.ToInt32(row["Cantidad"]);

                        // Actualizamos la cantidad en la base de datos
                        string updateQuery = @"UPDATE sales
                                               SET qty = @cantidad
                                               WHERE ord_num = @ordNum AND title_id = @titleId AND stor_id = @storId";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@cantidad", cantidad),
                            new SqlParameter("@ordNum", ordNum),
                            new SqlParameter("@titleId", titleId),
                            new SqlParameter("@storId", storId)
                        };

                        datos.ejecutarABC(updateQuery, parameters);
                    }
                }

                // Actualizar el método de pago en la base de datos si ha cambiado
                string newPayTerms = cmbPago.SelectedItem.ToString();

                if (newPayTerms != currentPayTerms)
                {
                    string updatePayTermsQuery = @"UPDATE sales SET payterms = @payterms WHERE ord_num = @ordNum AND stor_id = @storId";
                    SqlParameter[] payTermsParameters = new SqlParameter[]
                    {
                        new SqlParameter("@payterms", newPayTerms),
                        new SqlParameter("@ordNum", ordNum),
                        new SqlParameter("@storId", storId)
                    };

                    datos.ejecutarABC(updatePayTermsQuery, payTermsParameters);
                }

                // Aceptamos los cambios en el DataTable
                carritoDataTable.AcceptChanges();

                // Verificamos si quedan artículos en la orden
                string checkOrderQuery = @"SELECT COUNT(*) FROM sales WHERE ord_num = @ordNum AND stor_id = @storId";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
                    new SqlParameter("@ordNum", ordNum),
                    new SqlParameter("@storId", storId)
                };

                DataSet ds = datos.consulta(checkOrderQuery, checkParameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int itemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (itemCount == 0)
                    {
                        // Eliminamos la orden si no quedan artículos
                        string deleteOrderQuery = @"DELETE FROM sales WHERE ord_num = @ordNum AND stor_id = @storId";
                        datos.ejecutarABC(deleteOrderQuery, checkParameters);
                    }
                }

                MessageBox.Show("La orden ha sido actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cancelar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void CargarDatosComboBox()
        {
            try
            {
                // Agregar las formas de pago al ComboBox
                cmbPago.Items.Add("Contado");
                cmbPago.Items.Add("Crédito");
                cmbPago.Items.Add("Net 30");
                cmbPago.Items.Add("Net 60");
                cmbPago.Items.Add("SPEI");
                cmbPago.Items.Add("Tarjeta");

                // La selección actual se establecerá después de obtener el método de pago actual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las formas de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosOrden()
        {
            try
            {
                // Obtener el método de pago actual de la orden
                string query = @"SELECT TOP 1 payterms FROM sales WHERE ord_num = @ordNum AND stor_id = @storId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ordNum", ordNum),
                    new SqlParameter("@storId", storId)
                };

                DataSet ds = datos.consulta(query, parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    currentPayTerms = ds.Tables[0].Rows[0]["payterms"].ToString();

                    // Establecer el método de pago actual en el ComboBox
                    if (cmbPago.Items.Contains(currentPayTerms))
                    {
                        cmbPago.SelectedItem = currentPayTerms;
                    }
                    else
                    {
                        // Si el método de pago no está en la lista, agregarlo y seleccionarlo
                        cmbPago.Items.Add(currentPayTerms);
                        cmbPago.SelectedItem = currentPayTerms;
                    }
                }
                else
                {
                    // Si no se encuentra el método de pago, seleccionar el primer elemento
                    cmbPago.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
