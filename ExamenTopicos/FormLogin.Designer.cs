namespace ExamenTopicos
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnLogin;

        /// <summary>
        /// Limpia los recursos usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicializa los componentes del formulario.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(50, 50);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "Usuario:";

            // txtUsuario
            this.txtUsuario.Location = new System.Drawing.Point(150, 45);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 22);

            // lblContrasena
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(50, 100);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Text = "Contraseña:";

            // txtContrasena
            this.txtContrasena.Location = new System.Drawing.Point(150, 95);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(200, 22);
            this.txtContrasena.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(150, 150);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.Size = new System.Drawing.Size(200, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // FormLogin
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnLogin);
            this.Text = "Inicio de Sesión";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
