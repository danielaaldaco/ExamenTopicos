namespace ExamenTopicos
{
    partial class FormAgregarInfo
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
            txtDetalles = new TextBox();
            label3 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnImagen = new Button();
            label2 = new Label();
            picBox = new PictureBox();
            label4 = new Label();
            cmbEditorial = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // txtDetalles
            // 
            txtDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtDetalles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDetalles.Location = new Point(139, 156);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.ScrollBars = ScrollBars.Vertical;
            txtDetalles.Size = new Size(256, 162);
            txtDetalles.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 156);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(94, 15);
            label3.TabIndex = 37;
            label3.Text = "Detalles editorial";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 65);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 36;
            label1.Text = "ID Editorial";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnCancelar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(208, 338);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAceptar.BackColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.BorderColor = SystemColors.ControlDark;
            btnAceptar.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatAppearance.MouseOverBackColor = SystemColors.InactiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(95, 338);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 40;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImagen
            // 
            btnImagen.Location = new Point(139, 106);
            btnImagen.Name = "btnImagen";
            btnImagen.Size = new Size(256, 23);
            btnImagen.TabIndex = 43;
            btnImagen.Text = "Subir imagen";
            btnImagen.UseVisualStyleBackColor = true;
            btnImagen.Click += btnImagen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 110);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 44;
            label2.Text = "Logo de editorial";
            // 
            // picBox
            // 
            picBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picBox.ErrorImage = Properties.Resources.edit;
            picBox.Image = Properties.Resources.PLUS;
            picBox.Location = new Point(443, 92);
            picBox.Name = "picBox";
            picBox.Size = new Size(256, 226);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 45;
            picBox.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(443, 60);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(150, 15);
            label4.TabIndex = 47;
            label4.Text = "Previsualización de imagen";
            // 
            // cmbEditorial
            // 
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(139, 62);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(255, 23);
            cmbEditorial.TabIndex = 48;
            // 
            // FormAgregarInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 373);
            Controls.Add(cmbEditorial);
            Controls.Add(label4);
            Controls.Add(picBox);
            Controls.Add(label2);
            Controls.Add(btnImagen);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDetalles);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FormAgregarInfo";
            Text = "Editar detalles";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDetalles;
        private Label label3;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
        private OpenFileDialog openFileDialog1;
        private Button btnImagen;
        private Label label2;
        private PictureBox picBox;
        private Label label4;
        private ComboBox cmbEditorial;
    }
}