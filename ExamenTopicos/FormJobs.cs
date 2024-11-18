using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamenTopicos

{
    public partial class FormJobs : Form
    {
        DataSet ds;
        int rol;
        public FormJobs()
        {
            InitializeComponent();
        }

        public FormJobs(int rol)
        {
            InitializeComponent();
            this.rol = rol;
            ConfigurarAccesoPorRol(rol);
        }

        private void ConfigurarAccesoPorRol(int rol)
        {
            switch (rol)
            {
                case 1:
                    btnAgregar.Visible = false;
                    contextMenuStrip1.Items["eliminarPuestoToolStripMenuItem"].Visible = false;
                    dgvPuestos.ReadOnly = true;
                    break;

                case 2:
                    contextMenuStrip1.Items["eliminarPuestoToolStripMenuItem"].Visible = false;
                    dgvPuestos.ReadOnly = true;
                    break;

                case 3:
                    contextMenuStrip1.Items["eliminarPuestoToolStripMenuItem"].Visible = false;
                    break;

                case 4:
                    break;


                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }


        Datos datos = new Datos();



        private void ActualizarGrid()
        {

            DataSet ds;
            ds = datos.consulta("SELECT job_id , job_desc , min_lvl, max_lvl FROM jobs");

            if (ds != null)
            {
                dgvPuestos.DataSource = ds.Tables[0];
                dgvPuestos.Columns["job_id"].HeaderText = "ID Puesto";
                dgvPuestos.Columns["job_desc"].HeaderText = "Descripción";
                dgvPuestos.Columns["min_lvl"].HeaderText = "Nivel Mínimo";
                dgvPuestos.Columns["max_lvl"].HeaderText = "Nivel Máximo";

            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Datos dt = new Datos();
            ds = dt.consulta("Select * from jobs where job_id like '"
                + txtBuscar.Text + "%' OR job_desc like '"
                + txtBuscar.Text + "%'");
            if (ds != null)
            {
                dgvPuestos.DataSource = ds.Tables[0];
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void FormJobs_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarJob agregar = new FormAgregarJob();
            agregar.Show();
            agregar.FormClosed += (s, args) => ActualizarGrid();
        }

        private void eliminarPuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(dgvPuestos[0,
                dgvPuestos.SelectedRows[0].Index].Value.ToString());
            if (MessageBox.Show("Deseas eliminar a " +
                dgvPuestos[1, dgvPuestos.SelectedRows[0].Index].Value.ToString(),
                "Sistema",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool s = datos.ejecutarABC("Delete from jobs Where job_id=" + x);
                if (s)
                {
                    MessageBox.Show("Registro eliminado", "Sistema", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ActualizarGrid();

                }
                else
                    MessageBox.Show("Error", "Sistema", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvPuestos_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPuestos.SelectedRows.Count > 0)
                {
                    var row = dgvPuestos.Rows[e.RowIndex];

                    int id = Convert.ToInt32(row.Cells[0].Value); // Columna de ID
                    string descripcion = row.Cells[1].Value?.ToString();
                    int minLvl = Convert.ToInt32(row.Cells[2].Value);
                    int maxLvl = Convert.ToInt32(row.Cells[3].Value);

                    // Mostrar mensaje de confirmación
                    var confirmResult = MessageBox.Show(
                        "¿Deseas guardar los siguientes cambios?\n" +
                        "- Descripción: {descripcion}\n" +
                        "- Nivel mínimo: {minLvl}\n" +
                        "- Nivel máximo: {maxLvl}",
                        "Confirmar Cambios",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        string consulta = $"UPDATE jobs SET job_desc = '{descripcion}', min_lvl = {minLvl}, max_lvl = {maxLvl} WHERE job_id = {id}";
                        bool resultado = datos.ejecutarABC(consulta);

                        if (resultado)
                        {
                            MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        ActualizarGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro para editar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
