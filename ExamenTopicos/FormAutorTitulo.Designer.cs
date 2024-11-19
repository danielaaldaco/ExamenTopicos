using System.Windows.Forms;

namespace ExamenTopicos
{
    partial class FormAutorTitulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Componentes de la interfaz
        private DataGridView dgvAutoresTitulos;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem eliminarRegistroToolStripMenuItem;
        private Label lblBuscar;

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
        /// Método requerido para el soporte del Diseñador. No se debe modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvAutoresTitulos = new DataGridView();
            this.txtBuscar = new TextBox();
            this.btnAgregar = new Button();
            this.menuStrip1 = new MenuStrip();
            this.eliminarRegistroToolStripMenuItem = new ToolStripMenuItem();
            this.lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoresTitulos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAutoresTitulos
            // 
            this.dgvAutoresTitulos.AllowUserToAddRows = false;
            this.dgvAutoresTitulos.AllowUserToDeleteRows = false;
            this.dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutoresTitulos.Location = new System.Drawing.Point(12, 90);
            this.dgvAutoresTitulos.MultiSelect = false;
            this.dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            this.dgvAutoresTitulos.ReadOnly = true;
            this.dgvAutoresTitulos.RowHeadersWidth = 51;
            this.dgvAutoresTitulos.RowTemplate.Height = 29;
            this.dgvAutoresTitulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutoresTitulos.Size = new System.Drawing.Size(760, 350);
            this.dgvAutoresTitulos.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(90, 50);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 27);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(12, 53);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 20);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(672, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.eliminarRegistroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eliminarRegistroToolStripMenuItem
            // 
            this.eliminarRegistroToolStripMenuItem.Name = "eliminarRegistroToolStripMenuItem";
            this.eliminarRegistroToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.eliminarRegistroToolStripMenuItem.Text = "Eliminar Registro";
            // 
            // FormAutorTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvAutoresTitulos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAutorTitulo";
            this.Text = "Autores y Títulos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutoresTitulos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Nota: Los manejadores de eventos ya están asignados en el archivo principal FormAutorTitulo.cs
        }

        #endregion
    }
}
