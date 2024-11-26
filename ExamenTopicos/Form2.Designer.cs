namespace ExamenTopicos
{
    partial class FormCarrito
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
            txtCantidad = new TextBox();
            label4 = new Label();
            label2 = new Label();
            dgvCarrito = new DataGridView();
            btnCancelar = new Button();
            btnTerminarCompra = new Button();
            btnAgregarCarrito = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // cmbTitulo
            // 
            cmbTitulo.FormattingEnabled = true;
            cmbTitulo.Location = new Point(181, 64);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(190, 23);
            cmbTitulo.TabIndex = 26;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(181, 104);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(190, 23);
            txtCantidad.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 110);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 28;
            label4.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 70);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(37, 15);
            label2.TabIndex = 27;
            label2.Text = "Título";
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(23, 187);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(348, 213);
            dgvCarrito.TabIndex = 32;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(275, 433);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 23);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnTerminarCompra
            // 
            btnTerminarCompra.BackColor = SystemColors.ControlDark;
            btnTerminarCompra.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnTerminarCompra.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnTerminarCompra.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnTerminarCompra.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnTerminarCompra.FlatStyle = FlatStyle.Flat;
            btnTerminarCompra.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTerminarCompra.Location = new Point(23, 433);
            btnTerminarCompra.Name = "btnTerminarCompra";
            btnTerminarCompra.Size = new Size(125, 23);
            btnTerminarCompra.TabIndex = 33;
            btnTerminarCompra.Text = "Aceptar compra";
            btnTerminarCompra.UseVisualStyleBackColor = false;
            btnTerminarCompra.Click += btnTerminarCompra_Click_1;
            // 
            // btnAgregarCarrito
            // 
            btnAgregarCarrito.BackColor = SystemColors.ControlDark;
            btnAgregarCarrito.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregarCarrito.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAgregarCarrito.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregarCarrito.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregarCarrito.FlatStyle = FlatStyle.Flat;
            btnAgregarCarrito.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarCarrito.Location = new Point(181, 149);
            btnAgregarCarrito.Name = "btnAgregarCarrito";
            btnAgregarCarrito.Size = new Size(190, 23);
            btnAgregarCarrito.TabIndex = 35;
            btnAgregarCarrito.Text = "Agregar al carrito";
            btnAgregarCarrito.UseVisualStyleBackColor = false;
            btnAgregarCarrito.Click += btnAgregarCarrito_Click_1;
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 514);
            Controls.Add(btnAgregarCarrito);
            Controls.Add(btnCancelar);
            Controls.Add(btnTerminarCompra);
            Controls.Add(dgvCarrito);
            Controls.Add(cmbTitulo);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(label2);
            Name = "FormCarrito";
            Text = "Agregar compra";
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTitulo;
        private TextBox txtCantidad;
        private Label label4;
        private Label label2;
        private DataGridView dgvCarrito;
        private Button btnCancelar;
        private Button btnTerminarCompra;
        private Button btnAgregarCarrito;
    }
}