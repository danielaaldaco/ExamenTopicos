namespace ExamenTopicos
{
    partial class FormAutores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutores));
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            dgvAutores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAgregar.Location = new Point(707, 77);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(157, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BackColor = Color.FromArgb(242, 242, 242);
            txtBuscar.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBuscar.Location = new Point(12, 80);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(670, 23);
            txtBuscar.TabIndex = 5;
            // 
            // dgvAutores
            // 
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dgvAutores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAutores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutores.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAutores.Location = new Point(12, 122);
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersVisible = false;
            dgvAutores.Size = new Size(852, 299);
            dgvAutores.TabIndex = 4;
            // 
            // FormAutores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 442);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvAutores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAutores";
            Text = "Autores";
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private TextBox txtBuscar;
        private DataGridView dgvAutores;
    }
}