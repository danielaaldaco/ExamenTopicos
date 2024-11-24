namespace ExamenTopicos
{
    partial class FormAgregarAutores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarAutores));
            txtDireccion = new TextBox();
            txtNombre = new TextBox();
            label7 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellido = new TextBox();
            txtCiudad = new TextBox();
            Ciudad = new Label();
            txtEstado = new TextBox();
            label8 = new Label();
            label9 = new Label();
            rBtnSi = new RadioButton();
            rBtnNo = new RadioButton();
            label6 = new Label();
            txtIdAutor = new TextBox();
            txtTelefono = new TextBox();
            txtCP = new TextBox();
            SuspendLayout();
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.FromArgb(242, 242, 242);
            txtDireccion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDireccion.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtDireccion.Location = new Point(139, 243);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(193, 24);
            txtDireccion.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(242, 242, 242);
            txtNombre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtNombre.Location = new Point(140, 158);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 24);
            txtNombre.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(242, 242, 242);
            label7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label7.Location = new Point(21, 198);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(61, 17);
            label7.TabIndex = 44;
            label7.Text = "Telefono";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(242, 242, 242);
            btnCancelar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnCancelar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnCancelar.Location = new Point(185, 466);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(242, 242, 242);
            btnAceptar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnAceptar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAceptar.Location = new Point(72, 466);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click_2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(242, 242, 242);
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label3.Location = new Point(21, 161);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(58, 17);
            label3.TabIndex = 42;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(242, 242, 242);
            label4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label4.Location = new Point(21, 246);
            label4.Name = "label4";
            label4.Size = new Size(65, 17);
            label4.TabIndex = 41;
            label4.Text = "Dirección";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(242, 242, 242);
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label2.Location = new Point(22, 425);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(126, 17);
            label2.TabIndex = 40;
            label2.Text = "?Contrato vigente¿";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.UseMnemonic = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(242, 242, 242);
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label1.Location = new Point(22, 120);
            label1.Name = "label1";
            label1.Size = new Size(100, 17);
            label1.TabIndex = 39;
            label1.Text = "Primer apellido";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(242, 242, 242);
            txtApellido.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtApellido.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtApellido.Location = new Point(140, 117);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(194, 24);
            txtApellido.TabIndex = 1;
            // 
            // txtCiudad
            // 
            txtCiudad.BackColor = Color.FromArgb(242, 242, 242);
            txtCiudad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCiudad.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCiudad.Location = new Point(140, 287);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(193, 24);
            txtCiudad.TabIndex = 5;
            // 
            // Ciudad
            // 
            Ciudad.AutoSize = true;
            Ciudad.BackColor = Color.FromArgb(242, 242, 242);
            Ciudad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Ciudad.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Ciudad.Location = new Point(22, 290);
            Ciudad.Name = "Ciudad";
            Ciudad.Size = new Size(52, 17);
            Ciudad.TabIndex = 49;
            Ciudad.Text = "Ciudad";
            // 
            // txtEstado
            // 
            txtEstado.BackColor = Color.FromArgb(242, 242, 242);
            txtEstado.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEstado.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtEstado.Location = new Point(140, 327);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(193, 24);
            txtEstado.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(242, 242, 242);
            label8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label8.Location = new Point(22, 330);
            label8.Name = "label8";
            label8.Size = new Size(52, 17);
            label8.TabIndex = 51;
            label8.Text = "Estado";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(242, 242, 242);
            label9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label9.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label9.Location = new Point(22, 374);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(94, 17);
            label9.TabIndex = 52;
            label9.Text = "Codigo postal";
            // 
            // rBtnSi
            // 
            rBtnSi.AutoSize = true;
            rBtnSi.BackColor = Color.FromArgb(242, 242, 242);
            rBtnSi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            rBtnSi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            rBtnSi.Location = new Point(156, 424);
            rBtnSi.Name = "rBtnSi";
            rBtnSi.Size = new Size(37, 21);
            rBtnSi.TabIndex = 8;
            rBtnSi.TabStop = true;
            rBtnSi.Text = "Sí";
            rBtnSi.UseVisualStyleBackColor = false;
            // 
            // rBtnNo
            // 
            rBtnNo.AutoSize = true;
            rBtnNo.BackColor = Color.FromArgb(242, 242, 242);
            rBtnNo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            rBtnNo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            rBtnNo.Location = new Point(209, 423);
            rBtnNo.Name = "rBtnNo";
            rBtnNo.Size = new Size(44, 21);
            rBtnNo.TabIndex = 9;
            rBtnNo.TabStop = true;
            rBtnNo.Text = "No";
            rBtnNo.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(242, 242, 242);
            label6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label6.Location = new Point(21, 80);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 53;
            label6.Text = "ID Autor";
            // 
            // txtIdAutor
            // 
            txtIdAutor.BackColor = Color.FromArgb(242, 242, 242);
            txtIdAutor.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIdAutor.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtIdAutor.Location = new Point(138, 77);
            txtIdAutor.Name = "txtIdAutor";
            txtIdAutor.Size = new Size(194, 24);
            txtIdAutor.TabIndex = 58;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(242, 242, 242);
            txtTelefono.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefono.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTelefono.Location = new Point(140, 198);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(193, 24);
            txtTelefono.TabIndex = 3;
            // 
            // txtCP
            // 
            txtCP.BackColor = Color.FromArgb(242, 242, 242);
            txtCP.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCP.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCP.Location = new Point(140, 371);
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(193, 24);
            txtCP.TabIndex = 7;
            // 
            // FormAgregarAutores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 504);
            Controls.Add(txtCP);
            Controls.Add(txtTelefono);
            Controls.Add(txtIdAutor);
            Controls.Add(label6);
            Controls.Add(rBtnNo);
            Controls.Add(rBtnSi);
            Controls.Add(label9);
            Controls.Add(txtEstado);
            Controls.Add(label8);
            Controls.Add(txtCiudad);
            Controls.Add(Ciudad);
            Controls.Add(txtApellido);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAgregarAutores";
            Text = "Agregar autor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDireccion;
        private TextBox txtNombre;
        private Label label7;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtApellido;
        private TextBox txtCiudad;
        private Label Ciudad;
        private TextBox txtEstado;
        private Label label8;
        private Label label9;
        private RadioButton rBtnSi;
        private RadioButton rBtnNo;
        private Label label6;
        private TextBox txtIdAutor;
        private TextBox txtTelefono;
        private TextBox txtCP;
    }
}