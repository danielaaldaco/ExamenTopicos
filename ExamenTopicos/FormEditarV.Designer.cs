namespace ExamenTopicos
{
    partial class FormEditarV
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvCarrito = new DataGridView();
            btnCancelar = new Button();
            btnTerminarCompra = new Button();
            cmbPago = new ComboBox();
            label8 = new Label();
            lblOrden = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(27, 149);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(348, 239);
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
            btnCancelar.Location = new Point(238, 407);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 23);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
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
            btnTerminarCompra.Location = new Point(27, 407);
            btnTerminarCompra.Name = "btnTerminarCompra";
            btnTerminarCompra.Size = new Size(149, 23);
            btnTerminarCompra.TabIndex = 33;
            btnTerminarCompra.Text = "Aceptar compra";
            btnTerminarCompra.UseVisualStyleBackColor = false;
            btnTerminarCompra.Click += btnTerminarCompra_Click;
            // 
            // cmbPago
            // 
            cmbPago.FormattingEnabled = true;
            cmbPago.Location = new Point(185, 110);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(190, 23);
            cmbPago.TabIndex = 35;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 116);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 36;
            label8.Text = "Forma de pago";
            // 
            // lblOrden
            // 
            lblOrden.Location = new Point(27, 71);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(190, 24);
            lblOrden.TabIndex = 38;
            // 
            // FormEditarV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 482);
            Controls.Add(lblOrden);
            Controls.Add(cmbPago);
            Controls.Add(label8);
            Controls.Add(btnCancelar);
            Controls.Add(btnTerminarCompra);
            Controls.Add(dgvCarrito);
            MaximizeBox = false;
            Name = "FormEditarV";
            Resizable = false;
            Text = "Editar compra";
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvCarrito;
        private Button btnCancelar;
        private Button btnTerminarCompra;
        private ComboBox cmbPago;
        private Label label8;
        private Label lblOrden;
    }
}