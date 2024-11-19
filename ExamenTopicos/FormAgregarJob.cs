using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarJob : Form
    {
        Datos Datos = new Datos();

        public FormAgregarJob()
        {
            InitializeComponent();
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            txtDescripcion.Validating += txtDescripcion_Validating;
            this.AcceptButton = btnAceptar;
        }

        // Validar entrada de texto en tiempo real
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y retroceso
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\b]$"))
            {
                e.Handled = true;
                return;
            }

            // Prevenir espacios consecutivos
            if (char.IsWhiteSpace(e.KeyChar))
            {
                TextBox tb = sender as TextBox;
                int selectionStart = tb.SelectionStart;
                if (selectionStart > 0 && char.IsWhiteSpace(tb.Text[selectionStart - 1]))
                {
                    e.Handled = true;
                }
            }
        }

        // Validar descripción antes de aceptar
        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider2.SetError(txtDescripcion, "Por favor, ingresa la descripción.");
                e.Cancel = true;
            }
            else
            {
                errorProvider2.SetError(txtDescripcion, string.Empty);
            }
        }

        // Botón Aceptar: lógica principal para guardar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar si hay errores en la descripción
            if (string.IsNullOrEmpty(errorProvider2.GetError(txtDescripcion)))
            {
                // Confirmar si los datos son correctos
                if (MessageBox.Show("¿Los datos son correctos?", "Sistema",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // Limpiar y transformar la descripción
                    string descripcion = txtDescripcion.Text.Trim();
                    descripcion = Regex.Replace(descripcion, @"\s+", " ");
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    descripcion = textInfo.ToTitleCase(descripcion.ToLower());

                    // Validar que no quede vacía después de limpiar
                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        MessageBox.Show("La descripción no puede estar vacía después de limpiar los espacios.",
                            "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar niveles mínimos y máximos
                    if (nudMin.Value < 10 || nudMax.Value > 250 || nudMin.Value > nudMax.Value)
                    {
                        MessageBox.Show("El nivel mínimo debe ser al menos 10, el nivel máximo no puede exceder 250, y el nivel mínimo no puede ser mayor al máximo.",
                            "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ejecutar inserción en la base de datos
                    try
                    {
                        bool resultado = Datos.ejecutarABC(
                            "INSERT INTO jobs(job_desc, min_lvl, max_lvl) " +
                            $"VALUES('{descripcion.Replace("'", "''")}', {nudMin.Value}, {nudMax.Value})");

                        if (resultado)
                        {
                            MessageBox.Show("Datos Agregados Correctamente", "Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpiar los campos
                            txtDescripcion.Clear();
                            nudMin.Value = 10;
                            nudMax.Value = 15;
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar los datos", "Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar los datos: {ex.Message}", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos obligatorios.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
