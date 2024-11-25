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
            cmbTitulo = new ComboBox();
            cmbAutor = new ComboBox();
            nudRegalias = new NumericUpDown();
            nudOrden = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudRegalias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            SuspendLayout();
            // 
            // cmbTitulo
            // 
            cmbTitulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(156, 79);
            cmbTitulo.Margin = new Padding(3, 4, 3, 4);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(179, 23);
            cmbTitulo.TabIndex = 1;
            // 
            // cmbAutor
            // 
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(156, 135);
            cmbAutor.Margin = new Padding(3, 4, 3, 4);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(179, 23);
            cmbAutor.TabIndex = 2;
            // 
            // nudRegalias
            // 
            nudRegalias.Location = new Point(156, 245);
            nudRegalias.Margin = new Padding(3, 4, 3, 4);
            nudRegalias.Name = "nudRegalias";
            nudRegalias.Size = new Size(179, 23);
            nudRegalias.TabIndex = 4;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(156, 187);
            nudOrden.Margin = new Padding(3, 4, 3, 4);
            nudOrden.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(179, 23);
            nudOrden.TabIndex = 3;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 138);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 4;
            label1.Text = "Autor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 87);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 5;
            label2.Text = "Título";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 253);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Regalías";
            // 
            // btnCancelar
            // 
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(202, 308);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 31);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(63, 308);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 31);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 195);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 7;
            label3.Text = "No. Orden";
            label3.Click += label3_Click;
            // 
            // FormAgregarRegalias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 373);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudOrden);
            Controls.Add(nudRegalias);
            Controls.Add(cmbAutor);
            Controls.Add(cmbTitulo);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormAgregarRegalias";
            Text = "Agregar regalías";
            ((System.ComponentModel.ISupportInitialize)nudRegalias).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTitulo;
        private ComboBox cmbAutor;
        private NumericUpDown nudOrden;
        private NumericUpDown nudRegalias;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label3;
    }
}
