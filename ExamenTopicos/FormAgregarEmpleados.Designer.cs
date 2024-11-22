namespace ExamenTopicos
{
    partial class FormAgregarEmpleados
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
            label6 = new Label();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            label10 = new Label();
            mskInicialSNombre = new MaskedTextBox();
            dtpFecha = new DateTimePicker();
            cmbPuesto = new ComboBox();
            label11 = new Label();
            label13 = new Label();
            nudNivel = new NumericUpDown();
            label14 = new Label();
            cmbEditorial = new ComboBox();
            label15 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblID = new Label();
            ((System.ComponentModel.ISupportInitialize)nudNivel).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 85);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 75;
            label6.Text = "ID Empleado";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(190, 208);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(194, 23);
            txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(191, 119);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 23);
            txtNombre.TabIndex = 2;
            // 
            // label5
            // 
            label5.Location = new Point(34, 22);
            label5.Name = "label5";
            label5.Size = new Size(502, 38);
            label5.TabIndex = 70;
            label5.Text = "Favor de rellene los campos correspondientes para agregar la información sobre el empleado";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 122);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(51, 15);
            label3.TabIndex = 69;
            label3.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 211);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 66;
            label1.Text = "Primer apellido";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 167);
            label10.Name = "label10";
            label10.Size = new Size(132, 15);
            label10.TabIndex = 78;
            label10.Text = "Inicial segundo nombre";
            // 
            // mskInicialSNombre
            // 
            mskInicialSNombre.Location = new Point(191, 164);
            mskInicialSNombre.Mask = "A";
            mskInicialSNombre.Name = "mskInicialSNombre";
            mskInicialSNombre.Size = new Size(45, 23);
            mskInicialSNombre.TabIndex = 3;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(574, 211);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 23);
            dtpFecha.TabIndex = 8;
            dtpFecha.Value = new DateTime(2024, 11, 19, 5, 51, 46, 0);
            // 
            // cmbPuesto
            // 
            cmbPuesto.FormattingEnabled = true;
            cmbPuesto.Location = new Point(570, 74);
            cmbPuesto.Name = "cmbPuesto";
            cmbPuesto.Size = new Size(121, 23);
            cmbPuesto.TabIndex = 5;
            cmbPuesto.SelectedIndexChanged += cmbPuesto_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(414, 217);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.Yes;
            label11.Size = new Size(124, 15);
            label11.TabIndex = 83;
            label11.Text = "Fecha de contratación";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(413, 77);
            label13.Name = "label13";
            label13.Size = new Size(57, 15);
            label13.TabIndex = 81;
            label13.Text = "ID Puesto";
            // 
            // nudNivel
            // 
            nudNivel.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudNivel.Location = new Point(574, 118);
            nudNivel.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            nudNivel.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudNivel.Name = "nudNivel";
            nudNivel.Size = new Size(120, 23);
            nudNivel.TabIndex = 6;
            nudNivel.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(414, 126);
            label14.Name = "label14";
            label14.Size = new Size(37, 15);
            label14.TabIndex = 87;
            label14.Text = "Nivel ";
            // 
            // cmbEditorial
            // 
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(574, 166);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(121, 23);
            cmbEditorial.TabIndex = 7;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(414, 169);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 88;
            label15.Text = "ID Editorial";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(690, 291);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(577, 291);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblID
            // 
            lblID.BackColor = Color.White;
            lblID.Location = new Point(190, 82);
            lblID.Name = "lblID";
            lblID.Size = new Size(194, 18);
            lblID.TabIndex = 89;
            // 
            // FormAgregarEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 326);
            Controls.Add(lblID);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbEditorial);
            Controls.Add(label15);
            Controls.Add(nudNivel);
            Controls.Add(label14);
            Controls.Add(dtpFecha);
            Controls.Add(cmbPuesto);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(mskInicialSNombre);
            Controls.Add(label10);
            Controls.Add(label6);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FormAgregarEmpleados";
            Text = "FormAgregarEmpleados";
            Load += FormAgregarEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)nudNivel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label5;
        private Label label3;
        private Label label1;
        private Label label10;
        private MaskedTextBox mskInicialSNombre;
        private DateTimePicker dtpFecha;
        private ComboBox cmbPuesto;
        private Label label11;
        private Label label13;
        private NumericUpDown nudNivel;
        private Label label14;
        private ComboBox cmbEditorial;
        private Label label15;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblID;
    }
}