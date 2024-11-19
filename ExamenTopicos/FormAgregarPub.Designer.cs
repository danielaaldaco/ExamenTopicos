namespace ExamenTopicos
{
    partial class FormAgregarPub
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtNombre = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtEstado = new TextBox();
            label1 = new Label();
            txtCiudad = new TextBox();
            label4 = new Label();
            txtPais = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(342, 301);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(224, 301);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 13;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(255, 23);
            txtNombre.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 41);
            label3.Name = "label3";
            label3.Size = new Size(407, 15);
            label3.TabIndex = 14;
            label3.Text = "Favor de rellnar los campos correspondientes para agregar la nueva editorial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 96);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 11;
            label2.Text = "Nombre";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(120, 181);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(255, 23);
            txtEstado.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 189);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 17;
            label1.Text = "Estado";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(120, 135);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(255, 23);
            txtCiudad.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 143);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 19;
            label4.Text = "Ciudad";
            // 
            // txtPais
            // 
            txtPais.Location = new Point(120, 229);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(255, 23);
            txtPais.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 237);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 21;
            label5.Text = "Pais";
            // 
            // FormAgregarPub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 362);
            Controls.Add(txtPais);
            Controls.Add(label5);
            Controls.Add(txtCiudad);
            Controls.Add(label4);
            Controls.Add(txtEstado);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormAgregarPub";
            Text = "FormAgregarPub";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtNombre;
        private Label label3;
        private Label label2;
        private TextBox txtEstado;
        private Label label1;
        private TextBox txtCiudad;
        private Label label4;
        private TextBox txtPais;
        private Label label5;
    }
}