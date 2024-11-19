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

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            FormPublisher formEditorial = new FormPublisher();
            formEditorial.Show();

        }

        private void btnAutoresLibros_Click(object sender, EventArgs e)
        {
            FormAutorTitulo formAutorTitulo = new FormAutorTitulo();
            formAutorTitulo.Show();
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            FormDescuentos descuentos = new FormDescuentos();
            descuentos.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }
    }
}
