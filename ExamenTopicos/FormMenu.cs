using System;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormMenu : Form
    {
        private Usuario user;

        public FormMenu(Usuario user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            FormJobs formAgregarJob = new FormJobs();
            formAgregarJob.Show();
        }
    }
}
