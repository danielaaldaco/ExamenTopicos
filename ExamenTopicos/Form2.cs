﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormCarrito : MetroForm
    {
        private DataTable carritoDataTable;
        private Datos datos = new Datos();
        private const int ActionColumnWidth = 30;

        public FormCarrito()
        {
            InitializeComponent();
            ConfigurarTablaCarrito();
            ConfigurarDataGridView();
            CargarDatosComboBox();
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

        private void CargarDatosComboBox()
        {
            try
            {
                string queryTitulos = "SELECT title_id, title FROM titles";
                DataSet dsTitulos = datos.consulta(queryTitulos);

                if (dsTitulos != null && dsTitulos.Tables.Count > 0 && dsTitulos.Tables[0].Rows.Count > 0)
                {
                    cmbTitulo.DataSource = dsTitulos.Tables[0];
                    cmbTitulo.DisplayMember = "title";
                    cmbTitulo.ValueMember = "title_id";
                    cmbTitulo.SelectedIndex = -1;
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
            try
            {
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

                string titulo = cmbTitulo.Text;
                string titleId = cmbTitulo.SelectedValue.ToString();

                DataRow filaExistente = carritoDataTable.Rows.Find(titleId);
                if (filaExistente != null)
                {
                    filaExistente["Cantidad"] = Convert.ToInt32(filaExistente["Cantidad"]) + cantidad;
                }
                else
                {
                    DataRow newRow = carritoDataTable.NewRow();
                    newRow["ID Título"] = titleId;
                    newRow["Título"] = titulo;
                    newRow["Cantidad"] = cantidad;
                    carritoDataTable.Rows.Add(newRow);
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar al carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminarCompra_Click(object sender, EventArgs e)
        {
            if (carritoDataTable.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agrega al menos un artículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parametrosYValores = CrearResumenPedido();

            using (var formConfirmacion = new FormConfirmacion(parametrosYValores, "Resumen de compra"))
            {
                if (formConfirmacion.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private Dictionary<string, object> CrearResumenPedido()
        {
            Dictionary<string, object> resumenPedido = new Dictionary<string, object>();
            resumenPedido.Add("Artículo", "   Cantidad");
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
                        carritoDataTable.Rows.Remove(dataRow);
                    }
                }
                else if (columnName == "Editar")
                {
                    DataRow dataRow = carritoDataTable.Rows.Find(titleId);
                    if (dataRow != null)
                    {
                        string currentCantidad = dataRow["Cantidad"].ToString();
                        string input = PromptForInput("Ingrese la nueva cantidad:", "Editar Cantidad", currentCantidad);
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
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            textBox.Text = defaultValue;
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
