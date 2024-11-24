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
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Location = new Point(12, 50);
            dgvEditoriales.MultiSelect = false;
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.ReadOnly = true;
            dgvEditoriales.RowHeadersVisible = false;
            dgvEditoriales.RowHeadersWidth = 51;
            dgvEditoriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEditoriales.Size = new Size(758, 350);
            dgvEditoriales.TabIndex = 0;
            dgvEditoriales.CellContentClick += dgvEditoriales_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(12, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.Size = new Size(658, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(676, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 27);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormEditoriales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 412);
            Controls.Add(btnAgregar);
            Controls.Add(dgvEditoriales);
            Controls.Add(txtBuscar);
            Name = "FormEditoriales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Editoriales";
            Load += FormEditoriales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnAgregar;
    }
}