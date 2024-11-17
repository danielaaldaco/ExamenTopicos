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
        public FormJobs()
        {
            InitializeComponent();
        }

        Datos datos = new Datos();

        private void ActualizarGrid()
        {
            DataSet ds;
            ds = datos.consulta("Select job_id, job_desc, min_lvl, max_lvl From jobs");
            if (ds != null)
            {
                dgvPuestos.DataSource = ds.Tables[0];
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
