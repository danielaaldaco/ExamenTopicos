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
            txtBuscar = new TextBox();
            dgvDescuentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(587, 24);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 27);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(14, 20);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(567, 27);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvDescuentos
            // 
            dgvDescuentos.AllowUserToAddRows = false;
            dgvDescuentos.AllowUserToDeleteRows = false;
            dgvDescuentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDescuentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDescuentos.Location = new Point(14, 73);
            dgvDescuentos.Margin = new Padding(3, 4, 3, 4);
            dgvDescuentos.Name = "dgvDescuentos";
            dgvDescuentos.ReadOnly = true;
            dgvDescuentos.RowHeadersVisible = false;
            dgvDescuentos.RowHeadersWidth = 51;
            dgvDescuentos.Size = new Size(659, 337);
            dgvDescuentos.TabIndex = 4;
            // 
            // FormDescuentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 428);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvDescuentos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDescuentos";
            StartPosition = FormStartPosition.CenterScreen;
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