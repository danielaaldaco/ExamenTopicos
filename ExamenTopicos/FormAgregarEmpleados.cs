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
        private int contador = 1;
        bool bandera = false;


        public FormAgregarEmpleados()
        {
            InitializeComponent();


            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadPuestos();
            LoadEditorial();
        }

        public FormAgregarEmpleados(string empId, string nombre, string inicial, string apellido,
     string jobId, int jobLvl, string pubId, DateTime hireDate)
        {
            InitializeComponent();

            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadPuestos();
            LoadEditorial();

            this.Text = "Editar Empleado";

            lblID.Text = empId;
            lblID.Enabled = false;
            txtNombre.Text = nombre;
            mskInicialSNombre.Text = inicial;
            txtApellido.Text = apellido;

            if (cmbPuesto.DataSource != null)
            {
                cmbPuesto.SelectedValue = jobId;
            }

            nudNivel.Value = jobLvl;

            if (cmbEditorial.DataSource != null)
            {
                cmbEditorial.SelectedValue = pubId;
            }

            dtpFecha.Value = hireDate;
            bandera = true;
        }





        private void FormAgregarEmpleados_Load(object sender, EventArgs e)
        {
            String nuevoId = GenerarNuevoID();
            lblID.Text = nuevoId;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string selectedEditorialId = cmbEditorial.SelectedValue.ToString();
            string selectedPuestosId = cmbPuesto.SelectedValue.ToString();

            if (MessageBox.Show("¿Los datos son correctos?", "Sistema",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (bandera == true)
                    {
                        bool j = datos.ejecutarABC("Update UPDATE employee SET " +
                            "fname = '" + txtNombre.Text + "', " +
                            "minit = '" + mskInicialSNombre.Text + "', " +
                            "lname = '" + txtApellido.Text + "', " +
                            "job_id = " + selectedPuestosId + ", " +
                            "job_lvl = " + (int)nudNivel.Value + ", " +
                            "pub_id = '" + selectedEditorialId + "', " +
                            "hire_date = '" + dtpFecha.Value.ToShortDateString() + "' " +
                            "WHERE emp_id = '" + lblID.Text + "'");
                        if (j == true)
                        {
                            MessageBox.Show("Datos Actualizados", "Sistema", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Sistema", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        bool resultado = datos.ejecutarABC(
                        "INSERT INTO employee(emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date) " +
                        "VALUES('" + lblID.Text + "','" + txtNombre.Text + "','" + mskInicialSNombre.Text + "','" +
                        txtApellido.Text + "'," + selectedPuestosId + "," + (int)nudNivel.Value + ",'" + selectedEditorialId + "','" +
                        dtpFecha.Value.ToShortDateString() + "')");

                        if (resultado)
                        {
                            MessageBox.Show("Datos Agregados Correctamente", "Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCampos();
                            String nuevoId = GenerarNuevoID();
                            lblID.Text = nuevoId;
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar los datos", "Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            lblID.Text = "";
            txtNombre.Clear();
            mskInicialSNombre.Clear();
            txtApellido.Clear();
            cmbPuesto.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;
            nudNivel.Value = 10;
            dtpFecha.Value = DateTime.Now;
        }

        private void LoadPuestos()
        {
            DataSet ds = datos.consulta("SELECT job_id, job_desc FROM jobs");
            if (ds != null && ds.Tables.Count > 0)
            {
                cmbPuesto.DataSource = ds.Tables[0];
                cmbPuesto.DisplayMember = "job_desc";
                cmbPuesto.ValueMember = "job_id";
                cmbPuesto.SelectedIndex = -1;
            }
        }

        private void LoadEditorial()
        {
            DataSet ds = datos.consulta("SELECT pub_id, pub_name FROM publishers");
            if (ds != null && ds.Tables.Count > 0)
            {
                cmbEditorial.DataSource = ds.Tables[0];
                cmbEditorial.DisplayMember = "pub_name";
                cmbEditorial.ValueMember = "pub_id";
                cmbEditorial.SelectedIndex = -1;


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private string GenerarNuevoID()
        {
            const string sufijo = "M";
            Random random = new Random();

            char letra1 = (char)random.Next('A', 'Z' + 1);
            char letra2 = (char)random.Next('A', 'Z' + 1);
            char letra3 = (char)random.Next('A', 'Z' + 1);
            string prefijo = $"{letra1}{letra2}{letra3}";

            int primerDigito = random.Next(1, 10);

            int siguientesDigitos = random.Next(0, 1000);

            string numero = $"{primerDigito}{siguientesDigitos.ToString("D4")}";

            string nuevoID = $"{prefijo}{numero}{sufijo}";
            return nuevoID;
        }

        private void cmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cmbPuesto.SelectedIndex != -1)
                {
                    string selectedJobId = cmbPuesto.SelectedValue.ToString();

                    string query = "SELECT min_lvl FROM jobs WHERE job_id = @job_id";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
            new SqlParameter("@job_id", SqlDbType.SmallInt) { Value = selectedJobId }
                    };
                    DataSet ds = datos.consulta(query, parametros);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        int jobLevel = Convert.ToInt32(ds.Tables[0].Rows[0]["min_lvl"]);

                        nudNivel.Value = jobLevel;
                    }
                    else
                    {
                        nudNivel.Value = 10;
                    }
                }
            


        }
    }
}








    

