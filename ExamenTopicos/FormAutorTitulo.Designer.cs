namespace ExamenTopicos
{
    partial class FormAutorTitulo
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
            dgvAutoresTitulos = new DataGridView();
            txtBuscar = new TextBox();
            label1 = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).BeginInit();
            SuspendLayout();
            // 
            // dgvAutoresTitulos
            // 
            dgvAutoresTitulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutoresTitulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutoresTitulos.Location = new Point(49, 85);
            dgvAutoresTitulos.Name = "dgvAutoresTitulos";
            dgvAutoresTitulos.Size = new Size(585, 268);
            dgvAutoresTitulos.TabIndex = 0;
            dgvAutoresTitulos.CellContentClick += dgvAutoresTitulos_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(218, 40);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(416, 23);
            txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 48);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 2;
            label1.Text = "Buscar autor o titulo";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(559, 388);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(456, 388);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // FormAutorTitulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvAutoresTitulos);
            Name = "FormAutorTitulo";
            Text = "FormAutorTitulo";
            ((System.ComponentModel.ISupportInitialize)dgvAutoresTitulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAutoresTitulos;
        private TextBox txtBuscar;
        private Label label1;
        private Button btnAgregar;
        private Button btnEditar;
    }
}