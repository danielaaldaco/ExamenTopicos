namespace ExamenTopicos
{
    partial class FormTiendas
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
            lblBuscar = new Label();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            dgvTiendas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(39, 45);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(78, 15);
            lblBuscar.TabIndex = 12;
            lblBuscar.Text = "Buscar tienda";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(537, 45);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(88, 27);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(128, 43);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(311, 23);
            txtBuscar.TabIndex = 10;
            // 
            // dgvTiendas
            // 
            dgvTiendas.AllowUserToAddRows = false;
            dgvTiendas.AllowUserToDeleteRows = false;
            dgvTiendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiendas.Location = new Point(39, 95);
            dgvTiendas.Margin = new Padding(3, 2, 3, 2);
            dgvTiendas.MultiSelect = false;
            dgvTiendas.Name = "dgvTiendas";
            dgvTiendas.ReadOnly = true;
            dgvTiendas.RowHeadersWidth = 51;
            dgvTiendas.RowTemplate.Height = 29;
            dgvTiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiendas.Size = new Size(598, 262);
            dgvTiendas.TabIndex = 9;
            // 
            // FormTiendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 420);
            Controls.Add(lblBuscar);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvTiendas);
            Name = "FormTiendas";
            Text = "FormTiendas";
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private DataGridView dgvTiendas;
    }
}