namespace ExamenTopicos
{
    partial class FormDescuentos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDescuentos));
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            dgvDescuentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(485, 67);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 23);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(13, 67);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(466, 23);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvDescuentos
            // 
            dgvDescuentos.AllowUserToAddRows = false;
            dgvDescuentos.AllowUserToDeleteRows = false;
            dgvDescuentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDescuentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDescuentos.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDescuentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDescuentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDescuentos.Location = new Point(13, 107);
            dgvDescuentos.Name = "dgvDescuentos";
            dgvDescuentos.ReadOnly = true;
            dgvDescuentos.RowHeadersVisible = false;
            dgvDescuentos.RowHeadersWidth = 51;
            dgvDescuentos.Size = new Size(577, 253);
            dgvDescuentos.TabIndex = 4;
            // 
            // FormDescuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 376);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvDescuentos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDescuentos";
            Text = "Descuentos";
            Load += FormDescuentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private TextBox txtBuscar;
        private DataGridView dgvDescuentos;
    }
}