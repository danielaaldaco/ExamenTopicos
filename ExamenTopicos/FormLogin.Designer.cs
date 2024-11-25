namespace ExamenTopicos
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

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
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 29);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(15, 12);
            label3.Name = "label3";
            label3.Size = new Size(358, 356);
            label3.TabIndex = 7;
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Image = Properties.Resources.icons8_user_100;
            label1.Location = new Point(97, 22);
            label1.Name = "label1";
            label1.Size = new Size(203, 173);
            label1.TabIndex = 8;
            // 
            // lblUsuario
            // 
            lblUsuario.BackColor = Color.White;
            lblUsuario.Image = Properties.Resources.icons8_user_24;
            lblUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            lblUsuario.Location = new Point(32, 195);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(100, 20);
            lblUsuario.TabIndex = 9;
            lblUsuario.Text = "Usuario:";
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(138, 195);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(179, 23);
            txtUsuario.TabIndex = 10;
            // 
            // lblContrasena
            // 
            lblContrasena.BackColor = Color.White;
            lblContrasena.Image = Properties.Resources.icons8_password_30;
            lblContrasena.ImageAlign = ContentAlignment.MiddleLeft;
            lblContrasena.Location = new Point(33, 238);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(102, 35);
            lblContrasena.TabIndex = 11;
            lblContrasena.Text = "Contraseña:";
            lblContrasena.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(138, 245);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(179, 23);
            txtContrasena.TabIndex = 12;
            // 
            // btnLogin
            // 
            btnLogin.FlatAppearance.BorderColor = Color.White;
            btnLogin.Location = new Point(45, 303);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(311, 30);
            btnLogin.TabIndex = 13;
            btnLogin.Text = "Iniciar Sesión";
            // 
            // FormLogin
            // 
            BackgroundImage = Properties.Resources.libros;
            ClientSize = new Size(392, 377);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label2;
        private Label label3;
        private Label label1;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnLogin;
    }
}
