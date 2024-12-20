﻿namespace ExamenTopicos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            cmbTitulo.Location = new Point(207, 85);
            cmbTitulo.Margin = new Padding(3, 4, 3, 4);
            cmbTitulo.Name = "cmbTitulo";
            cmbTitulo.Size = new Size(217, 28);
            cmbTitulo.TabIndex = 26;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(207, 139);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(217, 27);
            txtCantidad.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 147);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 28;
            label4.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 93);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(47, 20);
            label2.TabIndex = 27;
            label2.Text = "Título";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(26, 249);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(398, 284);
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
            btnCancelar.Location = new Point(314, 577);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 31);
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
            btnTerminarCompra.Location = new Point(26, 577);
            btnTerminarCompra.Margin = new Padding(3, 4, 3, 4);
            btnTerminarCompra.Name = "btnTerminarCompra";
            btnTerminarCompra.Size = new Size(143, 31);
            btnTerminarCompra.TabIndex = 33;
            btnTerminarCompra.Text = "Aceptar compra";
            btnTerminarCompra.UseVisualStyleBackColor = false;
            btnTerminarCompra.Click += btnTerminarCompra_Click;
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
            btnAgregarCarrito.Location = new Point(207, 199);
            btnAgregarCarrito.Margin = new Padding(3, 4, 3, 4);
            btnAgregarCarrito.Name = "btnAgregarCarrito";
            btnAgregarCarrito.Size = new Size(217, 31);
            btnAgregarCarrito.TabIndex = 35;
            btnAgregarCarrito.Text = "Agregar al carrito";
            btnAgregarCarrito.UseVisualStyleBackColor = false;
            btnAgregarCarrito.Click += btnAgregarCarrito_Click;
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 685);
            Controls.Add(btnAgregarCarrito);
            Controls.Add(btnCancelar);
            Controls.Add(btnTerminarCompra);
            Controls.Add(dgvCarrito);
            Controls.Add(cmbTitulo);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(label2);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormCarrito";
            Padding = new Padding(23, 80, 23, 27);
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