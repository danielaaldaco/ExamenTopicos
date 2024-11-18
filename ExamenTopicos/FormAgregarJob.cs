using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExamenTopicos
{
    public partial class FormAgregarJob : Form
    {
        Datos Datos = new Datos();
        public FormAgregarJob()
        {
            InitializeComponent();
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            this.AcceptButton = btnAceptar;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\b]$"))
            {
                e.Handled = true;
                return;
            }

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

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider2.SetError(txtDescripcion, "Por favor, ingresa la descripción");
            }
            else
            {
                errorProvider2.SetError(txtDescripcion, string.Empty);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(errorProvider2.GetError(txtDescripcion)))
            {
                if (MessageBox.Show("¿Los datos son correctos?", "Sistema",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string descripcion = txtDescripcion.Text.Trim();
                    descripcion = Regex.Replace(descripcion, @"\s+", " ");
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    descripcion = textInfo.ToTitleCase(descripcion.ToLower());

                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        MessageBox.Show("La descripción no puede estar vacía después de limpiar los espacios.",
                            "Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    bool j = Datos.ejecutarABC(
                        "INSERT INTO jobs(job_desc, min_lvl, max_lvl) " +
                        "VALUES('" + descripcion.Replace("'", "''") + "', " + (int)nudMin.Value + ", " + (int)nudMax.Value + ")");
                    if (j == true)
                    {
                        MessageBox.Show("Datos Agregados Correctamente", "Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        txtDescripcion.Clear();
                        nudMin.Value = 10;
                        nudMax.Value = 15;
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar los datos", "Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos obligatorios",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
