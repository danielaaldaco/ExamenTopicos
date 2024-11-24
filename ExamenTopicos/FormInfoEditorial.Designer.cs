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
            txtBuscar = new TextBox();
            dgvInfoEdi = new DataGridView();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInfoEdi).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(23, 15);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(368, 23);
            txtBuscar.TabIndex = 15;
            // 
            // dgvInfoEdi
            // 
            dgvInfoEdi.AllowUserToAddRows = false;
            dgvInfoEdi.AllowUserToDeleteRows = false;
            dgvInfoEdi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInfoEdi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfoEdi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfoEdi.Location = new Point(23, 56);
            dgvInfoEdi.Margin = new Padding(3, 2, 3, 2);
            dgvInfoEdi.MultiSelect = false;
            dgvInfoEdi.Name = "dgvInfoEdi";
            dgvInfoEdi.ReadOnly = true;
            dgvInfoEdi.RowHeadersVisible = false;
            dgvInfoEdi.RowHeadersWidth = 51;
            dgvInfoEdi.RowTemplate.Height = 29;
            dgvInfoEdi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvInfoEdi.Size = new Size(519, 262);
            dgvInfoEdi.TabIndex = 14;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(467, 15);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 16;
            btnAgregar.Text = "Agregar ";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // FormInfoEditorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 341);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvInfoEdi);
            Name = "FormInfoEditorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInfoEditorial";
            ((System.ComponentModel.ISupportInitialize)dgvInfoEdi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBuscar;
        private DataGridView dgvInfoEdi;
        private Button btnAgregar;
    }
}