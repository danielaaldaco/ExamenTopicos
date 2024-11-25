namespace ExamenTopicos
{
    partial class FormRegalias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtBuscar = new TextBox();
            dgvRegalias = new DataGridView();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegalias).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(12, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(600, 27);
            txtBuscar.TabIndex = 0;
            // 
            // dgvRegalias
            // 
            dgvRegalias.AllowUserToAddRows = false;
            dgvRegalias.AllowUserToDeleteRows = false;
            dgvRegalias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegalias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegalias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegalias.Location = new Point(12, 47);
            dgvRegalias.MultiSelect = false;
            dgvRegalias.Name = "dgvRegalias";
            dgvRegalias.ReadOnly = true;
            dgvRegalias.RowHeadersWidth = 51;
            dgvRegalias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegalias.Size = new Size(760, 332);
            dgvRegalias.TabIndex = 1;
            dgvRegalias.CellContentClick += dgvRegalias_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(630, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 29);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormRegalias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 390);
            Controls.Add(btnAgregar);
            Controls.Add(dgvRegalias);
            Controls.Add(txtBuscar);
            Name = "FormRegalias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Regalías";
            ((System.ComponentModel.ISupportInitialize)dgvRegalias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvRegalias;
        private System.Windows.Forms.Button btnAgregar;
    }
}