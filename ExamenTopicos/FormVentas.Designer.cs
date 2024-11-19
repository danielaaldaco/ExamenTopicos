namespace ExamenTopicos
{
    partial class FormVentas
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
            dgvVentas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(554, 387);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 47);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 7;
            label1.Text = "Buscar venta";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(141, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(488, 23);
            txtBuscar.TabIndex = 6;
            // 
            // dgvVentas
            // 
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(44, 84);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(585, 268);
            dgvVentas.TabIndex = 5;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 450);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvVentas);
            Name = "FormVentas";
            Text = "FormVentas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label label1;
        private TextBox txtBuscar;
        private DataGridView dgvVentas;
    }
}