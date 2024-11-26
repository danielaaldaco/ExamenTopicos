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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtBuscar = new TextBox();
            dgvRegalias = new DataGridView();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegalias).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(10, 64);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(494, 23);
            txtBuscar.TabIndex = 0;
            // 
            // dgvRegalias
            // 
            dgvRegalias.AllowUserToAddRows = false;
            dgvRegalias.AllowUserToDeleteRows = false;
            dgvRegalias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegalias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegalias.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRegalias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRegalias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegalias.Location = new Point(10, 103);
            dgvRegalias.Margin = new Padding(3, 2, 3, 2);
            dgvRegalias.MultiSelect = false;
            dgvRegalias.Name = "dgvRegalias";
            dgvRegalias.ReadOnly = true;
            dgvRegalias.RowHeadersWidth = 51;
            dgvRegalias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegalias.Size = new Size(665, 330);
            dgvRegalias.TabIndex = 1;
            dgvRegalias.CellContentClick += dgvRegalias_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(510, 64);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(165, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormRegalias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 441);
            Controls.Add(btnAgregar);
            Controls.Add(dgvRegalias);
            Controls.Add(txtBuscar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormRegalias";
            Padding = new Padding(18, 45, 18, 15);
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