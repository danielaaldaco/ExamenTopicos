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
            dgvTitles.Location = new Point(20, 60);
            dgvTitles.MultiSelect = false;
            dgvTitles.Name = "dgvTitles";
            dgvTitles.ReadOnly = true;
            dgvTitles.RowHeadersVisible = false;
            dgvTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTitles.Size = new Size(760, 380);
            dgvTitles.TabIndex = 0;
            dgvTitles.CellContentClick += dgvTitles_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarTituloToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(151, 48);
            // 
            // editarTituloToolStripMenuItem
            // 
            editarTituloToolStripMenuItem.Name = "editarTituloToolStripMenuItem";
            editarTituloToolStripMenuItem.Size = new Size(150, 22);
            editarTituloToolStripMenuItem.Text = "Editar Título";
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(150, 22);
            eliminarToolStripMenuItem.Text = "Eliminar Título";
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(700, 20);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(80, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(80, 25);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(600, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 28);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar:";
            // 
            // FormTitles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTitles);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTitles";
            Text = "Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvTitles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}