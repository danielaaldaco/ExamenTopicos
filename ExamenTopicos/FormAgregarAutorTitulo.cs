using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarAutorTitulo : MetroForm
    {
        Datos datos = new Datos();

        public FormAgregarAutorTitulo()
        {
            InitializeComponent();

            // Configurar eventos para validaciones
            txtAutorId.KeyPress += txtAutorId_KeyPress;
            txtTituloId.KeyPress += txtTituloId_KeyPress;

            txtAutorId.TextChanged += txtAutorId_TextChanged;
            txtTituloId.TextChanged += txtTituloId_TextChanged;

            this.AcceptButton = btnAceptar;
        }

        // Validar entrada progresiva para AutorId (XXX-XX-XXXX)
        private void txtAutorId_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string currentText = tb.Text;

            // Permitir solo dígitos y retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                MostrarErrorTemporal(txtAutorId, "Solo se permiten dígitos.");
                e.Handled = true;
                return;
            }

            // Limitar la longitud total
            if (currentText.Length >= 11 && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }

            // Agregar guiones automáticamente en las posiciones correctas
            if (char.IsDigit(e.KeyChar))
            {
                if (currentText.Length == 3 || currentText.Length == 6)
                {
                    tb.Text += "-";
                    tb.SelectionStart = tb.Text.Length; // Mover el cursor al final
                }
            }
        }

        // Validar entrada progresiva para TituloId (XX1234)
        private void txtTituloId_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string currentText = tb.Text;

            // Permitir solo letras, números y retroceso
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z0-9\b]$"))
            {
                MostrarErrorTemporal(txtTituloId, "Solo se permiten letras y números.");
                e.Handled = true;
                return;
            }

            // Transformar automáticamente a mayúsculas si es una letra
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }

            // Validar longitud total y formato progresivo
            if (currentText.Length >= 6 && e.KeyChar != '\b') // Máximo 6 caracteres (XX1234)
            {
                e.Handled = true;
                return;
            }

            // Validar formato progresivo
            if (currentText.Length < 2 && char.IsDigit(e.KeyChar)) // Las dos primeras deben ser letras
            {
                MostrarErrorTemporal(txtTituloId, "El formato debe comenzar con dos letras.");
                e.Handled = true;
                return;
            }

            if (currentText.Length >= 2 && !char.IsDigit(e.KeyChar)) // Las siguientes deben ser dígitos
            {
                MostrarErrorTemporal(txtTituloId, "Solo se permiten números después de las letras.");
                e.Handled = true;
            }
        }

        // Validar progresivamente AutorId (mostrar/ocultar la "X")
        private void txtAutorId_TextChanged(object sender, EventArgs e)
        {
            string autorId = txtAutorId.Text.Trim();

            if (Regex.IsMatch(autorId, @"^\d{3}-\d{2}-\d{4}$") || Regex.IsMatch(autorId, @"^\d{0,3}(-\d{0,2})?(-\d{0,4})?$"))
            {
                errorProvider.SetError(txtAutorId, string.Empty); // Quitar error
            }
            else
            {
                MostrarErrorTemporal(txtAutorId, "El ID del Autor debe tener el formato XXX-XX-XXXX.");
            }
        }

        // Validar progresivamente TituloId (mostrar/ocultar la "X")
        private void txtTituloId_TextChanged(object sender, EventArgs e)
        {
            string tituloId = txtTituloId.Text.Trim();

            // Verificar si el formato es válido hasta ese momento
            if (Regex.IsMatch(tituloId, @"^[A-Z]{0,2}\d{0,4}$")) // Progresivo: XX1234
            {
                errorProvider.SetError(txtTituloId, string.Empty); // Quitar error
            }
            else
            {
                MostrarErrorTemporal(txtTituloId, "El ID del Título debe tener el formato XX1234.");
            }
        }

        // Mostrar errores temporales
        private void MostrarErrorTemporal(Control control, string mensaje)
        {
            errorProvider.SetError(control, mensaje);
        }

        // Botón Aceptar: insertar datos en la tabla titleauthor
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(errorProvider.GetError(txtAutorId)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtTituloId)))
            {
                string autorId = txtAutorId.Text.Trim();
                string tituloId = txtTituloId.Text.Trim();

                try
                {
                    // Validar existencia del Autor en la tabla authors
                    DataSet dsAutor = datos.consulta($"SELECT * FROM authors WHERE au_id = '{autorId}'");
                    if (dsAutor == null || dsAutor.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("El ID del Autor no existe en la tabla de autores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar existencia del Título en la tabla titles
                    DataSet dsTitulo = datos.consulta($"SELECT * FROM titles WHERE title_id = '{tituloId}'");
                    if (dsTitulo == null || dsTitulo.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("El ID del Título no existe en la tabla de títulos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar duplicados
                    DataSet dsDuplicados = datos.consulta(
                        $"SELECT * FROM titleauthor WHERE au_id = '{autorId}' AND title_id = '{tituloId}'"
                    );
                    if (dsDuplicados != null && dsDuplicados.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Ya existe un registro con el mismo Autor ID y Título ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insertar el registro
                    bool resultado = datos.ejecutarABC(
                        "INSERT INTO titleauthor (au_id, title_id, au_ord, royaltyper) " +
                        $"VALUES ('{autorId.Replace("'", "''")}', '{tituloId.Replace("'", "''")}', {nudOrden.Value}, {nudRegalia.Value})");

                    if (resultado)
                    {
                        MessageBox.Show("Datos agregados correctamente.", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtAutorId.Clear();
                        txtTituloId.Clear();
                        nudOrden.Value = 1;
                        nudRegalia.Value = 10;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Corrija los errores antes de continuar.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
