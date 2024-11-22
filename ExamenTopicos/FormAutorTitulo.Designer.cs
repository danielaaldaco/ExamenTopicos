// FormAutorTitulo.Designer.cs
using System.Windows.Forms;
using System.Drawing;

namespace ExamenTopicos
{
    partial class FormAutorTitulo
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvAutoresTitulos;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarToolStripMenuItem;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método requerido para el Diseñador de Windows Forms.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvAutoresTitulos = new DataGridView();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAutoresTitulos
            // 
            dgvAutoresTitulos.AllowUserToAddRows = false;
            dgvAutoresTitulos.AllowUserToDeleteRows = false;
            dgvAutoresTitulos.AllowUserToResizeRows = false;
            dgvAutoresTitulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutoresTitulos.Location = new Point(23, 80);
            dgvAutoresTitulos.Margin = new Padding(3, 4, 3, 4);
            dgvAutoresTitulos.MultiSelect = false;
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.ReadOnly = true;
            dgvAutoresTitulos.RowHeadersVisible = false;
            dgvAutoresTitulos.RowHeadersWidth = 51;
            dgvAutoresTitulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutoresTitulos.Size = new Size(869, 379);
            dgvAutoresTitulos.TabIndex = 0;
            dgvAutoresTitulos.CellContentClick += dgvAutoresTitulos_CellContentClick;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(133, 28);
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(132, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 472);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvAutoresTitulos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAutorTitulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autores y Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}