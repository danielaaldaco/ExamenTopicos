using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAgregarAutores : Form
    {
        private string operacion;
        private string autorId;
        private Datos datos = new Datos();
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormAgregarAutores(string operacion, string autorId = null, string apellidos = "", string nombre = "",
                                   string telefono = "", string direccion = "", string ciudad = "",
                                   string estado = "", string codigoPostal = "", bool contrato = true)
        {
            InitializeComponent();

            this.operacion = operacion;
            this.autorId = autorId;

            ConfigurarFormulario();

            if (operacion == "Agregar")
            {
                txtIdAutor.Text = GenerarIdAutor(); // Generar ID único
                txtIdAutor.ReadOnly = true;
            }
            else if (operacion == "Editar")
            {
                // Cargar datos en los campos
                txtIdAutor.Text = autorId;
                txtApellido.Text = apellidos;
                txtNombre.Text = nombre;

                // Si el teléfono tiene formato, extraer solo los dígitos
                txtTelefono.Text = ExtraerSoloDigitos(telefono);

                txtDireccion.Text = direccion;
                txtCiudad.Text = ciudad;
                txtEstado.Text = estado;
                txtCP.Text = codigoPostal;

                // Seleccionar el radio button correspondiente
                rBtnSi.Checked = contrato;
                rBtnNo.Checked = !contrato;

                // Bloquear la edición de nombre y apellido
                txtIdAutor.ReadOnly = true; // ID siempre de solo lectura
                txtApellido.ReadOnly = true;
                txtNombre.ReadOnly = true;
            }
        }

        private void ConfigurarFormulario()
        {
            if (operacion == "Editar")
            {
                this.Text = "Editar Autor";
                btnAceptar.Text = "Actualizar";
            }
            else
            {
                this.Text = "Agregar Autor";
                btnAceptar.Text = "Agregar";
            }
        }

        private string GenerarIdAutor()
        {
            // Generar un ID único según el formato requerido
            Random random = new Random();
            return $"{random.Next(100, 999)}-{random.Next(10, 99)}-{random.Next(1000, 9999)}";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidarCampos()
        {
            bool esValido = true;

            // Limpiar mensajes de error anteriores
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider.SetError(txtApellido, "El campo 'Apellidos' es obligatorio.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "El campo 'Nombre' es obligatorio.");
                esValido = false;
            }

            if (!Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                errorProvider.SetError(txtTelefono, "El campo 'Teléfono' debe contener exactamente 10 dígitos.");
                esValido = false;
            }

            if (!Regex.IsMatch(txtEstado.Text, @"^[A-Za-z]{2}$"))
            {
                errorProvider.SetError(txtEstado, "El campo 'Estado' debe contener exactamente 2 caracteres.");
                esValido = false;
            }

            if (!Regex.IsMatch(txtCP.Text, @"^\d{5}$"))
            {
                errorProvider.SetError(txtCP, "El campo 'Código Postal' debe contener exactamente 5 dígitos.");
                esValido = false;
            }

            return esValido;
        }

        private string FormatearTelefono(string telefono)
        {
            // Convertir teléfono de 10 dígitos al formato 000 000-0000
            return Regex.Replace(telefono, @"(\d{3})(\d{3})(\d{4})", "$1 $2-$3");
        }

        private string ExtraerSoloDigitos(string telefono)
        {
            // Extraer solo los dígitos del teléfono
            return Regex.Replace(telefono, @"[^\d]", "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_2(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (!ValidarCampos())
                return;

            try
            {
                // Formatear el teléfono al formato requerido
                string telefonoFormateado = FormatearTelefono(txtTelefono.Text.Trim());

                string query;
                SqlParameter[] parametros;

                if (operacion == "Agregar")
                {
                    query = @"
                        INSERT INTO authors (au_id, au_lname, au_fname, phone, address, city, state, zip, contract)
                        VALUES (@au_id, @au_lname, @au_fname, @phone, @address, @city, @state, @zip, @contract)";
                }
                else // Editar
                {
                    query = @"
                        UPDATE authors
                        SET phone = @phone,
                            address = @address,
                            city = @city,
                            state = @state,
                            zip = @zip,
                            contract = @contract
                        WHERE au_id = @au_id";
                }

                parametros = new SqlParameter[]
                {
                    new SqlParameter("@au_id", txtIdAutor.Text.Trim()),
                    new SqlParameter("@au_lname", txtApellido.Text.Trim()),
                    new SqlParameter("@au_fname", txtNombre.Text.Trim()),
                    new SqlParameter("@phone", telefonoFormateado),
                    new SqlParameter("@address", txtDireccion.Text.Trim()),
                    new SqlParameter("@city", txtCiudad.Text.Trim()),
                    new SqlParameter("@state", txtEstado.Text.Trim()),
                    new SqlParameter("@zip", txtCP.Text.Trim()),
                    new SqlParameter("@contract", rBtnSi.Checked ? 1 : 0)
                };

                bool resultado = datos.ejecutarABC(query, parametros);

                if (resultado)
                {
                    MessageBox.Show($"Autor {(operacion == "Agregar" ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
