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
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 0;
            label6.Text = "ID Tienda";
            toolTip.SetToolTip(label6, "Ingrese el ID único de la tienda.");
            // 
            // txtIdTienda
            // 
            txtIdTienda.AcceptsTab = true;
            txtIdTienda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdTienda.Location = new Point(141, 17);
            txtIdTienda.Name = "txtIdTienda";
            txtIdTienda.ReadOnly = true;
            txtIdTienda.Size = new Size(247, 27);
            txtIdTienda.TabIndex = 0;
            toolTip.SetToolTip(txtIdTienda, "Ejemplo: T001");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 70);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 1;
            label3.Text = "Nombre";
            toolTip.SetToolTip(label3, "Ingrese el nombre de la tienda.");
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(141, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(247, 27);
            txtNombre.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 120);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 2;
            label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDireccion.Location = new Point(141, 117);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(247, 27);
            txtDireccion.TabIndex = 2;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(20, 170);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(56, 20);
            lblCiudad.TabIndex = 3;
            lblCiudad.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            txtCiudad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCiudad.Location = new Point(141, 167);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(247, 27);
            txtCiudad.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 220);
            label8.Name = "label8";
            label8.Size = new Size(54, 20);
            label8.TabIndex = 4;
            label8.Text = "Estado";
            // 
            // txtEstado
            // 
            txtEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEstado.Location = new Point(141, 217);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(247, 27);
            txtEstado.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 270);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 5;
            label9.Text = "Código Postal";
            // 
            // mskCP
            // 
            mskCP.Location = new Point(141, 263);
            mskCP.Mask = "00000";
            mskCP.Name = "mskCP";
            mskCP.Size = new Size(139, 27);
            mskCP.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAceptar.Location = new Point(57, 330);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(110, 40);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(250, 330);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarTienda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 382);
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
            Name = "FormAgregarTienda";
            StartPosition = FormStartPosition.CenterScreen;
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