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
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(26, 84);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
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
            btnCancelar.Location = new Point(267, 415);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(157, 31);
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
            btnTerminarCompra.Location = new Point(26, 415);
            btnTerminarCompra.Margin = new Padding(3, 4, 3, 4);
            btnTerminarCompra.Name = "btnTerminarCompra";
            btnTerminarCompra.Size = new Size(170, 31);
            btnTerminarCompra.TabIndex = 33;
            btnTerminarCompra.Text = "Aceptar compra";
            btnTerminarCompra.UseVisualStyleBackColor = false;
            btnTerminarCompra.Click += btnTerminarCompra_Click;
            // 
            // FormEditarV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 470);
            Controls.Add(btnCancelar);
            Controls.Add(btnTerminarCompra);
            Controls.Add(dgvCarrito);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormEditarV";
            Padding = new Padding(23, 80, 23, 27);
            Text = "Editar compra";
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvCarrito;
        private Button btnCancelar;
        private Button btnTerminarCompra;
    }
}