﻿namespace ExamenTopicos
{
    partial class FormAgregarJob
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
            components = new System.ComponentModel.Container();
            label2 = new Label();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            label5 = new Label();
            nudMax = new NumericUpDown();
            nudMin = new NumericUpDown();
            errorProvider2 = new ErrorProvider(components);
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 79);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 24);
            label3.Name = "label3";
            label3.Size = new Size(407, 15);
            label3.TabIndex = 4;
            label3.Text = "Favor de rellenar los campos correspondientes para agregar el nuevo puesto";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(117, 71);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(255, 23);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.Validating += txtDescripcion_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 122);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Nivel minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 168);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 8;
            label5.Text = "Nivel máximo";
            // 
            // nudMax
            // 
            nudMax.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudMax.Location = new Point(117, 168);
            nudMax.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            nudMax.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            nudMax.Name = "nudMax";
            nudMax.Size = new Size(120, 23);
            nudMax.TabIndex = 3;
            nudMax.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // nudMin
            // 
            nudMin.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudMin.Location = new Point(117, 120);
            nudMin.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudMin.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMin.Name = "nudMin";
            nudMin.Size = new Size(120, 23);
            nudMin.TabIndex = 2;
            nudMin.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(221, 230);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(339, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarJob
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 284);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudMin);
            Controls.Add(nudMax);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDescripcion);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormAgregarJob";
            Text = "FormAgregarJob";
            Load += FormAgregarJob_Load;
            ((System.ComponentModel.ISupportInitialize)nudMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private Label label5;
        private NumericUpDown nudMax;
        private NumericUpDown nudMin;
        private ErrorProvider errorProvider2;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}