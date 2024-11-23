namespace ExamenTopicos
{
    partial class FormAddEditEditorial
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cboPais;  // ComboBox para el País
        private ComboBox cboEstado;  // ComboBox para el Estado
        private ComboBox cboEditorialId; // ComboBox para el ID de la Editorial (en lugar de TextBox)
        private TextBox txtNombre;  // TextBox para el Nombre de la Editorial
        private TextBox txtCiudad;  // TextBox para la Ciudad
        private Button btnAceptar;  // Botón Aceptar
        private Button btnCancelar;  // Botón Cancelar
        private Label lblEditorialId;  // Etiqueta Editorial ID
        private Label lblNombre;  // Etiqueta Nombre
        private Label lblCiudad;  // Etiqueta Ciudad
        private Label lblEstado;  // Etiqueta Estado
        private Label lblPais;  // Etiqueta País
        private ErrorProvider errorProvider;  // ErrorProvider para validación

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cboPais = new ComboBox();
            cboEstado = new ComboBox();
            cboEditorialId = new ComboBox();
            txtNombre = new TextBox();
            txtCiudad = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblEditorialId = new Label();
            lblNombre = new Label();
            lblCiudad = new Label();
            lblEstado = new Label();
            lblPais = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // cboPais
            // 
            cboPais.FormattingEnabled = true;
            cboPais.Location = new Point(150, 150);
            cboPais.Name = "cboPais";
            cboPais.Size = new Size(200, 28);
            cboPais.TabIndex = 0;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(150, 196);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(200, 28);
            cboEstado.TabIndex = 1;
            // 
            // cboEditorialId
            // 
            cboEditorialId.FormattingEnabled = true;
            cboEditorialId.Location = new Point(150, 30);
            cboEditorialId.Name = "cboEditorialId";
            cboEditorialId.Size = new Size(200, 28);
            cboEditorialId.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 27);
            txtNombre.TabIndex = 3;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(150, 107);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(200, 27);
            txtCiudad.TabIndex = 4;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(150, 230);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 30);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(275, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblEditorialId
            // 
            lblEditorialId.AutoSize = true;
            lblEditorialId.Location = new Point(30, 30);
            lblEditorialId.Name = "lblEditorialId";
            lblEditorialId.Size = new Size(87, 20);
            lblEditorialId.TabIndex = 7;
            lblEditorialId.Text = "Editorial ID:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre:";
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(30, 110);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(59, 20);
            lblCiudad.TabIndex = 9;
            lblCiudad.Text = "Ciudad:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(30, 200);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado:";
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(30, 150);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(37, 20);
            lblPais.TabIndex = 11;
            lblPais.Text = "País:";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormAddEditEditorial
            // 
            ClientSize = new Size(379, 283);
            Controls.Add(cboPais);
            Controls.Add(cboEstado);
            Controls.Add(cboEditorialId);
            Controls.Add(txtNombre);
            Controls.Add(txtCiudad);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(lblEditorialId);
            Controls.Add(lblNombre);
            Controls.Add(lblCiudad);
            Controls.Add(lblEstado);
            Controls.Add(lblPais);
            Name = "FormAddEditEditorial";
            Text = "Agregar/Editar Editorial";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
