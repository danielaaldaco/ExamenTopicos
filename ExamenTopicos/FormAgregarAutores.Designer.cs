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
            txtDireccion.Location = new Point(132, 191);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(193, 23);
            txtDireccion.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(133, 106);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 23);
            txtNombre.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 146);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(52, 15);
            label7.TabIndex = 44;
            label7.Text = "Telefono";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(227, 423);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(114, 423);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 109);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(51, 15);
            label3.TabIndex = 42;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 194);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 41;
            label4.Text = "Dirección";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 373);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(106, 15);
            label2.TabIndex = 40;
            label2.Text = "?Contrato vigente¿";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.UseMnemonic = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 68);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 39;
            label1.Text = "Primer apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(133, 65);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(194, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(133, 235);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(193, 23);
            txtCiudad.TabIndex = 5;
            // 
            // Ciudad
            // 
            Ciudad.AutoSize = true;
            Ciudad.Location = new Point(15, 238);
            Ciudad.Name = "Ciudad";
            Ciudad.Size = new Size(45, 15);
            Ciudad.TabIndex = 49;
            Ciudad.Text = "Ciudad";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(133, 275);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(193, 23);
            txtEstado.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 278);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 51;
            label8.Text = "Estado";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 322);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(81, 15);
            label9.TabIndex = 52;
            label9.Text = "Codigo postal";
            // 
            // rBtnSi
            // 
            rBtnSi.AutoSize = true;
            rBtnSi.Location = new Point(133, 371);
            rBtnSi.Name = "rBtnSi";
            rBtnSi.Size = new Size(34, 19);
            rBtnSi.TabIndex = 8;
            rBtnSi.TabStop = true;
            rBtnSi.Text = "Sí";
            rBtnSi.UseVisualStyleBackColor = true;
            // 
            // rBtnNo
            // 
            rBtnNo.AutoSize = true;
            rBtnNo.Location = new Point(186, 370);
            rBtnNo.Name = "rBtnNo";
            rBtnNo.Size = new Size(41, 19);
            rBtnNo.TabIndex = 9;
            rBtnNo.TabStop = true;
            rBtnNo.Text = "No";
            rBtnNo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 28);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 53;
            label6.Text = "ID Autor";
            // 
            // txtIdAutor
            // 
            txtIdAutor.Location = new Point(131, 25);
            txtIdAutor.Name = "txtIdAutor";
            txtIdAutor.Size = new Size(194, 23);
            txtIdAutor.TabIndex = 58;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(133, 146);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(193, 23);
            txtTelefono.TabIndex = 3;
            // 
            // txtCP
            // 
            txtCP.Location = new Point(133, 319);
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(193, 23);
            txtCP.TabIndex = 7;
            // 
            // FormAgregarAutores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 458);
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