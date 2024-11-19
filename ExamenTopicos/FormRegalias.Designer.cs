namespace ExamenTopicos
{
    partial class FormRegalias
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
            txtBuscar = new TextBox();
            dgvRegalias = new DataGridView();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegalias).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(36, 56);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(83, 15);
            lblBuscar.TabIndex = 8;
            lblBuscar.Text = "Buscar regalia:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(125, 54);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(311, 23);
            txtBuscar.TabIndex = 6;
            // 
            // dgvRegalias
            // 
            dgvRegalias.AllowUserToAddRows = false;
            dgvRegalias.AllowUserToDeleteRows = false;
            dgvRegalias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegalias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegalias.Location = new Point(38, 93);
            dgvRegalias.Margin = new Padding(3, 2, 3, 2);
            dgvRegalias.MultiSelect = false;
            dgvRegalias.Name = "dgvRegalias";
            dgvRegalias.ReadOnly = true;
            dgvRegalias.RowHeadersWidth = 51;
            dgvRegalias.RowTemplate.Height = 29;
            dgvRegalias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegalias.Size = new Size(519, 262);
            dgvRegalias.TabIndex = 5;
            dgvRegalias.CellContentClick += dgvRegalias_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(482, 56);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // FormRegalias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 399);
            Controls.Add(btnAgregar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvRegalias);
            Name = "FormRegalias";
            Text = "FormRegalias";
            Load += FormRegalias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegalias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvRegalias;
        private Button btnAgregar;
    }
}