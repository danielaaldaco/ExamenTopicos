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
            label5 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudRegalias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            SuspendLayout();
            // 
            // cmbTitulo
            // 
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(157, 91);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(121, 23);
            cmbTitulo.TabIndex = 1;
            // 
            // cmbAutor
            // 
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(157, 149);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(121, 23);
            cmbAutor.TabIndex = 2;
            // 
            // nudRegalias
            // 
            nudRegalias.Location = new Point(158, 246);
            nudRegalias.Name = "nudRegalias";
            nudRegalias.Size = new Size(120, 23);
            nudRegalias.TabIndex = 4;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(157, 198);
            nudOrden.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(120, 23);
            nudOrden.TabIndex = 3;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 157);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "ID Autor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 99);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "ID Titulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 206);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(87, 15);
            label3.TabIndex = 7;
            label3.Text = "Orden de autor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 254);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Regalias";
            // 
            // label5
            // 
            label5.Location = new Point(25, 27);
            label5.Name = "label5";
            label5.Size = new Size(407, 38);
            label5.TabIndex = 15;
            label5.Text = "Favor de seleccionar los campos correspondientes para agregar la relacion del autor y su titulo";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(334, 339);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(216, 339);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FormAgregarAT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 393);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudOrden);
            Controls.Add(nudRegalias);
            Controls.Add(cmbAutor);
            Controls.Add(cmbTitulo);
            Name = "FormAgregarAT";
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
        private Label label5;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}