﻿namespace ExamenTopicos
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
            txtBuscar = new System.Windows.Forms.TextBox();
            dgvPuestos = new System.Windows.Forms.DataGridView();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            eliminarPuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnAgregar = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(dgvPuestos)).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new System.Drawing.Point(165, 68);
            txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(513, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged; // Conectado al manejador principal
            // 
            // dgvPuestos
            // 
            dgvPuestos.AllowUserToAddRows = false;
            dgvPuestos.AllowUserToDeleteRows = false;
            dgvPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.ContextMenuStrip = contextMenuStrip1;
            dgvPuestos.GridColor = System.Drawing.SystemColors.MenuBar;
            dgvPuestos.Location = new System.Drawing.Point(41, 149);
            dgvPuestos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.RowHeadersWidth = 51;
            dgvPuestos.Size = new System.Drawing.Size(637, 313);
            dgvPuestos.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { eliminarPuestoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(182, 28);
            // 
            // eliminarPuestoToolStripMenuItem
            // 
            eliminarPuestoToolStripMenuItem.Name = "eliminarPuestoToolStripMenuItem";
            eliminarPuestoToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            eliminarPuestoToolStripMenuItem.Text = "Eliminar puesto";
            eliminarPuestoToolStripMenuItem.Click += eliminarPuestoToolStripMenuItem_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new System.Drawing.Point(592, 519);
            btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(86, 31);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(41, 72);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 20);
            label1.TabIndex = 4;
            label1.Text = "Buscar puesto";
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(741, 600);
            Controls.Add(label1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPuestos);
            Controls.Add(txtBuscar);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FormJobs";
            Text = "Puestos";
            Load += FormJobs_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvPuestos)).EndInit();
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
