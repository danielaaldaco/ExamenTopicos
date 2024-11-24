namespace ExamenTopicos
{
    partial class FormJobs
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No modifique el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobs));
            txtBuscar = new TextBox();
            dgvPuestos = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarPuestoToolStripMenuItem = new ToolStripMenuItem();
            btnAgregar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(60, 16);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(449, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvPuestos
            // 
            dgvPuestos.AllowUserToAddRows = false;
            dgvPuestos.AllowUserToDeleteRows = false;
            dgvPuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.ContextMenuStrip = contextMenuStrip1;
            dgvPuestos.GridColor = SystemColors.MenuBar;
            dgvPuestos.Location = new Point(12, 55);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.RowHeadersVisible = false;
            dgvPuestos.RowHeadersWidth = 51;
            dgvPuestos.Size = new Size(557, 235);
            dgvPuestos.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarPuestoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(68, 26);
            // 
            // eliminarPuestoToolStripMenuItem
            // 
            eliminarPuestoToolStripMenuItem.Name = "eliminarPuestoToolStripMenuItem";
            eliminarPuestoToolStripMenuItem.Size = new Size(67, 22);
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(494, 305);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Buscar";
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 342);
            Controls.Add(label1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPuestos);
            Controls.Add(txtBuscar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormJobs";
            Text = "Puestos";
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvPuestos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarPuestoToolStripMenuItem;
    }
}