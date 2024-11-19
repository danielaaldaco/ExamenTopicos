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
            btnAgregar = new Button();
            label1 = new Label();
            txtBuscar = new TextBox();
            dgvEmpleados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(546, 373);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 42);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 10;
            label1.Text = "Buscar empleados";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(192, 39);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(429, 23);
            txtBuscar.TabIndex = 9;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(44, 84);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.Size = new Size(577, 253);
            dgvEmpleados.TabIndex = 8;
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 450);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEmpleados);
            Name = "FormEmpleados";
            Text = "FormEmpleados";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label label1;
        private TextBox txtBuscar;
        private DataGridView dgvEmpleados;
    }
}