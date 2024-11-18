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
            MessageBox.Show("Botón 'Puestos' presionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
