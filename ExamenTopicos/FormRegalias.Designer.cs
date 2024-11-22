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
            lblBuscar.Location = new Point(10, 20);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(105, 20);
            lblBuscar.TabIndex = 8;
            lblBuscar.Text = "Buscar regalia:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(112, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(355, 27);
            txtBuscar.TabIndex = 6;
            // 
            // dgvRegalias
            // 
            dgvRegalias.AllowUserToAddRows = false;
            dgvRegalias.AllowUserToDeleteRows = false;
            dgvRegalias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegalias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegalias.Location = new Point(12, 69);
            dgvRegalias.MultiSelect = false;
            dgvRegalias.Name = "dgvRegalias";
            dgvRegalias.ReadOnly = true;
            dgvRegalias.RowHeadersWidth = 51;
            dgvRegalias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegalias.Size = new Size(649, 349);
            dgvRegalias.TabIndex = 5;
            dgvRegalias.CellContentClick += dgvRegalias_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(543, 17);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // FormRegalias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 431);
            Controls.Add(btnAgregar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvRegalias);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegalias";
            Text = "FormRegalias";
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