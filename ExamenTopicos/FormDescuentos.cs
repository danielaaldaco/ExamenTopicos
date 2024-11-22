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

        DataSet ds;
        UserRole userRole;
        Datos datos = new Datos();

        public FormDescuentos(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
        }

        private void ConfigurarAccesoPorRol()
        {

            switch (userRole)
            {
                case UserRole.Cliente:
                    dgvDescuentos.ReadOnly = true;
                    break;

                case UserRole.Empleado:
                    dgvDescuentos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvDescuentos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    //contextMenuStrip1.Items["eliminarToolStripMenuItem"].Visible = true;
                    dgvDescuentos.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private void ActualizarGrid()
        {
            ds = datos.consulta("SELECT discounttype, stor_name, lowqty, highqty, discount FROM discounts, stores");

            if (ds != null)
            {
                dgvDescuentos.DataSource = ds.Tables[0];

                dgvDescuentos.Columns["discounttype"].HeaderText = "Tipo de descuento";
                dgvDescuentos.Columns["stor_name"].HeaderText = "Nombre";
                dgvDescuentos.Columns["lowqty"].HeaderText = "Cantidad Minima";
                dgvDescuentos.Columns["highqty"].HeaderText = "Cantidad Maxima";
                dgvDescuentos.Columns["discount"].HeaderText = "Descuento";

                dgvDescuentos.Columns["stor_name"].ReadOnly = true;
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarDescuentos descuentos = new FormAgregarDescuentos();
            descuentos.ShowDialog();
        }

        private void FormDescuentos_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

            dgvDescuentos.EditMode = DataGridViewEditMode.EditOnEnter;

            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtBuscar.Text;

                string query = $@"
                    SELECT discounttype, stor_name, lowqty, highqty, discount FROM discounts, stores
                    WHERE CAST(discounttype AS VARCHAR) LIKE '%{searchValue}%' OR 
                          stor_name LIKE '%{searchValue}%'";
                ds = datos.consulta(query);

                if (ds != null)
                {
                    dgvDescuentos.DataSource = ds.Tables[0];
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
