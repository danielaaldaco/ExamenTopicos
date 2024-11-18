namespace ExamenTopicos
{
    partial class FormJobs
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
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtBuscar.Location = new Point(144, 51);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(449, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // dgvPuestos
            // 
            dgvPuestos.AllowUserToAddRows = false;
            dgvPuestos.AllowUserToDeleteRows = false;
            dgvPuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.ContextMenuStrip = contextMenuStrip1;
            dgvPuestos.GridColor = SystemColors.MenuBar;
            dgvPuestos.Location = new Point(36, 112);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.Size = new Size(557, 235);
            dgvPuestos.TabIndex = 2;
            dgvPuestos.CellContentClick += dataGridView1_CellContentClick;
            dgvPuestos.RowValidated += dgvPuestos_RowValidated;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarPuestoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(157, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // eliminarPuestoToolStripMenuItem
            // 
            eliminarPuestoToolStripMenuItem.Name = "eliminarPuestoToolStripMenuItem";
            eliminarPuestoToolStripMenuItem.Size = new Size(156, 22);
            eliminarPuestoToolStripMenuItem.Text = "Eliminar puesto";
            eliminarPuestoToolStripMenuItem.Click += eliminarPuestoToolStripMenuItem_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(518, 389);
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
            label1.Location = new Point(36, 54);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Buscar puesto";
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 450);
            Controls.Add(label1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPuestos);
            Controls.Add(txtBuscar);
            Name = "FormJobs";
            Text = "Puestos";
            Load += FormJobs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private DataGridView dgvPuestos;
        private Button btnAgregar;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarPuestoToolStripMenuItem;
    }
}