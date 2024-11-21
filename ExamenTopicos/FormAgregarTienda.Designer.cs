namespace ExamenTopicos
{
    partial class FormAgregarTienda
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
            label6 = new Label();
            mskCP = new MaskedTextBox();
            label9 = new Label();
            txtEstado = new TextBox();
            label8 = new Label();
            textCiudad = new TextBox();
            Ciudad = new Label();
            txtDireccion = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 96);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 73;
            label6.Text = "ID Tienda";
            // 
            // mskCP
            // 
            mskCP.Location = new Point(154, 294);
            mskCP.Mask = "00000";
            mskCP.Name = "mskCP";
            mskCP.Size = new Size(194, 23);
            mskCP.TabIndex = 61;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(36, 297);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(81, 15);
            label9.TabIndex = 72;
            label9.Text = "Codigo postal";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(154, 250);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(193, 23);
            txtEstado.TabIndex = 60;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 253);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 71;
            label8.Text = "Estado";
            // 
            // textCiudad
            // 
            textCiudad.Location = new Point(154, 210);
            textCiudad.Name = "textCiudad";
            textCiudad.Size = new Size(193, 23);
            textCiudad.TabIndex = 59;
            // 
            // Ciudad
            // 
            Ciudad.AutoSize = true;
            Ciudad.Location = new Point(36, 213);
            Ciudad.Name = "Ciudad";
            Ciudad.Size = new Size(45, 15);
            Ciudad.TabIndex = 70;
            Ciudad.Text = "Ciudad";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(154, 170);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(193, 23);
            txtDireccion.TabIndex = 58;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(154, 130);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 23);
            txtNombre.TabIndex = 56;
            // 
            // label5
            // 
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(389, 69);
            label5.TabIndex = 68;
            label5.Text = "Favor de rellene los campos correspondientes para agregar la información sobre el autor";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 133);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(51, 15);
            label3.TabIndex = 67;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 173);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 66;
            label4.Text = "Dirección";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(154, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 23);
            textBox1.TabIndex = 75;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(291, 362);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 77;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(178, 362);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 76;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FormAgregarTienda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 406);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(mskCP);
            Controls.Add(label9);
            Controls.Add(txtEstado);
            Controls.Add(label8);
            Controls.Add(textCiudad);
            Controls.Add(Ciudad);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "FormAgregarTienda";
            Text = "FormAgregarTienda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private MaskedTextBox mskCP;
        private Label label9;
        private TextBox txtEstado;
        private Label label8;
        private TextBox textCiudad;
        private Label Ciudad;
        private TextBox txtDireccion;
        private TextBox txtNombre;
        private Label label5;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}