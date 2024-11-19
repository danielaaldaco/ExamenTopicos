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
            cmbEditorial = new ComboBox();
            txtOrden = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cmbEditorial
            // 
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(161, 86);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(121, 23);
            cmbEditorial.TabIndex = 39;
            // 
            // txtOrden
            // 
            txtOrden.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrden.Location = new Point(161, 126);
            txtOrden.Name = "txtOrden";
            txtOrden.Size = new Size(256, 23);
            txtOrden.TabIndex = 35;
            // 
            // label5
            // 
            label5.Location = new Point(36, 30);
            label5.Name = "label5";
            label5.Size = new Size(497, 38);
            label5.TabIndex = 38;
            label5.Text = "Favor de rellene los campos correspondientes para agregar los detalles de la editorial";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 129);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(94, 15);
            label3.TabIndex = 37;
            label3.Text = "Detalles editorial";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 89);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 36;
            label1.Text = "ID Tienda";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(435, 190);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(322, 190);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 23);
            btnAceptar.TabIndex = 40;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FormAgregarInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 241);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbEditorial);
            Controls.Add(txtOrden);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FormAgregarInfo";
            Text = "FormAgregarInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEditorial;
        private TextBox txtOrden;
        private Label label5;
        private Label label3;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}