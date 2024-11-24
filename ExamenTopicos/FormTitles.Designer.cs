// FormTitles.Designer.cs
using System.Windows.Forms;
using System.Drawing;

namespace ExamenTopicos
{
    partial class FormTitles
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvTitles;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarTituloToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;

        /// <summary>
        /// Método requerido para el Diseñador de Windows Forms.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTitles));
            dgvTitles = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarTituloToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTitles).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTitles
            // 
            dgvTitles.AllowUserToAddRows = false;
            dgvTitles.AllowUserToDeleteRows = false;
            dgvTitles.AllowUserToResizeRows = false;
            dgvTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTitles.ContextMenuStrip = contextMenuStrip1;
            dgvTitles.Location = new Point(23, 80);
            dgvTitles.Margin = new Padding(3, 4, 3, 4);
            dgvTitles.MultiSelect = false;
            dgvTitles.Name = "dgvTitles";
            dgvTitles.ReadOnly = true;
            dgvTitles.RowHeadersVisible = false;
            dgvTitles.RowHeadersWidth = 51;
            dgvTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTitles.Size = new Size(869, 507);
            dgvTitles.TabIndex = 0;
            dgvTitles.CellContentClick += dgvTitles_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarTituloToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 52);
            // 
            // editarTituloToolStripMenuItem
            // 
            editarTituloToolStripMenuItem.Name = "editarTituloToolStripMenuItem";
            editarTituloToolStripMenuItem.Size = new Size(174, 24);
            editarTituloToolStripMenuItem.Text = "Editar Título";
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(174, 24);
            eliminarToolStripMenuItem.Text = "Eliminar Título";
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(800, 27);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(91, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(91, 33);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(685, 27);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(23, 37);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(55, 20);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar:";
            // 
            // FormTitles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 613);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTitles);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTitles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvTitles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}