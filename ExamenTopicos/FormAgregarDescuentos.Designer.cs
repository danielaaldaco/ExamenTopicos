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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarDescuentos));
            btnCancelar = new Button();
            btnAceptar = new Button();
            nudMin = new NumericUpDown();
            nudMax = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            cmbIdTienda = new ComboBox();
            nudDescuento = new NumericUpDown();
            label6 = new Label();
            label2 = new Label();
            txtDescripcion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDescuento).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(193, 315);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(75, 315);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // nudMin
            // 
            nudMin.Location = new Point(130, 163);
            nudMin.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMin.Name = "nudMin";
            nudMin.Size = new Size(120, 23);
            nudMin.TabIndex = 3;
            nudMin.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudMax
            // 
            nudMax.Location = new Point(131, 205);
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
            label5.Location = new Point(17, 213);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 17;
            label5.Text = "Cantidad máxima";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 165);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 16;
            label4.Text = "Cantidad minima";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 118);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 19;
            label1.Text = "ID Tienda";
            // 
            // cmbIdTienda
            // 
            cmbIdTienda.FormattingEnabled = true;
            cmbIdTienda.Location = new Point(130, 110);
            cmbIdTienda.Name = "cmbIdTienda";
            cmbIdTienda.Size = new Size(121, 23);
            cmbIdTienda.TabIndex = 2;
            // 
            // nudDescuento
            // 
            nudDescuento.Location = new Point(131, 248);
            nudDescuento.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudDescuento.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDescuento.Name = "nudDescuento";
            nudDescuento.Size = new Size(120, 23);
            nudDescuento.TabIndex = 5;
            nudDescuento.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 256);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 21;
            label6.Text = "% Descuento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 74);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 11;
            label2.Text = "Tipo";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(131, 71);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(218, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // FormAgregarDescuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 364);
            Controls.Add(nudDescuento);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(cmbIdTienda);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudMin);
            Controls.Add(nudMax);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAgregarDescuentos";
            Text = "Agregar descuentos";
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDescuento).EndInit();
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
        private Label label1;
        private ComboBox cmbIdTienda;
        private NumericUpDown nudDescuento;
        private Label label6;
        private Label label2;
        private TextBox txtDescripcion;
    }
}