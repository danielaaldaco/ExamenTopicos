namespace ExamenTopicos
{
    partial class FormEditoriales
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEditoriales;
        private System.Windows.Forms.TextBox txtBuscar;

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
            dgvEditoriales = new DataGridView();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // dgvEditoriales
            // 
            dgvEditoriales.AllowUserToAddRows = false;
            dgvEditoriales.AllowUserToDeleteRows = false;
            dgvEditoriales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEditoriales.BackgroundColor = Color.White;
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Location = new Point(10, 101);
            dgvEditoriales.Margin = new Padding(3, 2, 3, 2);
            dgvEditoriales.MultiSelect = false;
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.ReadOnly = true;
            dgvEditoriales.RowHeadersVisible = false;
            dgvEditoriales.RowHeadersWidth = 51;
            dgvEditoriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEditoriales.Size = new Size(663, 316);
            dgvEditoriales.TabIndex = 0;
            dgvEditoriales.CellContentClick += dgvEditoriales_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(9, 62);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.Size = new Size(537, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
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
            btnAgregar.Location = new Point(552, 62);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(121, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormEditoriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 426);
            Controls.Add(btnAgregar);
            Controls.Add(dgvEditoriales);
            Controls.Add(txtBuscar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormEditoriales";
            Text = "Gestión de Editoriales";
            Load += FormEditoriales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnAgregar;
    }
}