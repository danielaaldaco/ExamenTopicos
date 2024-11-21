namespace ExamenTopicos
{
    partial class FormAgregarDescuentos
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
            nudMin = new NumericUpDown();
            nudMax = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            label2 = new Label();
            txtDescripcion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(345, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(227, 335);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // nudMin
            // 
            nudMin.Location = new Point(147, 190);
            nudMin.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMin.Name = "nudMin";
            nudMin.Size = new Size(120, 23);
            nudMin.TabIndex = 3;
            nudMin.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudMax
            // 
            nudMax.Location = new Point(148, 232);
            nudMax.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMax.Name = "nudMax";
            nudMax.Size = new Size(120, 23);
            nudMax.TabIndex = 4;
            nudMax.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 240);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 17;
            label5.Text = "Cantidad máxima";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 192);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 16;
            label4.Text = "Cantidad minima";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 45);
            label3.Name = "label3";
            label3.Size = new Size(426, 15);
            label3.TabIndex = 14;
            label3.Text = "Favor de rellenar los campos correspondientes para agregar el nuevo descuento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 145);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 19;
            label1.Text = "ID Tienda";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(147, 137);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(148, 275);
            numericUpDown1.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 283);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 21;
            label6.Text = "% Descuento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 101);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 11;
            label2.Text = "Tipo";
            label2.Click += label2_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(147, 93);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(255, 23);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.TextAlign = HorizontalAlignment.Right;
            // 
            // FormAgregarDescuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 388);
            Controls.Add(numericUpDown1);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudMin);
            Controls.Add(nudMax);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormAgregarDescuentos";
            Text = "FormAgregarDescuentos";
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private NumericUpDown nudMin;
        private NumericUpDown nudMax;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private ComboBox comboBox2;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private Label label2;
        private TextBox txtDescripcion;
    }
}