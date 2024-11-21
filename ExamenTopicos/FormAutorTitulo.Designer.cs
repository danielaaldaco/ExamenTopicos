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
            dgvAutoresTitulos = new DataGridView();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).BeginInit();
            SuspendLayout();
            // 
            // dgvAutoresTitulos
            // 
            dgvAutoresTitulos.AllowUserToAddRows = false;
            dgvAutoresTitulos.AllowUserToDeleteRows = false;
            dgvAutoresTitulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutoresTitulos.Location = new Point(12, 77);
            dgvAutoresTitulos.Margin = new Padding(3, 2, 3, 2);
            dgvAutoresTitulos.MultiSelect = false;
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.ReadOnly = true;
            dgvAutoresTitulos.RowHeadersWidth = 51;
            dgvAutoresTitulos.RowTemplate.Height = 29;
            dgvAutoresTitulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutoresTitulos.Size = new Size(519, 262);
            dgvAutoresTitulos.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(79, 38);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(263, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(443, 32);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(88, 33);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(10, 40);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 4;
            lblBuscar.Text = "Buscar:";
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 365);
            Controls.Add(lblBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvAutoresTitulos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormAutorTitulo";
            Text = "Autores y Títulos";
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
