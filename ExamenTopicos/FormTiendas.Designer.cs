namespace ExamenTopicos
{
    partial class FormTiendas
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
            dgvTiendas = new DataGridView();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).BeginInit();
            SuspendLayout();
            // 
            // dgvTiendas
            // 
            dgvTiendas.AllowUserToAddRows = false;
            dgvTiendas.AllowUserToDeleteRows = false;
            dgvTiendas.AllowUserToResizeRows = false;
            dgvTiendas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiendas.Location = new Point(12, 80);
            dgvTiendas.Margin = new Padding(3, 4, 3, 4);
            dgvTiendas.MultiSelect = false;
            dgvTiendas.Name = "dgvTiendas";
            dgvTiendas.ReadOnly = true;
            dgvTiendas.RowHeadersVisible = false;
            dgvTiendas.RowHeadersWidth = 51;
            dgvTiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiendas.Size = new Size(988, 379);
            dgvTiendas.TabIndex = 0;
            dgvTiendas.CellContentClick += dgvTiendas_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(909, 33);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(91, 27);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Tienda";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Location = new Point(12, 33);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(891, 27);
            txtBuscar.TabIndex = 2;
            txtBuscar.Text = "Buscar por Nombre, Ciudad, Estado...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FormTiendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 472);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTiendas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTiendas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Tiendas";
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvTiendas;
        private Button btnAgregar;
        private TextBox txtBuscar;
    }
}