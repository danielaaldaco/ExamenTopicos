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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutorTitulo));
            dgvAutoresTitulos = new DataGridView();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
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
            dgvAutoresTitulos.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAutoresTitulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutoresTitulos.Location = new Point(20, 110);
            dgvAutoresTitulos.MultiSelect = false;
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.ReadOnly = true;
            dgvAutoresTitulos.RowHeadersVisible = false;
            dgvAutoresTitulos.RowHeadersWidth = 51;
            dgvAutoresTitulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutoresTitulos.Size = new Size(760, 344);
            dgvAutoresTitulos.TabIndex = 0;
            dgvAutoresTitulos.CellContentClick += dgvAutoresTitulos_CellContentClick;
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
            btnAgregar.Location = new Point(630, 68);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 25);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(23, 68);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(601, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
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
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 464);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvAutoresTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAutorTitulo";
            Text = "Autores y Títulos";
            Load += FormAutorTitulo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}