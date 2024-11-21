using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarEmpleados : Form
    {
        Datos datos = new Datos();

        public FormAgregarEmpleados()
        {
            InitializeComponent();
        }

        private void FormAgregarEmpleados_Load(object sender, EventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Los datos son correctos?", "Sistema",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    bool resultado = datos.ejecutarABC(
                    "INSERT INTO employes(emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date) " +
                    "VALUES('" + mskIdEmpleado.Text + "','" + txtNombre.Text + "','" + mskInicialSNombre.Text + "','" +
                    txtApellido.Text + "','" + cmbPuesto.Text + "','" + (int)nudNivel.Value + "','" + cmbEditorial.Text + "','" +
                    dtpFecha.Value.ToLongDateString + "')");

                    if (resultado)
                    {
                        MessageBox.Show("Datos Agregados Correctamente", "Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
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

        private void LimpiarCampos()
        {
            mskIdEmpleado.Clear();
            txtNombre.Clear();
            mskInicialSNombre.Clear();
            txtApellido.Clear();
            cmbPuesto.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;
            nudNivel.Value = 10;
            dtpFecha.Value = DateTime.Now;
        }

    }
}








    

