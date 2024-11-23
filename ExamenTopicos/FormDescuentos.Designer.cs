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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDescuentos));
            btnAgregar = new Button();
            label1 = new Label();
            txtBuscar = new TextBox();
            dgvDescuentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(514, 325);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 18);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 6;
            label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(77, 15);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(429, 23);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvDescuentos
            // 
            dgvDescuentos.AllowUserToAddRows = false;
            dgvDescuentos.AllowUserToDeleteRows = false;
            dgvDescuentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDescuentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDescuentos.Location = new Point(12, 55);
            dgvDescuentos.Name = "dgvDescuentos";
            dgvDescuentos.ReadOnly = true;
            dgvDescuentos.Size = new Size(577, 253);
            dgvDescuentos.TabIndex = 4;
            // 
            // FormDescuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 363);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtBuscar;
        private DataGridView dgvDescuentos;
    }
}