namespace ExamenTopicos
{
    partial class FormAgregarTienda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip = new ToolTip(components);
            label6 = new Label();
            txtIdTienda = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label4 = new Label();
            txtDireccion = new TextBox();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            label8 = new Label();
            txtEstado = new TextBox();
            label9 = new Label();
            mskCP = new MaskedTextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 74);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 0;
            label6.Text = "ID Tienda";
            toolTip.SetToolTip(label6, "Ingrese el ID único de la tienda.");
            // 
            // txtIdTienda
            // 
            txtIdTienda.AcceptsTab = true;
            txtIdTienda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdTienda.Location = new Point(128, 72);
            txtIdTienda.Margin = new Padding(3, 2, 3, 2);
            txtIdTienda.Name = "txtIdTienda";
            txtIdTienda.ReadOnly = true;
            txtIdTienda.Size = new Size(217, 23);
            txtIdTienda.TabIndex = 0;
            toolTip.SetToolTip(txtIdTienda, "Ejemplo: T001");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 111);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Nombre";
            toolTip.SetToolTip(label3, "Ingrese el nombre de la tienda.");
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(128, 109);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(217, 23);
            txtNombre.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 149);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 2;
            label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDireccion.Location = new Point(128, 147);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(217, 23);
            txtDireccion.TabIndex = 2;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(23, 187);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(45, 15);
            lblCiudad.TabIndex = 3;
            lblCiudad.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            txtCiudad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCiudad.Location = new Point(128, 184);
            txtCiudad.Margin = new Padding(3, 2, 3, 2);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(217, 23);
            txtCiudad.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 224);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 4;
            label8.Text = "Estado";
            // 
            // txtEstado
            // 
            txtEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEstado.Location = new Point(128, 222);
            txtEstado.Margin = new Padding(3, 2, 3, 2);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(217, 23);
            txtEstado.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 261);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 5;
            label9.Text = "Código Postal";
            // 
            // mskCP
            // 
            mskCP.Location = new Point(128, 256);
            mskCP.Margin = new Padding(3, 2, 3, 2);
            mskCP.Mask = "00000";
            mskCP.Name = "mskCP";
            mskCP.Size = new Size(122, 23);
            mskCP.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(55, 319);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(111, 30);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(214, 319);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 30);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarTienda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 366);
            Controls.Add(label6);
            Controls.Add(txtIdTienda);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(txtDireccion);
            Controls.Add(lblCiudad);
            Controls.Add(txtCiudad);
            Controls.Add(label8);
            Controls.Add(txtEstado);
            Controls.Add(label9);
            Controls.Add(mskCP);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FormAgregarTienda";
            Padding = new Padding(18, 45, 18, 15);
            Text = "Agregar Tienda";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label6, label3, label4, lblCiudad, label8, label9;
        private TextBox txtIdTienda, txtNombre, txtDireccion, txtCiudad, txtEstado;
        private MaskedTextBox mskCP;
        private Button btnAceptar, btnCancelar;
        private ToolTip toolTip;
    }
}