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
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtOrden = new TextBox();
            cmbPago = new ComboBox();
            cmbTienda = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnPedido = new Button();
            label2 = new Label();
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
            btnCancelar.Location = new Point(253, 424);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 31);
            btnCancelar.TabIndex = 7;
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
            btnAceptar.Location = new Point(73, 424);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(110, 31);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 108);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(89, 20);
            label3.TabIndex = 25;
            label3.Text = "N. de Orden";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 164);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 21;
            label1.Text = "Tienda";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 220);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(111, 20);
            label7.TabIndex = 30;
            label7.Text = "Fecha de orden";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 281);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 33;
            label8.Text = "Forma de pago";
            // 
            // txtOrden
            // 
            txtOrden.Location = new Point(198, 100);
            txtOrden.Margin = new Padding(3, 4, 3, 4);
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(217, 27);
            txtOrden.TabIndex = 2;
            // 
            // cmbPago
            // 
            cmbPago.FormattingEnabled = true;
            cmbPago.Location = new Point(198, 273);
            cmbPago.Margin = new Padding(3, 4, 3, 4);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(217, 28);
            cmbPago.TabIndex = 4;
            // 
            // cmbTienda
            // 
            cmbTienda.FormattingEnabled = true;
            cmbTienda.Location = new Point(198, 156);
            cmbTienda.Margin = new Padding(3, 4, 3, 4);
            cmbTienda.Name = "cmbTienda";
            cmbTienda.Size = new Size(217, 28);
            cmbTienda.TabIndex = 1;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(198, 216);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(217, 27);
            dtpFecha.TabIndex = 2;
            // 
            // btnPedido
            // 
            btnPedido.BackColor = SystemColors.ControlDark;
            btnPedido.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnPedido.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnPedido.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnPedido.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnPedido.FlatStyle = FlatStyle.Flat;
            btnPedido.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPedido.Location = new Point(198, 331);
            btnPedido.Margin = new Padding(3, 4, 3, 4);
            btnPedido.Name = "btnPedido";
            btnPedido.Size = new Size(217, 31);
            btnPedido.TabIndex = 34;
            btnPedido.Text = "Agregar libros";
            btnPedido.UseVisualStyleBackColor = false;
            btnPedido.Click += btnPedido_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 341);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 35;
            label2.Text = "Pedido";
            // 
            // FormAgregarVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 494);
            Controls.Add(label2);
            Controls.Add(btnPedido);
            Controls.Add(dtpFecha);
            Controls.Add(cmbTienda);
            Controls.Add(cmbPago);
            Controls.Add(txtOrden);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label3);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormAgregarVenta";
            Padding = new Padding(21, 80, 21, 20);
            Text = "FormAgregarVenta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private Label label3;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox2;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private Label label8;
        private NumericUpDown numericUpDown2;
        private TextBox txtOrden;
        private ComboBox cmbPago;
        private ComboBox cmbTienda;
        private DateTimePicker dtpFecha;
        private Button btnPedido;
        private Label label2;
    }
}