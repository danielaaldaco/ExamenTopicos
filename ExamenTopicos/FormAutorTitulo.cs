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
    }
}
