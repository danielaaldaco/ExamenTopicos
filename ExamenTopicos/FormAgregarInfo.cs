using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarInfo : MetroForm
    {
        private string operacion;
        private string pubId;
        private Datos datos = new Datos();
        private byte[] logoActual;

        public FormAgregarInfo(string pubId = null)
        {
            InitializeComponent();
            this.pubId = pubId;
            operacion = string.IsNullOrEmpty(pubId) ? "Agregar" : "Editar";
            ConfigurarFormulario();

            if (operacion == "Agregar")
            {
                CargarEditorialesSinInfo();
            }
            else
            {
                CargarDatosEditorial();
            }

            txtDetalles.Focus();
        }

        private void ConfigurarFormulario()
        {
            if (operacion == "Editar")
            {
                this.Text = "Editar Información Editorial";
                btnAceptar.Text = "Actualizar";
                cmbEditorial.Enabled = false;
            }
            else
            {
                this.Text = "Agregar Información Editorial";
                btnAceptar.Text = "Guardar";
                cmbEditorial.Enabled = true;
            }
        }

        private void CargarEditorialesSinInfo()
        {
            string query = @"
                SELECT pub_id, pub_name
                FROM publishers
                WHERE pub_id NOT IN (SELECT pub_id FROM pub_info)";
            DataSet ds = datos.consulta(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                cmbEditorial.DataSource = ds.Tables[0];
                cmbEditorial.DisplayMember = "pub_name";
                cmbEditorial.ValueMember = "pub_id";
                cmbEditorial.SelectedIndex = -1;

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Todas las editoriales ya tienen información registrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void CargarDatosEditorial()
        {
            string query = @"
        SELECT pu.pub_name, p.pr_info, p.logo 
        FROM pub_info p
        INNER JOIN publishers pu ON p.pub_id = pu.pub_id
        WHERE p.pub_id = @pubId";
            SqlParameter[] parametros = { new SqlParameter("@pubId", pubId) };
            DataSet ds = datos.consulta(query, parametros);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if (row["pr_info"] != DBNull.Value)
                {
                    string info = row["pr_info"].ToString();
                    string[] partes = info.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    txtDetalles.Text = partes.Length > 0 ? partes[0] : info;
                }

                if (row["logo"] != DBNull.Value)
                {
                    logoActual = (byte[])row["logo"];
                    using (MemoryStream ms = new MemoryStream(logoActual))
                    {
                        picBox.Image = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información de la editorial seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void btnImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Seleccionar imagen"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    picBox.Image = Image.FromFile(filePath);
                    logoActual = File.ReadAllBytes(filePath);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                string query;
                SqlParameter[] parametros;

                if (operacion == "Agregar")
                {
                    query = @"
                        INSERT INTO pub_info (pub_id, pr_info, logo)
                        VALUES (@pubId, @prInfo, @logo)";
                    parametros = new SqlParameter[]
                    {
                        new SqlParameter("@pubId", cmbEditorial.SelectedValue.ToString()),
                        new SqlParameter("@prInfo", txtDetalles.Text.Trim()),
                        new SqlParameter("@logo", (object)logoActual ?? DBNull.Value)
                    };
                }
                else
                {
                    query = @"
                        UPDATE pub_info
                        SET pr_info = @prInfo,
                            logo = @logo
                        WHERE pub_id = @pubId";
                    parametros = new SqlParameter[]
                    {
                        new SqlParameter("@pubId", pubId),
                        new SqlParameter("@prInfo", txtDetalles.Text.Trim()),
                        new SqlParameter("@logo", (object)logoActual ?? DBNull.Value)
                    };
                }

                bool resultado = datos.ejecutarABC(query, parametros);

                if (resultado)
                {
                    MessageBox.Show($"Información {(operacion == "Agregar" ? "agregada" : "actualizada")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la información. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (operacion == "Agregar" && cmbEditorial.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una editorial antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDetalles.Text) || txtDetalles.Text.Length > 200)
            {
                MessageBox.Show("La información es obligatoria y no debe exceder los 200 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
