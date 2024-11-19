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
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            this.cmbIdTienda = new ComboBox();
            cmbTitulos = new ComboBox();
            label7 = new Label();
            this.dtpFechaOrden = new DateTimePicker();
            label8 = new Label();
            txtOrden = new TextBox();
            txtCantidad = new TextBox();
            cmbPago = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(339, 372);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(226, 372);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Location = new Point(49, 26);
            label5.Name = "label5";
            label5.Size = new Size(407, 38);
            label5.TabIndex = 26;
            label5.Text = "Favor de rellene los campos correspondientes para agregar la venta";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 125);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(71, 15);
            label3.TabIndex = 25;
            label3.Text = "N. de Orden";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 217);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 24;
            label4.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 311);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(51, 15);
            label2.TabIndex = 23;
            label2.Text = "ID Titulo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 85);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 21;
            label1.Text = "ID Tienda";
            // 
            // cmbIdTienda
            // 
            this.cmbIdTienda.FormattingEnabled = true;
            this.cmbIdTienda.Location = new Point(173, 82);
            this.cmbIdTienda.Name = "cmbIdTienda";
            this.cmbIdTienda.Size = new Size(121, 23);
            this.cmbIdTienda.TabIndex = 1;
            // 
            // cmbTitulos
            // 
            cmbTitulos.FormattingEnabled = true;
            cmbTitulos.Location = new Point(174, 308);
            cmbTitulos.Name = "cmbTitulos";
            cmbTitulos.Size = new Size(121, 23);
            cmbTitulos.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(55, 169);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(88, 15);
            label7.TabIndex = 30;
            label7.Text = "Fecha de orden";
            // 
            // dtpFechaOrden
            // 
            this.dtpFechaOrden.Format = DateTimePickerFormat.Short;
            this.dtpFechaOrden.Location = new Point(174, 168);
            this.dtpFechaOrden.Name = "dtpFechaOrden";
            this.dtpFechaOrden.Size = new Size(121, 23);
            this.dtpFechaOrden.TabIndex = 3;
            this.dtpFechaOrden.ValueChanged += this.dateTimePicker1_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(56, 264);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 33;
            label8.Text = "Termino de pago";
            // 
            // txtOrden
            // 
            txtOrden.Location = new Point(174, 122);
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(121, 23);
            txtOrden.TabIndex = 2;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(173, 214);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(121, 23);
            txtCantidad.TabIndex = 4;
            // 
            // cmbPago
            // 
            cmbPago.FormattingEnabled = true;
            cmbPago.Location = new Point(173, 261);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(121, 23);
            cmbPago.TabIndex = 5;
            // 
            // FormAgregarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 426);
            Controls.Add(cmbPago);
            Controls.Add(txtCantidad);
            Controls.Add(txtOrden);
            Controls.Add(label8);
            Controls.Add(this.dtpFechaOrden);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(this.cmbIdTienda);
            Controls.Add(cmbTitulos);
            Name = "FormAgregarVenta";
            Text = "FormAgregarVenta";
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
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox2;
        private ComboBox cmbTitulos;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private Label label8;
        private NumericUpDown numericUpDown2;
        private TextBox txtOrden;
        private TextBox txtCantidad;
        private ComboBox cmbPago;
    }
}