namespace ExamenTopicos
{
    partial class FormTitles
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTitles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarTituloToolStripMenuItem;

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
            dgvTitles = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarTituloToolStripMenuItem = new ToolStripMenuItem();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTitles).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTitles
            // 
            dgvTitles.AllowUserToAddRows = false;
            dgvTitles.AllowUserToDeleteRows = false;
            dgvTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTitles.ContextMenuStrip = contextMenuStrip1;
            dgvTitles.Location = new Point(12, 50);
            dgvTitles.Name = "dgvTitles";
            dgvTitles.ReadOnly = true;
            dgvTitles.RowHeadersWidth = 51;
            dgvTitles.RowTemplate.Height = 24;
            dgvTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTitles.Size = new Size(1513, 350);
            dgvTitles.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarTituloToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(160, 28);
            // 
            // editarTituloToolStripMenuItem
            // 
            editarTituloToolStripMenuItem.Name = "editarTituloToolStripMenuItem";
            editarTituloToolStripMenuItem.Size = new Size(159, 24);
            editarTituloToolStripMenuItem.Text = "Editar Título";
            editarTituloToolStripMenuItem.Click += editarTituloToolStripMenuItem_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 420);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar Título";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FormTitles
            // 
            ClientSize = new Size(1532, 455);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTitles);
            Name = "FormTitles";
            Text = "Gestión de Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvTitles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
