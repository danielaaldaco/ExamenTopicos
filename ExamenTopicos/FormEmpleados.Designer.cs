namespace ExamenTopicos
{
    partial class FormEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmpleados));
            dgvEmpleados = new DataGridView();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmpleados.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(14, 96);
            dgvEmpleados.Margin = new Padding(4, 4, 4, 4);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.Size = new Size(780, 343);
            dgvEmpleados.TabIndex = 0;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(13, 65);
            txtBuscar.Margin = new Padding(4, 4, 4, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(612, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAgregar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(643, 65);
            btnAgregar.Margin = new Padding(4, 4, 4, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(151, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 449);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEmpleados);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormEmpleados";
            Padding = new Padding(18, 45, 18, 15);
            Text = "Gestión de Empleados";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnAgregar;
    }
}
    