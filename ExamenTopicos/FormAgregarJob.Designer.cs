namespace ExamenTopicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarJob));
            label2 = new Label();
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
            label2.Location = new Point(13, 71);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(104, 63);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(255, 23);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.Validating += txtDescripcion_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 114);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Nivel minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 160);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 8;
            label5.Text = "Nivel máximo";
            // 
            // nudMax
            // 
            nudMax.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudMax.Location = new Point(104, 160);
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
            nudMin.Location = new Point(104, 112);
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
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(85, 213);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(203, 213);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarJob
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 259);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(nudMin);
            Controls.Add(nudMax);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAgregarJob";
            Text = "Agregar puesto";
            ((System.ComponentModel.ISupportInitialize)nudMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
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