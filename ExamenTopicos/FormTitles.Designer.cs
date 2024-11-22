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
            this.components = new System.ComponentModel.Container();
            this.dgvTitles = new DataGridView();
            this.btnAgregar = new Button();
            this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.editarTituloToolStripMenuItem = new ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTitles
            // 
            this.dgvTitles.AllowUserToAddRows = false;
            this.dgvTitles.AllowUserToDeleteRows = false;
            this.dgvTitles.AllowUserToResizeRows = false;
            this.dgvTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.ContextMenuStrip = this.contextMenuStrip1; // Asignar el ContextMenuStrip
            this.dgvTitles.Location = new Point(20, 60);
            this.dgvTitles.MultiSelect = false;
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.RowHeadersVisible = false;
            this.dgvTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTitles.Size = new Size(760, 380);
            this.dgvTitles.TabIndex = 0;
            this.dgvTitles.CellContentClick += new DataGridViewCellEventHandler(this.dgvTitles_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                this.editarTituloToolStripMenuItem,
                this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(181, 70);
            // 
            // editarTituloToolStripMenuItem
            // 
            this.editarTituloToolStripMenuItem.Name = "editarTituloToolStripMenuItem";
            this.editarTituloToolStripMenuItem.Size = new Size(180, 22);
            this.editarTituloToolStripMenuItem.Text = "Editar Título";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new Size(180, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar Título";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAgregar.Location = new Point(700, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(80, 30);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtBuscar.Location = new Point(80, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(600, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new Point(20, 28);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(46, 15);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar:";
            // 
            // FormTitles
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 460);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvTitles);
            this.Name = "FormTitles";
            this.Text = "Títulos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}