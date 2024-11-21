namespace ExamenTopicos
{
    partial class FormInfoEditorial
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
            btnAgregar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvInfoEdi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInfoEdi).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(505, 371);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 17;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(59, 46);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(147, 15);
            lblBuscar.TabIndex = 16;
            lblBuscar.Text = "Buscar detalles de editorial";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(212, 43);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(368, 23);
            txtBuscar.TabIndex = 15;
            // 
            // dgvInfoEdi
            // 
            dgvInfoEdi.AllowUserToAddRows = false;
            dgvInfoEdi.AllowUserToDeleteRows = false;
            dgvInfoEdi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfoEdi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfoEdi.Location = new Point(61, 88);
            dgvInfoEdi.Margin = new Padding(3, 2, 3, 2);
            dgvInfoEdi.MultiSelect = false;
            dgvInfoEdi.Name = "dgvInfoEdi";
            dgvInfoEdi.ReadOnly = true;
            dgvInfoEdi.RowHeadersWidth = 51;
            dgvInfoEdi.RowTemplate.Height = 29;
            dgvInfoEdi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInfoEdi.Size = new Size(519, 262);
            dgvInfoEdi.TabIndex = 14;
            // 
            // FormInfoEditorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(btnAgregar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvInfoEdi);
            Name = "FormInfoEditorial";
            Text = "FormInfoEditorial";
            ((System.ComponentModel.ISupportInitialize)dgvInfoEdi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvInfoEdi;
    }
}