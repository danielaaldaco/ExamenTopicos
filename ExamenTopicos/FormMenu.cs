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
            if (user.Rol == UserRole.GerenteVentas || user.Rol == UserRole.Administrador)
            {
                FormJobs formAgregarJob = new FormJobs();
                formAgregarJob.Show();
            }
            else
            {
                mostrarNoAcceso("Gerente o administrador");
            }
        }

        private void mostrarNoAcceso(string puestos)
        {
            MessageBox.Show("Solamente se puede accedeor como " + puestos);
        }
    }
}
