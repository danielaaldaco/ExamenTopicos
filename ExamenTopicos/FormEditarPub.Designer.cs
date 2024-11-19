namespace ExamenTopicos
{
    partial class FormEditarPub
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.Label lblPubId;
        private System.Windows.Forms.TextBox txtPubId;
        private System.Windows.Forms.Label lblPubName;
        private System.Windows.Forms.TextBox txtPubName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se debe modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPubId = new System.Windows.Forms.Label();
            this.txtPubId = new System.Windows.Forms.TextBox();
            this.lblPubName = new System.Windows.Forms.Label();
            this.txtPubName = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPubId
            // 
            this.lblPubId.AutoSize = true;
            this.lblPubId.Location = new System.Drawing.Point(30, 20);
            this.lblPubId.Name = "lblPubId";
            this.lblPubId.Size = new System.Drawing.Size(57, 15);
            this.lblPubId.TabIndex = 0;
            this.lblPubId.Text = "ID Editorial";
            // 
            // txtPubId
            // 
            this.txtPubId.Location = new System.Drawing.Point(150, 17);
            this.txtPubId.Name = "txtPubId";
            this.txtPubId.ReadOnly = true; // Campo de solo lectura
            this.txtPubId.Size = new System.Drawing.Size(200, 23);
            this.txtPubId.TabIndex = 1;
            // 
            // lblPubName
            // 
            this.lblPubName.AutoSize = true;
            this.lblPubName.Location = new System.Drawing.Point(30, 60);
            this.lblPubName.Name = "lblPubName";
            this.lblPubName.Size = new System.Drawing.Size(49, 15);
            this.lblPubName.TabIndex = 2;
            this.lblPubName.Text = "Nombre";
            // 
            // txtPubName
            // 
            this.txtPubName.Location = new System.Drawing.Point(150, 57);
            this.txtPubName.Name = "txtPubName";
            this.txtPubName.Size = new System.Drawing.Size(200, 23);
            this.txtPubName.TabIndex = 3;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(30, 100);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(46, 15);
            this.lblCity.TabIndex = 4;
            this.lblCity.Text = "Ciudad";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(150, 97);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(200, 23);
            this.txtCity.TabIndex = 5;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(30, 140);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(42, 15);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "Estado";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(150, 137);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(200, 23);
            this.txtState.TabIndex = 7;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(30, 180);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(29, 15);
            this.lblCountry.TabIndex = 8;
            this.lblCountry.Text = "País";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(150, 177);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(200, 23);
            this.txtCountry.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(80, 230);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(200, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormEditarPub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtPubName);
            this.Controls.Add(this.lblPubName);
            this.Controls.Add(this.txtPubId);
            this.Controls.Add(this.lblPubId);
            this.Name = "FormEditarPub";
            this.Text = "Editar Editorial";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}