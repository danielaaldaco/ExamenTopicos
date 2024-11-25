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
            txtBuscar.Location = new Point(12, 20);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(848, 27);
            txtBuscar.TabIndex = 15;
            // 
            // dgvInfoEdi
            // 
            dgvInfoEdi.AllowUserToAddRows = false;
            dgvInfoEdi.AllowUserToDeleteRows = false;
            dgvInfoEdi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInfoEdi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfoEdi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfoEdi.Location = new Point(12, 58);
            dgvInfoEdi.MultiSelect = false;
            dgvInfoEdi.Name = "dgvInfoEdi";
            dgvInfoEdi.ReadOnly = true;
            dgvInfoEdi.RowHeadersVisible = false;
            dgvInfoEdi.RowHeadersWidth = 51;
            dgvInfoEdi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvInfoEdi.Size = new Size(940, 509);
            dgvInfoEdi.TabIndex = 14;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(866, 20);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 16;
            btnAgregar.Text = "Agregar ";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormInfoEditorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 579);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvInfoEdi);
            Margin = new Padding(3, 4, 3, 4);
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