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
            labelAutorId.Location = new Point(30, 40);
            labelAutorId.Name = "labelAutorId";
            labelAutorId.Size = new Size(93, 20);
            labelAutorId.TabIndex = 0;
            labelAutorId.Text = "ID del Autor:";
            // 
            // labelTituloId
            // 
            labelTituloId.AutoSize = true;
            labelTituloId.Location = new Point(30, 100);
            labelTituloId.Name = "labelTituloId";
            labelTituloId.Size = new Size(94, 20);
            labelTituloId.TabIndex = 1;
            labelTituloId.Text = "ID del Título:";
            // 
            // labelOrden
            // 
            labelOrden.AutoSize = true;
            labelOrden.Location = new Point(30, 160);
            labelOrden.Name = "labelOrden";
            labelOrden.Size = new Size(119, 20);
            labelOrden.TabIndex = 2;
            labelOrden.Text = "Orden del Autor:";
            // 
            // labelRegalia
            // 
            labelRegalia.AutoSize = true;
            labelRegalia.Location = new Point(30, 220);
            labelRegalia.Name = "labelRegalia";
            labelRegalia.Size = new Size(152, 20);
            labelRegalia.TabIndex = 3;
            labelRegalia.Text = "Regalía (% del título):";
            // 
            // txtAutorId
            // 
            txtAutorId.Location = new Point(170, 37);
            txtAutorId.Name = "txtAutorId";
            txtAutorId.Size = new Size(250, 27);
            txtAutorId.TabIndex = 4;
            // 
            // txtTituloId
            // 
            txtTituloId.Location = new Point(170, 97);
            txtTituloId.Name = "txtTituloId";
            txtTituloId.Size = new Size(250, 27);
            txtTituloId.TabIndex = 5;
            // 
            // nudOrden
            // 
            nudOrden.Location = new Point(170, 157);
            nudOrden.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudOrden.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(120, 27);
            nudOrden.TabIndex = 6;
            nudOrden.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudRegalia
            // 
            nudRegalia.Location = new Point(170, 217);
            nudRegalia.Name = "nudRegalia";
            nudRegalia.Size = new Size(120, 27);
            nudRegalia.TabIndex = 7;
            nudRegalia.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(220, 280);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(100, 30);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormAgregarAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 350);
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
