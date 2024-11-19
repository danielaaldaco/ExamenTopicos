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
    public partial class FormAutores : Form
    {
        public FormAutores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarAutores formAgregarAutores = new FormAgregarAutores();
            formAgregarAutores.Show();
        }
    }
}
