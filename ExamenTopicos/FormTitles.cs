using System;
using System.Data;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormTitles : Form
    {
        private readonly Datos datos = new Datos();
        private UserRole role;

        public FormTitles(UserRole role)
        {
            this.role = role;
            InitializeComponent();
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            try
            {
                DataSet ds = Utils.TablaConEliminar(
                    "Title_id", "Id_titulo",
                    "Title", "titulo",
                    "Type", "Tipo",
                    "Pub_id", "Id_pub",
                    "Price", "Precio",
                    "Advance", "Anticipo",
                    "Royalty", "Regalias",
                    "Ytd_sales", "Ventas",
                    "Notes", "Notas",
                    "Pubdate", "Fecha pub",
                    "Titles"
                );

                if (ds != null)
                {
                    dgvTitles.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddEditTitle())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid();
                }
            }
        }

        private void editarTituloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTitles.SelectedRows.Count > 0)
            {
                var row = dgvTitles.SelectedRows[0];
                string id = row.Cells["Id_Titulo"].Value.ToString();

                using (var form = new FormAddEditTitle(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = txtBuscar.Text.Trim();
                DataSet ds = datos.consulta($"SELECT * FROM titles WHERE title LIKE '%{search}%' OR title_id LIKE '%{search}%'");
                dgvTitles.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> master
