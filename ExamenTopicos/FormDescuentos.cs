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
    public partial class FormDescuentos : Form
    {
        public FormDescuentos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarDescuentos descuentos = new FormAgregarDescuentos();
            descuentos.ShowDialog();
        }
    }
}
