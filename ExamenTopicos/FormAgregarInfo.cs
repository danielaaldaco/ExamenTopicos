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

        public FormAgregarInfo(string operacion, string pubId = null, string informacion = null, byte[] logo = null)
        {
            InitializeComponent();

            this.operacion = operacion;
            this.pubId = pubId;
            this.logoActual = logo;

            ConfigurarFormulario();

            if (operacion == "Agregar")
            {
                CargarEditorialesSinInfo(); // Cargar solo las editoriales sin detalles
            }
            else if (operacion == "Editar")
            {
                ConfigurarCamposEditar(informacion, logo);
            }
        }

        private void ConfigurarFormulario()
        {
            if (operacion == "Editar")
            {
                this.Text = "Editar Información Editorial";
                btnAceptar.Text = "Actualizar";
                cmbEditorial.Enabled = false; // No permitir cambiar la editorial al editar
            }
            else
            {
                this.Text = "Agregar Información Editorial";
                btnAceptar.Text = "Guardar";
                cmbEditorial.Enabled = true;
            }
        }

        private void ConfigurarCamposEditar(string informacion, byte[] logo)
        {
            // Cargar información existente en los campos
            cmbEditorial.Items.Add(pubId); // Agregar la editorial actual al ComboBox
            cmbEditorial.SelectedIndex = 0;
            txtDetalles.Text = informacion;

            // Mostrar la imagen actual en el PictureBox si existe
            if (logo != null)
            {
                using (MemoryStream ms = new MemoryStream(logo))
                {
                    picBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void CargarEditorialesSinInfo()
        {
            try
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
                    cmbEditorial.SelectedIndex = -1; // Sin selección inicial

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Todas las editoriales ya tienen información registrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar editoriales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Seleccionar imagen"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Mostrar la imagen en el PictureBox
                picBox.Image = Image.FromFile(filePath);

                // Convertir la imagen a un arreglo de bytes
                logoActual = File.ReadAllBytes(filePath);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string query;

                // Validar que se haya seleccionado una editorial al agregar
                if (operacion == "Agregar" && cmbEditorial.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una editorial antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (operacion == "Agregar")
                {
                    query = @"
                        INSERT INTO pub_info (pub_id, pr_info, logo)
                        VALUES (@pub_id, @pr_info, @logo)";
                }
                else // Editar
                {
                    query = @"
                        UPDATE pub_info
                        SET pr_info = @pr_info,
                            logo = @logo
                        WHERE pub_id = @pub_id";
                }

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@pub_id", operacion == "Agregar" ? cmbEditorial.SelectedValue.ToString() : pubId),
                    new SqlParameter("@pr_info", txtDetalles.Text.Trim()),
                    new SqlParameter("@logo", logoActual ?? (object)DBNull.Value)
                };

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
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
