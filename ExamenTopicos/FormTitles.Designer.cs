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
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarTituloToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;

        /// <summary>
        /// Método requerido para el Diseñador de Windows Forms.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTitles));
            dgvTitles = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarTituloToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
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
            dgvTitles.AllowUserToResizeRows = false;
            dgvTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTitles.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTitles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTitles.ContextMenuStrip = contextMenuStrip1;
            dgvTitles.Location = new Point(19, 105);
            dgvTitles.MultiSelect = false;
            dgvTitles.Name = "dgvTitles";
            dgvTitles.ReadOnly = true;
            dgvTitles.RowHeadersVisible = false;
            dgvTitles.RowHeadersWidth = 51;
            dgvTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTitles.Size = new Size(760, 337);
            dgvTitles.TabIndex = 0;
            dgvTitles.CellContentClick += dgvTitles_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
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
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(646, 64);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(133, 25);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(21, 66);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(603, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FormTitles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTitles);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTitles";
            Padding = new Padding(18, 45, 18, 15);
            Text = "Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvTitles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}