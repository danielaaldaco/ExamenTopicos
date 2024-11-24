namespace ExamenTopicos
{
    partial class FormAgregarVenta
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
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtOrden = new TextBox();
            txtCantidad = new TextBox();
            cmbPago = new ComboBox();
            cmbTienda = new ComboBox();
            cmbTitulo = new ComboBox();
            dtpFecha = new DateTimePicker();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(254, 380);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 31);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(73, 380);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(110, 31);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 20);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(89, 20);
            label3.TabIndex = 25;
            label3.Text = "N. de Orden";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 196);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 24;
            label4.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 322);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(47, 20);
            label2.TabIndex = 23;
            label2.Text = "Título";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 76);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 21;
            label1.Text = "Tienda";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 132);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(111, 20);
            label7.TabIndex = 30;
            label7.Text = "Fecha de orden";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 259);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 33;
            label8.Text = "Forma de pago";
            // 
            // txtOrden
            // 
            txtOrden.Location = new Point(196, 12);
            txtOrden.Margin = new Padding(3, 4, 3, 4);
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(216, 27);
            txtOrden.TabIndex = 2;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(196, 188);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(216, 27);
            txtCantidad.TabIndex = 3;
            // 
            // cmbPago
            // 
            cmbPago.FormattingEnabled = true;
            cmbPago.Location = new Point(196, 251);
            cmbPago.Margin = new Padding(3, 4, 3, 4);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(216, 28);
            cmbPago.TabIndex = 4;
            // 
            // cmbTienda
            // 
            cmbTienda.FormattingEnabled = true;
            cmbTienda.Location = new Point(196, 68);
            cmbTienda.Margin = new Padding(3, 4, 3, 4);
            cmbTienda.Name = "cmbTienda";
            cmbTienda.Size = new Size(216, 28);
            cmbTienda.TabIndex = 1;
            // 
            // cmbTitulo
            // 
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(196, 314);
            cmbTitulo.Margin = new Padding(3, 4, 3, 4);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(216, 28);
            cmbTitulo.TabIndex = 5;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(196, 128);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(216, 27);
            dtpFecha.TabIndex = 2;
            // 
            // FormAgregarVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 424);
            Controls.Add(dtpFecha);
            Controls.Add(cmbTitulo);
            Controls.Add(cmbTienda);
            Controls.Add(cmbPago);
            Controls.Add(txtCantidad);
            Controls.Add(txtOrden);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAgregarVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAgregarVenta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox2;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private Label label8;
        private NumericUpDown numericUpDown2;
        private TextBox txtOrden;
        private TextBox txtCantidad;
        private ComboBox cmbPago;
        private ComboBox cmbTienda;
        private ComboBox cmbTitulo;
        private DateTimePicker dtpFecha;
    }
}