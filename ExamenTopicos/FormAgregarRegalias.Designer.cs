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
            cmbTitulo.DropDownStyle = ComboBoxStyle.DropDownList; // Establecer DropDownList
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(157, 25);
            cmbTitulo.Margin = new Padding(3, 4, 3, 4);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(179, 28);
            cmbTitulo.TabIndex = 1;
            // 
            // cmbAutor
            // 
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList; // Establecer DropDownList
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(157, 103);
            cmbAutor.Margin = new Padding(3, 4, 3, 4);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(179, 28);
            cmbAutor.TabIndex = 2;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(157, 168);
            nudOrden.Margin = new Padding(3, 4, 3, 4);
            nudOrden.Maximum = new decimal(new int[] { 1000, 0, 0, 0 }); // Ajustar según necesidad
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(179, 27);
            nudOrden.TabIndex = 3;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudRegalias
            // 
            nudRegalias.Location = new Point(157, 232);
            nudRegalias.Margin = new Padding(3, 4, 3, 4);
            nudRegalias.Maximum = new decimal(new int[] { 100, 0, 0, 0 }); // Porcentaje máximo
            nudRegalias.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nudRegalias.Name = "nudRegalias";
            nudRegalias.Size = new Size(179, 27);
            nudRegalias.TabIndex = 4;
            nudRegalias.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // label1 (Autor)
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 113);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 4;
            label1.Text = "Autor";
            // 
            // label2 (Titulo)
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 36);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 5;
            label2.Text = "Título";
            // 
            // label3 (Orden de autor)
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 175);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 7;
            label3.Text = "Orden de autor";
            // 
            // label4 (Regalias)
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 239);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 6;
            label4.Text = "Regalías";
            // 
            // btnAceptar
            // 
            btnAceptar.Image = Properties.Resources.pencil2;
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft; // Alinear imagen a la izquierda
            btnAceptar.Location = new Point(54, 295);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(111, 31);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextAlign = ContentAlignment.MiddleRight; // Alinear texto a la derecha
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(206, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 31);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label3 (Mensaje de instrucciones)
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 10);
            label3.Name = "label3";
            label3.Size = new Size(370, 15);
            label3.TabIndex = 30;
            label3.Text = "Favor de rellenar los campos correspondientes para agregar la regalía";
            // 
            // FormAgregarRegalias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 376);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAgregarRegalias";
            Text = "FormAgregarRegalias";
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
        private Label label3;
        private Label label4;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}
