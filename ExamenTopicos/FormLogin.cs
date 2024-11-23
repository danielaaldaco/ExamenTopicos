using System;
using System.Data;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormLogin : Form
    {
        Datos datos = new Datos();
        public Usuario UsuarioLogueado { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; // Permitir "Enter" para iniciar sesión
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Consulta original con interpolación
                string consultaSQL = $@"
                    SELECT u.NombrePersona, u.Usuario, r.NombreRol 
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.Rol = r.RolID
                    WHERE u.Usuario = '{nombreUsuario}' AND u.Contraseña = '{contrasena}'";

                // Ejecutar consulta
                DataSet resultado = datos.consulta(consultaSQL);

                // Verificar si hay resultados
                if (resultado != null && resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
                {
                    // Extraer datos del resultado
                    string nombrePersona = resultado.Tables[0].Rows[0]["NombrePersona"].ToString();
                    string nombreRol = resultado.Tables[0].Rows[0]["NombreRol"].ToString();
                    string usuario = resultado.Tables[0].Rows[0]["Usuario"].ToString();

                    // Normalizar el nombre del rol
                    nombreRol = NormalizarRol(nombreRol);

                    // Validar que el rol coincida con el enumerado
                    if (Enum.TryParse(nombreRol, true, out UserRole userRole))
                    {
                        UsuarioLogueado = new Usuario(usuario, userRole, nombrePersona);

                        MessageBox.Show($"¡Bienvenido, {nombrePersona}! Tu rol es: {nombreRol}", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Rol desconocido: {nombreRol}. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Si no hay resultados, mostrar error
                    MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                MessageBox.Show($"Ocurrió un error durante el inicio de sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Normaliza el nombre del rol para que coincida con los valores del enumerado.
        /// </summary>
        /// <param name="rol">Nombre del rol desde la base de datos.</param>
        /// <returns>Nombre del rol normalizado.</returns>
        private string NormalizarRol(string rol)
        {
            // Convertir el nombre del rol a un formato estándar
            return rol.Replace(" ", "").Replace("-", "").Replace("_", "");
        }

        private void btnMostrarOcultar_Click(object sender, EventArgs e)
        {
            // Alternar entre mostrar y ocultar contraseña
            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
        }
    }
}

