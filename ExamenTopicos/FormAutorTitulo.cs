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
    public partial class FormAutorTitulo : Form
    {
        DataSet ds;
        Datos datos = new Datos();


        public FormAutorTitulo()
        {
            InitializeComponent();
        }

        private void dgvAutoresTitulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarAT formAgregarAT = new FormAgregarAT();
            formAgregarAT.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormEditarAT formEditarAT = new FormEditarAT();
            formEditarAT.Show();
        }
    }
}
