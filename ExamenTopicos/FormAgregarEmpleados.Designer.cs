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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarEmpleados));
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
            lblIdEmpleado.Location = new Point(14, 17);
            lblIdEmpleado.Margin = new Padding(4, 0, 4, 0);
            lblIdEmpleado.Name = "lblIdEmpleado";
            lblIdEmpleado.Size = new Size(77, 15);
            lblIdEmpleado.TabIndex = 0;
            lblIdEmpleado.Text = "ID Empleado:";
            // 
            // mskIdEmpleado
            // 
            mskIdEmpleado.Location = new Point(140, 14);
            mskIdEmpleado.Margin = new Padding(4);
            mskIdEmpleado.Name = "mskIdEmpleado";
            mskIdEmpleado.Size = new Size(116, 23);
            mskIdEmpleado.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(14, 52);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 49);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(232, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblInicial
            // 
            lblInicial.AutoSize = true;
            lblInicial.Location = new Point(14, 86);
            lblInicial.Margin = new Padding(4, 0, 4, 0);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(41, 15);
            lblInicial.TabIndex = 4;
            lblInicial.Text = "Inicial:";
            // 
            // mskInicialSNombre
            // 
            mskInicialSNombre.Location = new Point(140, 83);
            mskInicialSNombre.Margin = new Padding(4);
            mskInicialSNombre.Mask = "A";
            mskInicialSNombre.Name = "mskInicialSNombre";
            mskInicialSNombre.Size = new Size(22, 23);
            mskInicialSNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(14, 122);
            lblApellido.Margin = new Padding(4, 0, 4, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(140, 118);
            txtApellido.Margin = new Padding(4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(232, 23);
            txtApellido.TabIndex = 7;
            // 
            // lblPuesto
            // 
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(14, 156);
            lblPuesto.Margin = new Padding(4, 0, 4, 0);
            lblPuesto.Name = "lblPuesto";
            lblPuesto.Size = new Size(46, 15);
            lblPuesto.TabIndex = 8;
            lblPuesto.Text = "Puesto:";
            // 
            // cmbPuesto
            // 
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuesto.FormattingEnabled = true;
            cmbPuesto.Location = new Point(140, 152);
            cmbPuesto.Margin = new Padding(4);
            cmbPuesto.Name = "cmbPuesto";
            cmbPuesto.Size = new Size(232, 23);
            cmbPuesto.TabIndex = 9;
            cmbPuesto.SelectedIndexChanged += cmbPuesto_SelectedIndexChanged;
            cmbPuesto.Click += cmbPuesto_Click;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(14, 190);
            lblNivel.Margin = new Padding(4, 0, 4, 0);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(76, 15);
            lblNivel.TabIndex = 10;
            lblNivel.Text = "Nivel Puesto:";
            // 
            // nudNivel
            // 
            nudNivel.Location = new Point(140, 188);
            nudNivel.Margin = new Padding(4);
            nudNivel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudNivel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNivel.Name = "nudNivel";
            nudNivel.Size = new Size(70, 23);
            nudNivel.TabIndex = 11;
            nudNivel.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(14, 225);
            lblEditorial.Margin = new Padding(4, 0, 4, 0);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(53, 15);
            lblEditorial.TabIndex = 12;
            lblEditorial.Text = "Editorial:";
            // 
            // cmbEditorial
            // 
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(140, 221);
            cmbEditorial.Margin = new Padding(4);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(232, 23);
            cmbEditorial.TabIndex = 13;
            // 
            // lblFechaContratacion
            // 
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Location = new Point(14, 260);
            lblFechaContratacion.Margin = new Padding(4, 0, 4, 0);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(113, 15);
            lblFechaContratacion.TabIndex = 14;
            lblFechaContratacion.Text = "Fecha Contratación:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(140, 256);
            dtpFecha.Margin = new Padding(4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(116, 23);
            dtpFecha.TabIndex = 15;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(140, 300);
            btnAceptar.Margin = new Padding(4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(88, 26);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Agregar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(286, 300);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 26);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 347);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormAgregarEmpleados";
            Text = "Agregar Empleado";
            Shown += FormAgregarEmpleados_Shown_1;
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