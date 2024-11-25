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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            dgvTiendas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTiendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiendas.Location = new Point(11, 113);
            dgvTiendas.MultiSelect = false;
            dgvTiendas.Name = "dgvTiendas";
            dgvTiendas.ReadOnly = true;
            dgvTiendas.RowHeadersVisible = false;
            dgvTiendas.RowHeadersWidth = 51;
            dgvTiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiendas.Size = new Size(864, 379);
            dgvTiendas.TabIndex = 0;
            dgvTiendas.CellContentClick += dgvTiendas_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(715, 72);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(160, 24);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Location = new Point(9, 73);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(681, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.Text = "Buscar por Nombre, Ciudad, Estado...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FormTiendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 501);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTiendas);
            Name = "FormTiendas";
            Padding = new Padding(18, 60, 18, 15);
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