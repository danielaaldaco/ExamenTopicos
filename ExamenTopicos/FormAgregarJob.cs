using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarJob : Form
    {
        Datos Datos = new Datos();
        public FormAgregarJob()
        {
            InitializeComponent();
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
                    // Escapar caracteres especiales
                    string safeDescripcion = txtDescripcion.Text.Replace("'", "''");

                    // Convertir a mayúsculas en la consulta SQL
                    bool j = Datos.ejecutarABC(
                        "INSERT INTO jobs(job_desc, min_lvl, max_lvl) " +
                        "VALUES( UPPER('" + safeDescripcion + "'), " + (int)nudMin.Value + ", " + (int)nudMax.Value + ")");
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
                        MessageBox.Show("Error", "Sistema", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos obligatorios",
                "Sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
