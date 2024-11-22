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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutorTitulo));
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
            dgvAutoresTitulos.Location = new Point(20, 60);
            dgvAutoresTitulos.MultiSelect = false;
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.ReadOnly = true;
            dgvAutoresTitulos.RowHeadersVisible = false;
            dgvAutoresTitulos.RowHeadersWidth = 51;
            dgvAutoresTitulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutoresTitulos.Size = new Size(760, 284);
            dgvAutoresTitulos.TabIndex = 0;
            dgvAutoresTitulos.CellContentClick += dgvAutoresTitulos_CellContentClick;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(118, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(117, 22);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 354);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvAutoresTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAutorTitulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autores y Títulos";
            Load += FormAutorTitulo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}