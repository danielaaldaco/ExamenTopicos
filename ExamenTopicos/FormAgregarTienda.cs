using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ExamenTopicos.Utils;
using MetroFramework.Forms;


namespace ExamenTopicos
{
    public partial class FormAgregarTienda : MetroForm
    {
        private Datos datos = new Datos();
        private string storId;

        public FormAgregarTienda(string id = null)
        {
            InitializeComponent();
            storId = id;

            if (string.IsNullOrEmpty(storId))
            {
                Text = "Agregar Tienda";
                btnAceptar.Text = "Agregar";
                GenerarIdAleatorio();
                txtNombre.Focus();
            }
            else
            {
                Text = "Editar Tienda";
                btnAceptar.Text = "Actualizar";
                CargarDatosTienda();
            }
            txtIdTienda.TabStop = false;
            ConfigurarRestricciones();
            AsignarEventos();
        }

        private void GenerarIdAleatorio()
        {
            Random random = new Random();
            int idNumerico = random.Next(1000, 10000);
            txtIdTienda.Text = idNumerico.ToString();
        }

        private void CargarDatosTienda()
        {
            string query = "SELECT * FROM stores WHERE stor_id = @storId";
            SqlParameter[] parametros = { new SqlParameter("@storId", storId) };
            DataSet ds = datos.consulta(query, parametros);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtIdTienda.Text = row["stor_id"].ToString();
                txtNombre.Text = row["stor_name"].ToString();
                txtDireccion.Text = row["stor_address"].ToString();
                txtCiudad.Text = row["city"].ToString();
                txtEstado.Text = row["state"].ToString();
                mskCP.Text = row["zip"].ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string query;
                    SqlParameter[] parametros;

                    if (string.IsNullOrEmpty(storId))
                    {
                        query = @"
                            INSERT INTO stores (stor_id, stor_name, stor_address, city, state, zip)
                            VALUES (@storId, @storName, @storAddress, @city, @state, @zip)";
                        parametros = CrearParametros();
                    }
                    else
                    {
                        query = @"
                            UPDATE stores 
                            SET stor_name = @storName, stor_address = @storAddress, city = @city, state = @state, zip = @zip
                            WHERE stor_id = @storId";
                        parametros = CrearParametros();
                    }

                    if (datos.ejecutarABC(query, parametros))
                    {
                        MessageBox.Show("Tienda guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private SqlParameter[] CrearParametros()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@storId", txtIdTienda.Text),
                new SqlParameter("@storName", txtNombre.Text),
                new SqlParameter("@storAddress", txtDireccion.Text),
                new SqlParameter("@city", txtCiudad.Text),
                new SqlParameter("@state", txtEstado.Text.ToUpper()),
                new SqlParameter("@zip", mskCP.Text)
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdTienda.Text) || txtIdTienda.Text.Length != 4)
            {
                MessageBox.Show("El ID de la tienda debe tener exactamente 4 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.Length > 40)
            {
                MessageBox.Show("El nombre de la tienda es obligatorio y no debe exceder los 40 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text) || txtDireccion.Text.Length > 40)
            {
                MessageBox.Show("La dirección de la tienda es obligatoria y no debe exceder los 40 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text) || txtCiudad.Text.Length > 20)
            {
                MessageBox.Show("La ciudad de la tienda es obligatoria y no debe exceder los 20 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text.Length != 2 || !EsSoloLetras(txtEstado.Text))
            {
                MessageBox.Show("El estado debe tener exactamente 2 letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(mskCP.Text) || mskCP.Text.Length != 5)
            {
                MessageBox.Show("El código postal es obligatorio y debe tener exactamente 5 dígitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool EsSoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c)) return false;
            }
            return true;
        }

        private void ConfigurarRestricciones()
        {
            txtEstado.CharacterCasing = CharacterCasing.Upper;
            txtEstado.MaxLength = 2;

            foreach (var control in Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        private void AsignarEventos()
        {
            txtNombre.TextChanged += agregarEvento;
            txtDireccion.TextChanged += agregarEvento;
            txtCiudad.TextChanged += agregarEvento;
            txtEstado.TextChanged += agregarEvento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}