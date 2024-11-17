namespace ExamenTopicos
{
    partial class FormJobs
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
            textBox1 = new TextBox();
            button1 = new Button();
            dgvPuestos = new DataGridView();
            button2 = new Button();
            Column1 = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(356, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(447, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvPuestos
            // 
            dgvPuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dgvPuestos.Location = new Point(36, 112);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.Size = new Size(486, 235);
            dgvPuestos.TabIndex = 2;
            dgvPuestos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(437, 403);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Agregar";
            button2.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Image = Properties.Resources.eliminar;
            Column1.Name = "Column1";
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 450);
            Controls.Add(button2);
            Controls.Add(dgvPuestos);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "FormJobs";
            Text = "Puestos";
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private DataGridView dgvPuestos;
        private Button button2;
        private DataGridViewImageColumn Column1;
    }
}