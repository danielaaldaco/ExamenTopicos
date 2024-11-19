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
            txtDireccion = new TextBox();
            txtNombre = new TextBox();
            label7 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellido = new TextBox();
            mskTelefono = new MaskedTextBox();
            textCiudad = new TextBox();
            Ciudad = new Label();
            txtEstado = new TextBox();
            label8 = new Label();
            mskCP = new MaskedTextBox();
            label9 = new Label();
            rBtnSi = new RadioButton();
            rBtnNo = new RadioButton();
            mskIdAutor = new MaskedTextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(167, 244);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(193, 23);
            txtDireccion.TabIndex = 4;
            txtDireccion.TextChanged += txtCantidad_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(168, 152);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 23);
            txtNombre.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 199);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(52, 15);
            label7.TabIndex = 44;
            label7.Text = "Telefono";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(615, 329);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(502, 329);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Location = new Point(26, 22);
            label5.Name = "label5";
            label5.Size = new Size(687, 38);
            label5.TabIndex = 43;
            label5.Text = "Favor de rellene los campos correspondientes para agregar la información sobre el autor";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 155);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(51, 15);
            label3.TabIndex = 42;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 247);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 41;
            label4.Text = "Dirección";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 250);
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
            label1.Location = new Point(49, 115);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 39;
            label1.Text = "Primer apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(167, 112);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(194, 23);
            txtApellido.TabIndex = 1;
            // 
            // mskTelefono
            // 
            mskTelefono.Location = new Point(167, 196);
            mskTelefono.Mask = "(999)000-0000";
            mskTelefono.Name = "mskTelefono";
            mskTelefono.Size = new Size(194, 23);
            mskTelefono.TabIndex = 3;
            // 
            // textCiudad
            // 
            textCiudad.Location = new Point(519, 112);
            textCiudad.Name = "textCiudad";
            textCiudad.Size = new Size(193, 23);
            textCiudad.TabIndex = 5;
            // 
            // Ciudad
            // 
            Ciudad.AutoSize = true;
            Ciudad.Location = new Point(401, 115);
            Ciudad.Name = "Ciudad";
            Ciudad.Size = new Size(45, 15);
            Ciudad.TabIndex = 49;
            Ciudad.Text = "Ciudad";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(519, 152);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(193, 23);
            txtEstado.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(401, 155);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 51;
            label8.Text = "Estado";
            // 
            // mskCP
            // 
            mskCP.Location = new Point(519, 196);
            mskCP.Mask = "00000";
            mskCP.Name = "mskCP";
            mskCP.Size = new Size(194, 23);
            mskCP.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(401, 199);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(81, 15);
            label9.TabIndex = 52;
            label9.Text = "Codigo postal";
            // 
            // rBtnSi
            // 
            rBtnSi.AutoSize = true;
            rBtnSi.Location = new Point(519, 248);
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
            rBtnNo.Location = new Point(572, 247);
            rBtnNo.Name = "rBtnNo";
            rBtnNo.Size = new Size(41, 19);
            rBtnNo.TabIndex = 9;
            rBtnNo.TabStop = true;
            rBtnNo.Text = "No";
            rBtnNo.UseVisualStyleBackColor = true;
            // 
            // mskIdAutor
            // 
            mskIdAutor.Location = new Point(167, 73);
            mskIdAutor.Mask = "000-00-0000";
            mskIdAutor.Name = "mskIdAutor";
            mskIdAutor.Size = new Size(153, 23);
            mskIdAutor.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 81);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 53;
            label6.Text = "ID Autor";
            // 
            // FormAgregarAutores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 386);
            Controls.Add(mskIdAutor);
            Controls.Add(label6);
            Controls.Add(rBtnNo);
            Controls.Add(rBtnSi);
            Controls.Add(mskCP);
            Controls.Add(label9);
            Controls.Add(txtEstado);
            Controls.Add(label8);
            Controls.Add(textCiudad);
            Controls.Add(Ciudad);
            Controls.Add(mskTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAgregarAutores";
            Text = "FormAgregarAutores";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDireccion;
        private TextBox txtNombre;
        private Label label7;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtApellido;
        private MaskedTextBox mskTelefono;
        private TextBox textCiudad;
        private Label Ciudad;
        private TextBox txtEstado;
        private Label label8;
        private MaskedTextBox mskCP;
        private Label label9;
        private RadioButton rBtnSi;
        private RadioButton rBtnNo;
        private MaskedTextBox mskIdAutor;
        private Label label6;
    }
}