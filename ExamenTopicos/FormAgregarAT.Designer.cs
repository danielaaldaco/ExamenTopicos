namespace ExamenTopicos
{
    partial class FormAgregarAT
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
            cmbTitulo = new ComboBox();
            cmbAutor = new ComboBox();
            nudRegalias = new NumericUpDown();
            nudOrden = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudRegalias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            SuspendLayout();
            // 
            // cmbTitulo
            // 
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(121, 68);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(157, 23);
            cmbTitulo.TabIndex = 1;
            cmbTitulo.SelectedIndexChanged += cmbTitulo_SelectedIndexChanged;
            // 
            // cmbAutor
            // 
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(121, 126);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(157, 23);
            cmbAutor.TabIndex = 2;
            // 
            // nudRegalias
            // 
            nudRegalias.Location = new Point(122, 223);
            nudRegalias.Name = "nudRegalias";
            nudRegalias.Size = new Size(155, 23);
            nudRegalias.TabIndex = 4;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(121, 175);
            nudOrden.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(157, 23);
            nudOrden.TabIndex = 3;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 134);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 4;
            label1.Text = "Autor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 76);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(37, 15);
            label2.TabIndex = 5;
            label2.Text = "Titulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 180);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(87, 15);
            label3.TabIndex = 7;
            label3.Text = "Orden de autor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 228);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Regalias";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(160, 278);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(27, 278);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // FormAgregarAT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 329);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudOrden);
            Controls.Add(nudRegalias);
            Controls.Add(cmbAutor);
            Controls.Add(cmbTitulo);
            Name = "FormAgregarAT";
            Padding = new Padding(18, 45, 18, 15);
            Text = "FormAgregarAT";
            ((System.ComponentModel.ISupportInitialize)nudRegalias).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTitulo;
        private ComboBox cmbAutor;
        private NumericUpDown nudRegalias;
        private NumericUpDown nudOrden;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}