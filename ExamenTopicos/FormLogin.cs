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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string consultaSQL = $@"
                SELECT u.NombrePersona, u.Usuario, r.NombreRol 
                FROM Usuarios u
                INNER JOIN Roles r ON u.Rol = r.RolID
                WHERE u.Usuario = '{nombreUsuario}' AND u.Contraseña = '{contrasena}'";

            DataSet resultado = datos.consulta(consultaSQL);

            if (resultado != null && resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
            {
                string nombrePersona = resultado.Tables[0].Rows[0]["NombrePersona"].ToString();
                string nombreRol = resultado.Tables[0].Rows[0]["NombreRol"].ToString();
                string usuario = resultado.Tables[0].Rows[0]["Usuario"].ToString();

                if (Enum.TryParse(nombreRol, out UserRole userRole))
                {
                    UsuarioLogueado = new Usuario(usuario, userRole, nombrePersona);

                    MessageBox.Show($"¡Bienvenido, {nombrePersona}! Tu rol es: {nombreRol}", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Rol no reconocido. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}