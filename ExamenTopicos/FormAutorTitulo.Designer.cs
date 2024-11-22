// FormAutorTitulo.Designer.cs
namespace ExamenTopicos
{
    partial class FormAutorTitulo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvAutoresTitulos;

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            dgvAutoresTitulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(572, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 27);
            txtBuscar.TabIndex = 2;
            // 
            // dgvAutoresTitulos
            // 
            dgvAutoresTitulos.AllowUserToAddRows = false;
            dgvAutoresTitulos.AllowUserToDeleteRows = false;
            dgvAutoresTitulos.AllowUserToResizeRows = false;
            dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutoresTitulos.Location = new Point(12, 62);
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.ReadOnly = true;
            dgvAutoresTitulos.RowHeadersWidth = 51;
            dgvAutoresTitulos.Size = new Size(635, 350);
            dgvAutoresTitulos.TabIndex = 3;
            dgvAutoresTitulos.CellContentClick += dgvAutoresTitulos_CellContentClick;
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 424);
            Controls.Add(dgvAutoresTitulos);
            Controls.Add(txtBuscar);
            Controls.Add(btnAgregar);
            Name = "FormAutorTitulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autores y Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
    