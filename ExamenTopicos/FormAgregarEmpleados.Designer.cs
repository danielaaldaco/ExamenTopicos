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
            lblIdEmpleado = new Label();
            mskIdEmpleado = new MaskedTextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblInicial = new Label();
            mskInicialSNombre = new MaskedTextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblPuesto = new Label();
            cmbPuesto = new ComboBox();
            lblNivel = new Label();
            nudNivel = new NumericUpDown();
            lblEditorial = new Label();
            cmbEditorial = new ComboBox();
            lblFechaContratacion = new Label();
            dtpFecha = new DateTimePicker();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudNivel).BeginInit();
            SuspendLayout();
            // 
            // lblIdEmpleado
            // 
            lblIdEmpleado.AutoSize = true;
            lblIdEmpleado.Location = new Point(16, 23);
            lblIdEmpleado.Margin = new Padding(4, 0, 4, 0);
            lblIdEmpleado.Name = "lblIdEmpleado";
            lblIdEmpleado.Size = new Size(99, 20);
            lblIdEmpleado.TabIndex = 0;
            lblIdEmpleado.Text = "ID Empleado:";
            // 
            // mskIdEmpleado
            // 
            mskIdEmpleado.Location = new Point(160, 18);
            mskIdEmpleado.Margin = new Padding(4, 5, 4, 5);
            mskIdEmpleado.Name = "mskIdEmpleado";
            mskIdEmpleado.Size = new Size(132, 27);
            mskIdEmpleado.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(16, 69);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(160, 65);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(265, 27);
            txtNombre.TabIndex = 3;
            // 
            // lblInicial
            // 
            lblInicial.AutoSize = true;
            lblInicial.Location = new Point(16, 115);
            lblInicial.Margin = new Padding(4, 0, 4, 0);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(51, 20);
            lblInicial.TabIndex = 4;
            lblInicial.Text = "Inicial:";
            // 
            // mskInicialSNombre
            // 
            mskInicialSNombre.Location = new Point(160, 111);
            mskInicialSNombre.Margin = new Padding(4, 5, 4, 5);
            mskInicialSNombre.Mask = "A";
            mskInicialSNombre.Name = "mskInicialSNombre";
            mskInicialSNombre.Size = new Size(25, 27);
            mskInicialSNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(16, 162);
            lblApellido.Margin = new Padding(4, 0, 4, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(69, 20);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(160, 157);
            txtApellido.Margin = new Padding(4, 5, 4, 5);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(265, 27);
            txtApellido.TabIndex = 7;
            // 
            // lblPuesto
            // 
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(16, 208);
            lblPuesto.Margin = new Padding(4, 0, 4, 0);
            lblPuesto.Name = "lblPuesto";
            lblPuesto.Size = new Size(56, 20);
            lblPuesto.TabIndex = 8;
            lblPuesto.Text = "Puesto:";
            // 
            // cmbPuesto
            // 
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.FormattingEnabled = true;
            cmbPuesto.Location = new Point(160, 203);
            cmbPuesto.Margin = new Padding(4, 5, 4, 5);
            cmbPuesto.Name = "cmbPuesto";
            cmbPuesto.Size = new Size(265, 28);
            cmbPuesto.TabIndex = 9;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(16, 254);
            lblNivel.Margin = new Padding(4, 0, 4, 0);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(94, 20);
            lblNivel.TabIndex = 10;
            lblNivel.Text = "Nivel Puesto:";
            // 
            // nudNivel
            // 
            nudNivel.Location = new Point(160, 251);
            nudNivel.Margin = new Padding(4, 5, 4, 5);
            nudNivel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudNivel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNivel.Name = "nudNivel";
            nudNivel.Size = new Size(80, 27);
            nudNivel.TabIndex = 11;
            nudNivel.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(16, 300);
            lblEditorial.Margin = new Padding(4, 0, 4, 0);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(68, 20);
            lblEditorial.TabIndex = 12;
            lblEditorial.Text = "Editorial:";
            // 
            // cmbEditorial
            // 
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(160, 295);
            cmbEditorial.Margin = new Padding(4, 5, 4, 5);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(265, 28);
            cmbEditorial.TabIndex = 13;
            // 
            // lblFechaContratacion
            // 
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Location = new Point(16, 346);
            lblFechaContratacion.Margin = new Padding(4, 0, 4, 0);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(139, 20);
            lblFechaContratacion.TabIndex = 14;
            lblFechaContratacion.Text = "Fecha Contratación:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(160, 342);
            dtpFecha.Margin = new Padding(4, 5, 4, 5);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(132, 27);
            dtpFecha.TabIndex = 15;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(160, 400);
            btnAceptar.Margin = new Padding(4, 5, 4, 5);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(100, 35);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Agregar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(327, 400);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 463);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dtpFecha);
            Controls.Add(lblFechaContratacion);
            Controls.Add(cmbEditorial);
            Controls.Add(lblEditorial);
            Controls.Add(nudNivel);
            Controls.Add(lblNivel);
            Controls.Add(cmbPuesto);
            Controls.Add(lblPuesto);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(mskInicialSNombre);
            Controls.Add(lblInicial);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(mskIdEmpleado);
            Controls.Add(lblIdEmpleado);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormAgregarEmpleados";
            Text = "Agregar Empleado";
            ((System.ComponentModel.ISupportInitialize)nudNivel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.MaskedTextBox mskIdEmpleado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.MaskedTextBox mskInicialSNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.ComboBox cmbEditorial;
        private System.Windows.Forms.Label lblFechaContratacion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}