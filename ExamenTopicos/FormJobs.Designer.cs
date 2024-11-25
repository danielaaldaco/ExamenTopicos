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
            dgvPuestos = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarPuestoToolStripMenuItem = new ToolStripMenuItem();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPuestos
            // 
            dgvPuestos.AllowUserToAddRows = false;
            dgvPuestos.AllowUserToDeleteRows = false;
            dgvPuestos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.ContextMenuStrip = contextMenuStrip1;
            dgvPuestos.GridColor = SystemColors.MenuBar;
            dgvPuestos.Location = new Point(14, 48);
            dgvPuestos.Margin = new Padding(3, 4, 3, 4);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.RowHeadersVisible = false;
            dgvPuestos.RowHeadersWidth = 51;
            dgvPuestos.Size = new Size(754, 392);
            dgvPuestos.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarPuestoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(70, 26);
            // 
            // eliminarPuestoToolStripMenuItem
            // 
            eliminarPuestoToolStripMenuItem.Name = "eliminarPuestoToolStripMenuItem";
            eliminarPuestoToolStripMenuItem.Size = new Size(69, 22);
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(684, 13);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 27);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(14, 13);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(665, 27);
            txtBuscar.TabIndex = 6;
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPuestos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormJobs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Puestos";
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPuestos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarPuestoToolStripMenuItem;
        private TextBox txtBuscar;
    }
}