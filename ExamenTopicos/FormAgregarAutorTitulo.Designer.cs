namespace ExamenTopicos
{
    partial class FormAgregarAutorTitulo
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelAutorId;
        private Label labelTituloId;
        private Label labelOrden;
        private Label labelRegalia;
        private TextBox txtAutorId;
        private TextBox txtTituloId;
        private NumericUpDown nudOrden;
        private NumericUpDown nudRegalia;
        private Button btnAceptar;
        private Button btnCancelar;
        private ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarAutorTitulo));
            labelAutorId = new Label();
            labelTituloId = new Label();
            labelOrden = new Label();
            labelRegalia = new Label();
            txtAutorId = new TextBox();
            txtTituloId = new TextBox();
            nudOrden = new NumericUpDown();
            nudRegalia = new NumericUpDown();
            btnAceptar = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegalia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // labelAutorId
            // 
            labelAutorId.AutoSize = true;
            labelAutorId.Location = new Point(22, 75);
            labelAutorId.Name = "labelAutorId";
            labelAutorId.Size = new Size(73, 15);
            labelAutorId.TabIndex = 0;
            labelAutorId.Text = "ID del Autor:";
            // 
            // labelTituloId
            // 
            labelTituloId.AutoSize = true;
            labelTituloId.Location = new Point(22, 120);
            labelTituloId.Name = "labelTituloId";
            labelTituloId.Size = new Size(73, 15);
            labelTituloId.TabIndex = 1;
            labelTituloId.Text = "ID del Título:";
            // 
            // labelOrden
            // 
            labelOrden.AutoSize = true;
            labelOrden.Location = new Point(22, 165);
            labelOrden.Name = "labelOrden";
            labelOrden.Size = new Size(95, 15);
            labelOrden.TabIndex = 2;
            labelOrden.Text = "Orden del Autor:";
            // 
            // labelRegalia
            // 
            labelRegalia.AutoSize = true;
            labelRegalia.Location = new Point(22, 210);
            labelRegalia.Name = "labelRegalia";
            labelRegalia.Size = new Size(119, 15);
            labelRegalia.TabIndex = 3;
            labelRegalia.Text = "Regalía (% del título):";
            // 
            // txtAutorId
            // 
            txtAutorId.Location = new Point(145, 73);
            txtAutorId.Margin = new Padding(3, 2, 3, 2);
            txtAutorId.Name = "txtAutorId";
            txtAutorId.Size = new Size(219, 23);
            txtAutorId.TabIndex = 4;
            // 
            // txtTituloId
            // 
            txtTituloId.Location = new Point(145, 118);
            txtTituloId.Margin = new Padding(3, 2, 3, 2);
            txtTituloId.Name = "txtTituloId";
            txtTituloId.Size = new Size(219, 23);
            txtTituloId.TabIndex = 5;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(145, 163);
            nudOrden.Margin = new Padding(3, 2, 3, 2);
            nudOrden.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(105, 23);
            nudOrden.TabIndex = 6;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudRegalia
            // 
            nudRegalia.Location = new Point(145, 208);
            nudRegalia.Margin = new Padding(3, 2, 3, 2);
            nudRegalia.Name = "nudRegalia";
            nudRegalia.Size = new Size(105, 23);
            nudRegalia.TabIndex = 7;
            nudRegalia.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(91, 269);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(88, 22);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(197, 269);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 22);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormAgregarAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 326);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudRegalia);
            Controls.Add(nudOrden);
            Controls.Add(txtTituloId);
            Controls.Add(txtAutorId);
            Controls.Add(labelRegalia);
            Controls.Add(labelOrden);
            Controls.Add(labelTituloId);
            Controls.Add(labelAutorId);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FormAgregarAutorTitulo";
            Text = "Agregar Autor y Título";
            ((System.ComponentModel.ISupportInitialize)nudOrden).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegalia).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
