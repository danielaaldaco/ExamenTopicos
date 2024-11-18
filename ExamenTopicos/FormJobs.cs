using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamenTopicos

{
    public partial class FormJobs : Form
    {
        DataSet ds;
        public FormJobs()
        {
            InitializeComponent();
        }

        Datos datos = new Datos();



        private void ActualizarGrid()
        {

            DataSet ds;
            ds = datos.consulta("SELECT job_id , job_desc , min_lvl, max_lvl FROM jobs");

            if (ds != null)
            {
                dgvPuestos.DataSource = ds.Tables[0];
                dgvPuestos.Columns["job_id"].HeaderText = "ID Puesto";
                dgvPuestos.Columns["job_desc"].HeaderText = "Descripción";
                dgvPuestos.Columns["min_lvl"].HeaderText = "Nivel Mínimo";
                dgvPuestos.Columns["max_lvl"].HeaderText = "Nivel Máximo";

            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Datos dt = new Datos();
            ds = dt.consulta("Select * from jobs where job_id like '"
                + txtBuscar.Text + "%' OR job_desc like '"
                + txtBuscar.Text + "%'");
            if (ds != null)
            {
                dgvPuestos.DataSource = ds.Tables[0];
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void FormJobs_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarJob agregar = new FormAgregarJob();
            agregar.Show();
        }
    }
}
