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
            txtBuscar = new TextBox();
            dgvPuestos = new DataGridView();
            columnaEliminar = new DataGridViewImageColumn();
            btnAgregar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtBuscar.Location = new Point(144, 51);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(378, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // dgvPuestos
            // 
            dgvPuestos.AllowUserToAddRows = false;
            dgvPuestos.AllowUserToDeleteRows = false;
            dgvPuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPuestos.Columns.AddRange(new DataGridViewColumn[] { columnaEliminar });
            dgvPuestos.Location = new Point(36, 112);
            dgvPuestos.Name = "dgvPuestos";
            dgvPuestos.ReadOnly = true;
            dgvPuestos.Size = new Size(557, 235);
            dgvPuestos.TabIndex = 2;
            dgvPuestos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // columnaEliminar
            // 
            columnaEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            columnaEliminar.HeaderText = "Eliminar";
            columnaEliminar.Image = Properties.Resources.eliminar;
            columnaEliminar.Name = "columnaEliminar";
            columnaEliminar.ReadOnly = true;
            columnaEliminar.Resizable = DataGridViewTriState.False;
            columnaEliminar.Width = 56;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(518, 389);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 54);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Buscar puesto";
            // 
            // FormJobs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 450);
            Controls.Add(label1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPuestos);
            Controls.Add(txtBuscar);
            Name = "FormJobs";
            Text = "Puestos";
            Load += FormJobs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPuestos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private DataGridView dgvPuestos;
        private Button btnAgregar;
        private Label label1;
        private DataGridViewImageColumn columnaEliminar;
    }
}