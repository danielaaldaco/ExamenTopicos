using System.Windows.Forms; 
using System.Drawing;

namespace ExamenTopicos
{
    partial class FormAddEditTitle
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitleId;
        private TextBox txtTitleId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblPubId;
        private ComboBox cmbPubId;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblAdvance;
        private TextBox txtAdvance;
        private Label lblRoyalty;
        private TextBox txtRoyalty;
        private Label lblYtdSales;
        private TextBox txtYtdSales;
        private Label lblNotes;
        private TextBox txtNotes;
        private Label lblPubDate;
        private DateTimePicker dtpPubDate;
        private Button btnGuardar;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditTitle));
            lblTitleId = new Label();
            txtTitleId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            lblPubId = new Label();
            cmbPubId = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblAdvance = new Label();
            txtAdvance = new TextBox();
            lblRoyalty = new Label();
            txtRoyalty = new TextBox();
            lblYtdSales = new Label();
            txtYtdSales = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            lblPubDate = new Label();
            dtpPubDate = new DateTimePicker();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblTitleId
            // 
            lblTitleId.AutoSize = true;
            lblTitleId.Location = new Point(20, 20);
            lblTitleId.Name = "lblTitleId";
            lblTitleId.Size = new Size(51, 15);
            lblTitleId.TabIndex = 0;
            lblTitleId.Text = "ID Título";
            // 
            // txtTitleId
            // 
            txtTitleId.Location = new Point(177, 17);
            txtTitleId.Name = "txtTitleId";
            txtTitleId.ReadOnly = true;
            txtTitleId.Size = new Size(200, 23);
            txtTitleId.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(37, 15);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Título";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(177, 57);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(20, 100);
            lblType.Name = "lblType";
            lblType.Size = new Size(30, 15);
            lblType.TabIndex = 4;
            lblType.Text = "Tipo";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Ficción", "No Ficción", "Ciencia", "Historia", "Biografía", "Otro" });
            cmbType.Location = new Point(177, 97);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(200, 23);
            cmbType.TabIndex = 5;
            // 
            // lblPubId
            // 
            lblPubId.AutoSize = true;
            lblPubId.Font = new Font("Gadugi", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPubId.Location = new Point(20, 140);
            lblPubId.Name = "lblPubId";
            lblPubId.Size = new Size(50, 16);
            lblPubId.TabIndex = 6;
            lblPubId.Text = "Editorial";
            // 
            // cmbPubId
            // 
            cmbPubId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPubId.FormattingEnabled = true;
            cmbPubId.Location = new Point(177, 137);
            cmbPubId.Name = "cmbPubId";
            cmbPubId.Size = new Size(200, 23);
            cmbPubId.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 180);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(40, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(177, 177);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 9;
            // 
            // lblAdvance
            // 
            lblAdvance.AutoSize = true;
            lblAdvance.Location = new Point(20, 220);
            lblAdvance.Name = "lblAdvance";
            lblAdvance.Size = new Size(52, 15);
            lblAdvance.TabIndex = 10;
            lblAdvance.Text = "Anticipo";
            // 
            // txtAdvance
            // 
            txtAdvance.Location = new Point(177, 217);
            txtAdvance.Name = "txtAdvance";
            txtAdvance.Size = new Size(200, 23);
            txtAdvance.TabIndex = 11;
            // 
            // lblRoyalty
            // 
            lblRoyalty.AutoSize = true;
            lblRoyalty.Location = new Point(20, 260);
            lblRoyalty.Name = "lblRoyalty";
            lblRoyalty.Size = new Size(50, 15);
            lblRoyalty.TabIndex = 12;
            lblRoyalty.Text = "Regalías";
            // 
            // txtRoyalty
            // 
            txtRoyalty.Location = new Point(177, 257);
            txtRoyalty.Name = "txtRoyalty";
            txtRoyalty.Size = new Size(200, 23);
            txtRoyalty.TabIndex = 13;
            // 
            // lblYtdSales
            // 
            lblYtdSales.AutoSize = true;
            lblYtdSales.Location = new Point(20, 300);
            lblYtdSales.Name = "lblYtdSales";
            lblYtdSales.Size = new Size(104, 15);
            lblYtdSales.TabIndex = 14;
            lblYtdSales.Text = "Numeros a vender";
            // 
            // txtYtdSales
            // 
            txtYtdSales.Location = new Point(177, 297);
            txtYtdSales.Name = "txtYtdSales";
            txtYtdSales.Size = new Size(200, 23);
            txtYtdSales.TabIndex = 15;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(20, 340);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(38, 15);
            lblNotes.TabIndex = 16;
            lblNotes.Text = "Notas";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(177, 337);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(200, 60);
            txtNotes.TabIndex = 17;
            // 
            // lblPubDate
            // 
            lblPubDate.AutoSize = true;
            lblPubDate.Location = new Point(20, 420);
            lblPubDate.Name = "lblPubDate";
            lblPubDate.Size = new Size(119, 15);
            lblPubDate.TabIndex = 18;
            lblPubDate.Text = "Fecha de Publicación";
            // 
            // dtpPubDate
            // 
            dtpPubDate.Format = DateTimePickerFormat.Short;
            dtpPubDate.Location = new Point(177, 417);
            dtpPubDate.Name = "dtpPubDate";
            dtpPubDate.Size = new Size(200, 23);
            dtpPubDate.TabIndex = 19;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(177, 470);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormAddEditTitle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 520);
            Controls.Add(btnGuardar);
            Controls.Add(dtpPubDate);
            Controls.Add(lblPubDate);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtYtdSales);
            Controls.Add(lblYtdSales);
            Controls.Add(txtRoyalty);
            Controls.Add(lblRoyalty);
            Controls.Add(txtAdvance);
            Controls.Add(lblAdvance);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbPubId);
            Controls.Add(lblPubId);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(txtTitleId);
            Controls.Add(lblTitleId);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddEditTitle";
            Text = "Agregar/Editar Título";
            Load += FormAddEditTitle_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}