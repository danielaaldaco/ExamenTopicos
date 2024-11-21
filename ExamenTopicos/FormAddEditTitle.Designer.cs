namespace ExamenTopicos
{
    partial class FormAddEditTitle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitleId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.ComboBox cmbPubId;
        private System.Windows.Forms.DateTimePicker dtpPubDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.TextBox txtRoyalty;
        private System.Windows.Forms.TextBox txtYtdSales;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTitleId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPubId;
        private System.Windows.Forms.Label lblPubDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAdvance;
        private System.Windows.Forms.Label lblRoyalty;
        private System.Windows.Forms.Label lblYtdSales;
        private System.Windows.Forms.Label lblNotes;

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
        /// Método requerido para el Diseñador de Windows Forms.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitleId = new TextBox();
            txtTitle = new TextBox();
            txtType = new TextBox();
            cmbPubId = new ComboBox();
            dtpPubDate = new DateTimePicker();
            txtPrice = new TextBox();
            txtAdvance = new TextBox();
            txtRoyalty = new TextBox();
            txtYtdSales = new TextBox();
            txtNotes = new TextBox();
            btnGuardar = new Button();
            lblTitleId = new Label();
            lblTitle = new Label();
            lblType = new Label();
            lblPubId = new Label();
            lblPubDate = new Label();
            lblPrice = new Label();
            lblAdvance = new Label();
            lblRoyalty = new Label();
            lblYtdSales = new Label();
            lblNotes = new Label();
            SuspendLayout();
            // 
            // txtTitleId
            // 
            txtTitleId.Location = new Point(177, 20);
            txtTitleId.Name = "txtTitleId";
            txtTitleId.ReadOnly = true;
            txtTitleId.Size = new Size(200, 27);
            txtTitleId.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(177, 60);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 27);
            txtTitle.TabIndex = 3;
            // 
            // txtType
            // 
            txtType.Location = new Point(177, 100);
            txtType.Name = "txtType";
            txtType.Size = new Size(200, 27);
            txtType.TabIndex = 5;
            // 
            // cmbPubId
            // 
            cmbPubId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPubId.Location = new Point(177, 140);
            cmbPubId.Name = "cmbPubId";
            cmbPubId.Size = new Size(200, 28);
            cmbPubId.TabIndex = 7;
            // 
            // dtpPubDate
            // 
            dtpPubDate.Location = new Point(177, 180);
            dtpPubDate.Name = "dtpPubDate";
            dtpPubDate.Size = new Size(200, 27);
            dtpPubDate.TabIndex = 9;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(177, 220);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 11;
            // 
            // txtAdvance
            // 
            txtAdvance.Location = new Point(177, 260);
            txtAdvance.Name = "txtAdvance";
            txtAdvance.Size = new Size(200, 27);
            txtAdvance.TabIndex = 13;
            // 
            // txtRoyalty
            // 
            txtRoyalty.Location = new Point(177, 300);
            txtRoyalty.Name = "txtRoyalty";
            txtRoyalty.Size = new Size(200, 27);
            txtRoyalty.TabIndex = 15;
            // 
            // txtYtdSales
            // 
            txtYtdSales.Location = new Point(177, 340);
            txtYtdSales.Name = "txtYtdSales";
            txtYtdSales.Size = new Size(200, 27);
            txtYtdSales.TabIndex = 17;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(177, 380);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(200, 60);
            txtNotes.TabIndex = 19;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(177, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblTitleId
            // 
            lblTitleId.AutoSize = true;
            lblTitleId.Location = new Point(20, 20);
            lblTitleId.Name = "lblTitleId";
            lblTitleId.Size = new Size(57, 20);
            lblTitleId.TabIndex = 0;
            lblTitleId.Text = "Title ID";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(47, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Título";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(20, 100);
            lblType.Name = "lblType";
            lblType.Size = new Size(39, 20);
            lblType.TabIndex = 4;
            lblType.Text = "Tipo";
            // 
            // lblPubId
            // 
            lblPubId.AutoSize = true;
            lblPubId.Location = new Point(20, 140);
            lblPubId.Name = "lblPubId";
            lblPubId.Size = new Size(65, 20);
            lblPubId.TabIndex = 6;
            lblPubId.Text = "Editorial";
            // 
            // lblPubDate
            // 
            lblPubDate.AutoSize = true;
            lblPubDate.Location = new Point(20, 180);
            lblPubDate.Name = "lblPubDate";
            lblPubDate.Size = new Size(148, 20);
            lblPubDate.TabIndex = 8;
            lblPubDate.Text = "Fecha de Publicación";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 220);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(50, 20);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Precio";
            // 
            // lblAdvance
            // 
            lblAdvance.AutoSize = true;
            lblAdvance.Location = new Point(20, 260);
            lblAdvance.Name = "lblAdvance";
            lblAdvance.Size = new Size(70, 20);
            lblAdvance.TabIndex = 12;
            lblAdvance.Text = "Adelanto";
            // 
            // lblRoyalty
            // 
            lblRoyalty.AutoSize = true;
            lblRoyalty.Location = new Point(20, 300);
            lblRoyalty.Name = "lblRoyalty";
            lblRoyalty.Size = new Size(65, 20);
            lblRoyalty.TabIndex = 14;
            lblRoyalty.Text = "Regalías";
            // 
            // lblYtdSales
            // 
            lblYtdSales.AutoSize = true;
            lblYtdSales.Location = new Point(20, 340);
            lblYtdSales.Name = "lblYtdSales";
            lblYtdSales.Size = new Size(83, 20);
            lblYtdSales.TabIndex = 16;
            lblYtdSales.Text = "Ventas YTD";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(20, 380);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(48, 20);
            lblNotes.TabIndex = 18;
            lblNotes.Text = "Notas";
            // 
            // FormAddEditTitle
            // 
            ClientSize = new Size(389, 493);
            Controls.Add(lblTitleId);
            Controls.Add(txtTitleId);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblType);
            Controls.Add(txtType);
            Controls.Add(lblPubId);
            Controls.Add(cmbPubId);
            Controls.Add(lblPubDate);
            Controls.Add(dtpPubDate);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblAdvance);
            Controls.Add(txtAdvance);
            Controls.Add(lblRoyalty);
            Controls.Add(txtRoyalty);
            Controls.Add(lblYtdSales);
            Controls.Add(txtYtdSales);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(btnGuardar);
            Name = "FormAddEditTitle";
            Text = "Agregar/Editar Título";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
