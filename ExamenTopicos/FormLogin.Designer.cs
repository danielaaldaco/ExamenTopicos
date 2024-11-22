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
            lblUsuario = new Label();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.Image = Properties.Resources.icons8_user_24;
            lblUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            lblUsuario.Location = new Point(12, 150);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(100, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContrasena
            // 
            lblContrasena.Image = Properties.Resources.icons8_password_30;
            lblContrasena.ImageAlign = ContentAlignment.MiddleLeft;
            lblContrasena.Location = new Point(13, 193);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(102, 35);
            lblContrasena.TabIndex = 2;
            lblContrasena.Text = "Contraseña:";
            lblContrasena.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(118, 150);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(179, 23);
            txtUsuario.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(118, 200);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(179, 23);
            txtContrasena.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(25, 258);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(311, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.Image = Properties.Resources.icons8_user_100;
            label1.Location = new Point(108, 22);
            label1.Name = "label1";
            label1.Size = new Size(139, 106);
            label1.TabIndex = 5;
            // 
            // FormLogin
            // 
            ClientSize = new Size(354, 312);
            Controls.Add(label1);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}
