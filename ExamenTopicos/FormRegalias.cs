using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormRegalias : Form
    {
        public FormRegalias()
        {
            InitializeComponent();
        }

        private void dgvRegalias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormRegalias_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            FormAgregarRegalias formAgregarRegalias = new FormAgregarRegalias();
            formAgregarRegalias.Show();
        }
    }
}
