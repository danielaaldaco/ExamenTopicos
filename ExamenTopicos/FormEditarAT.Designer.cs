namespace ExamenTopicos
{
    partial class FormEditarAT
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
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            nudOrden = new NumericUpDown();
            nudRegalias = new NumericUpDown();
            cmbAutor = new ComboBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegalias).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(281, 310);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(163, 310);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(24, 22);
            label5.Name = "label5";
            label5.Size = new Size(355, 41);
            label5.TabIndex = 26;
            label5.Text = "Favor de seleccionar los campos correspondientes para editar la relacion del titulo y su autor";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 194);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(87, 15);
            label3.TabIndex = 25;
            label3.Text = "Orden de autor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 242);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 24;
            label4.Text = "Regalias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 87);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(51, 15);
            label2.TabIndex = 23;
            label2.Text = "ID Titulo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 145);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 21;
            label1.Text = "ID Autor";
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(161, 186);
            nudOrden.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(120, 23);
            nudOrden.TabIndex = 2;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudRegalias
            // 
            nudRegalias.Location = new Point(162, 234);
            nudRegalias.Name = "nudRegalias";
            nudRegalias.Size = new Size(120, 23);
            nudRegalias.TabIndex = 3;
            // 
            // cmbAutor
            // 
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(161, 137);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(121, 23);
            cmbAutor.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.White;
            lblTitulo.Location = new Point(161, 87);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(121, 23);
            lblTitulo.TabIndex = 29;
            // 
            // FormEditarAT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 356);
            Controls.Add(lblTitulo);
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
            Name = "FormEditarAT";
            Text = "FormEditarAT";
            ((System.ComponentModel.ISupportInitialize)nudOrden).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegalias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private NumericUpDown nudOrden;
        private NumericUpDown nudRegalias;
        private ComboBox cmbAutor;
        private Label lblTitulo;
    }
}