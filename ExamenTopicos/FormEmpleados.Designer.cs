namespace ExamenTopicos
{
    partial class FormEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmpleados));
            dgvEmpleados = new DataGridView();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(16, 77);
            dgvEmpleados.Margin = new Padding(5);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.Size = new Size(892, 453);
            dgvEmpleados.TabIndex = 0;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(16, 23);
            txtBuscar.Margin = new Padding(5);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(782, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(808, 23);
            btnAgregar.Margin = new Padding(5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(101, 27);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
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
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 544);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEmpleados);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "FormEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Empleados";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}
    