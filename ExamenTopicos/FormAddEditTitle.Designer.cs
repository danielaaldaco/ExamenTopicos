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
            this.lblTitleId = new Label();
            this.txtTitleId = new TextBox();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblType = new Label();
            this.cmbType = new ComboBox();
            this.lblPubId = new Label();
            this.cmbPubId = new ComboBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblAdvance = new Label();
            this.txtAdvance = new TextBox();
            this.lblRoyalty = new Label();
            this.txtRoyalty = new TextBox();
            this.lblYtdSales = new Label();
            this.txtYtdSales = new TextBox();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.lblPubDate = new Label();
            this.dtpPubDate = new DateTimePicker();
            this.btnGuardar = new Button();
            this.SuspendLayout();
            // 
            // lblTitleId
            // 
            this.lblTitleId.AutoSize = true;
            this.lblTitleId.Location = new Point(20, 20);
            this.lblTitleId.Name = "lblTitleId";
            this.lblTitleId.Size = new Size(43, 15);
            this.lblTitleId.TabIndex = 0;
            this.lblTitleId.Text = "ID Título";
            // 
            // txtTitleId
            // 
            this.txtTitleId.Location = new Point(177, 17);
            this.txtTitleId.Name = "txtTitleId";
            this.txtTitleId.ReadOnly = true;
            this.txtTitleId.Size = new Size(200, 23);
            this.txtTitleId.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(37, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Título";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new Point(177, 57);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(200, 23);
            this.txtTitle.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new Point(20, 100);
            this.lblType.Name = "lblType";
            this.lblType.Size = new Size(30, 15);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Tipo";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
                "Ficción",
                "No Ficción",
                "Ciencia",
                "Historia",
                "Biografía",
                "Otro"});
            this.cmbType.Location = new Point(177, 97);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new Size(200, 23);
            this.cmbType.TabIndex = 5;
            // 
            // lblPubId
            // 
            this.lblPubId.AutoSize = true;
            this.lblPubId.Location = new Point(20, 140);
            this.lblPubId.Name = "lblPubId";
            this.lblPubId.Size = new Size(50, 15);
            this.lblPubId.TabIndex = 6;
            this.lblPubId.Text = "Editorial";
            // 
            // cmbPubId
            // 
            this.cmbPubId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPubId.FormattingEnabled = true;
            this.cmbPubId.Location = new Point(177, 137);
            this.cmbPubId.Name = "cmbPubId";
            this.cmbPubId.Size = new Size(200, 23);
            this.cmbPubId.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new Point(20, 180);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(40, 15);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new Point(177, 177);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new Size(200, 23);
            this.txtPrice.TabIndex = 9;
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Location = new Point(20, 220);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new Size(55, 15);
            this.lblAdvance.TabIndex = 10;
            this.lblAdvance.Text = "Anticipo";
            // 
            // txtAdvance
            // 
            this.txtAdvance.Location = new Point(177, 217);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new Size(200, 23);
            this.txtAdvance.TabIndex = 11;
            // 
            // lblRoyalty
            // 
            this.lblRoyalty.AutoSize = true;
            this.lblRoyalty.Location = new Point(20, 260);
            this.lblRoyalty.Name = "lblRoyalty";
            this.lblRoyalty.Size = new Size(50, 15);
            this.lblRoyalty.TabIndex = 12;
            this.lblRoyalty.Text = "Regalías";
            // 
            // txtRoyalty
            // 
            this.txtRoyalty.Location = new Point(177, 257);
            this.txtRoyalty.Name = "txtRoyalty";
            this.txtRoyalty.Size = new Size(200, 23);
            this.txtRoyalty.TabIndex = 13;
            // 
            // lblYtdSales
            // 
            this.lblYtdSales.AutoSize = true;
            this.lblYtdSales.Location = new Point(20, 300);
            this.lblYtdSales.Name = "lblYtdSales";
            this.lblYtdSales.Size = new Size(65, 15);
            this.lblYtdSales.TabIndex = 14;
            this.lblYtdSales.Text = "Ventas YTD";
            // 
            // txtYtdSales
            // 
            this.txtYtdSales.Location = new Point(177, 297);
            this.txtYtdSales.Name = "txtYtdSales";
            this.txtYtdSales.Size = new Size(200, 23);
            this.txtYtdSales.TabIndex = 15;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new Point(20, 340);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(38, 15);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "Notas";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new Point(177, 337);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(200, 60);
            this.txtNotes.TabIndex = 17;
            // 
            // lblPubDate
            // 
            this.lblPubDate.AutoSize = true;
            this.lblPubDate.Location = new Point(20, 420);
            this.lblPubDate.Name = "lblPubDate";
            this.lblPubDate.Size = new Size(119, 15);
            this.lblPubDate.TabIndex = 18;
            this.lblPubDate.Text = "Fecha de Publicación";
            // 
            // dtpPubDate
            // 
            this.dtpPubDate.Format = DateTimePickerFormat.Short;
            this.dtpPubDate.Location = new Point(177, 417);
            this.dtpPubDate.Name = "dtpPubDate";
            this.dtpPubDate.Size = new Size(200, 23);
            this.dtpPubDate.TabIndex = 19;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(177, 470);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(100, 30);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // FormAddEditTitle
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 520);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpPubDate);
            this.Controls.Add(this.lblPubDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtYtdSales);
            this.Controls.Add(this.lblYtdSales);
            this.Controls.Add(this.txtRoyalty);
            this.Controls.Add(this.lblRoyalty);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.lblAdvance);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbPubId);
            this.Controls.Add(this.lblPubId);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitleId);
            this.Controls.Add(this.lblTitleId);
            this.Name = "FormAddEditTitle";
            this.Text = "Agregar/Editar Título";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}