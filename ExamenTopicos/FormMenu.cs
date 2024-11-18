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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            FormJobs puestos = new FormJobs(UserRole.Administrador);
            puestos.Show();
        }
    }
}
