﻿namespace ExamenTopicos
{
    partial class FormPublisher
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
            dgvEditoriales = new DataGridView();
            txtBuscar = new TextBox();
            label1 = new Label();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // dgvEditoriales
            // 
            dgvEditoriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Location = new Point(38, 79);
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.Size = new Size(577, 253);
            dgvEditoriales.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(186, 34);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(429, 23);
            txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 37);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 2;
            label1.Text = "Buscar editoriales";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(540, 368);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormPublisher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 450);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvEditoriales);
            Name = "FormPublisher";
            Text = "FormPublisher";
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEditoriales;
        private TextBox txtBuscar;
        private Label label1;
        private Button btnAgregar;
    }
}