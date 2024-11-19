namespace ExamenTopicos
{
    partial class FormAgregarRegalias
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
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            label1 = new Label();
            cmbTitulo = new ComboBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtVentasMin = new TextBox();
            txtVentasMax = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(157, 233);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 26;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 235);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 34;
            label6.Text = "% Regalias";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 97);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 33;
            label1.Text = "ID Titulo";
            // 
            // cmbTitulo
            // 
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(156, 89);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(121, 23);
            cmbTitulo.TabIndex = 23;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(313, 328);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(195, 328);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 27;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 187);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 32;
            label5.Text = "Ventas maximas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 139);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 31;
            label4.Text = "Ventas minimas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 38);
            label3.Name = "label3";
            label3.Size = new Size(370, 15);
            label3.TabIndex = 30;
            label3.Text = "Favor de rellenar los campos correspondientes para agregar la regalía";
            // 
            // txtVentasMin
            // 
            txtVentasMin.Location = new Point(157, 136);
            txtVentasMin.Name = "txtVentasMin";
            txtVentasMin.Size = new Size(121, 23);
            txtVentasMin.TabIndex = 35;
            // 
            // txtVentasMax
            // 
            txtVentasMax.Location = new Point(156, 184);
            txtVentasMax.Name = "txtVentasMax";
            txtVentasMax.Size = new Size(121, 23);
            txtVentasMax.TabIndex = 36;
            // 
            // FormAgregarRegalias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 376);
            Controls.Add(txtVentasMax);
            Controls.Add(txtVentasMin);
            Controls.Add(numericUpDown1);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(cmbTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Name = "FormAgregarRegalias";
            Text = "FormAgregarRegalias";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown1;
        private Label label6;
        private Label label1;
        private ComboBox cmbTitulo;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtVentasMin;
        private TextBox txtVentasMax;
    }
}