namespace ExamenTopicos
{
    partial class FormVentas
    {
        private System.ComponentModel.IContainer components = null;

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
            dgvVentas = new DataGridView();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AllowUserToResizeRows = false;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(23, 80);
            dgvVentas.Margin = new Padding(3, 4, 3, 4);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(869, 379);
            dgvVentas.TabIndex = 0;
            dgvVentas.CellContentClick += dgvVentas_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(801, 33);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(91, 27);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Venta";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Location = new Point(23, 33);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(753, 27);
            txtBuscar.TabIndex = 2;
            txtBuscar.Text = "Buscar por Tienda, Orden, Título...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 472);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvVentas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}