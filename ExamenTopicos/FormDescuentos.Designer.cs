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
            btnAgregar = new Button();
            label1 = new Label();
            txtBuscar = new TextBox();
            dgvEditoriales = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(531, 375);
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
            label1.Location = new Point(29, 44);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 6;
            label1.Text = "Buscar descuentos";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(177, 41);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(429, 23);
            txtBuscar.TabIndex = 5;
            // 
            // dgvEditoriales
            // 
            dgvEditoriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Location = new Point(29, 86);
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.Size = new Size(577, 253);
            dgvEditoriales.TabIndex = 4;
            // 
            // FormDescuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 450);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEditoriales);
            Name = "FormDescuentos";
            Text = "FormDescuentos";
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label label1;
        private TextBox txtBuscar;
        private DataGridView dgvEditoriales;
    }
}