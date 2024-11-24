namespace ExamenTopicos
{
    partial class FormConfirmacion
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TableLayoutPanel tableLayoutPanel;
        private Button btnAceptar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.tableLayoutPanel = new TableLayoutPanel();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(500, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Confirmar Acción";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // tableLayoutPanel
            this.tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.Location = new Point(20, 50);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tableLayoutPanel.Size = new Size(460, 80);
            this.tableLayoutPanel.TabIndex = 1;

            // btnAceptar
            this.btnAceptar.FlatStyle = FlatStyle.Flat;
            this.btnAceptar.BackColor = Color.FromArgb(34, 139, 34);
            this.btnAceptar.ForeColor = Color.White;
            this.btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnAceptar.Anchor = AnchorStyles.Bottom;
            this.btnAceptar.Location = new Point(80, tableLayoutPanel.Bottom + 20);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new Size(120, 40);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new EventHandler(this.BtnAceptar_Click);

            // btnCancelar
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.BackColor = Color.FromArgb(220, 50, 50);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCancelar.Anchor = AnchorStyles.Bottom;
            this.btnCancelar.Location = new Point(300, tableLayoutPanel.Bottom + 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 40);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.BtnCancelar_Click);

            // FormConfirmacion
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, btnCancelar.Bottom + 60);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "FormConfirmacion";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigurarFormulario(string titulo, Dictionary<string, object> parametrosYValores)
        {
            this.Text = titulo;
            lblTitulo.Text = titulo;
            ConfigurarTablaDetalles(parametrosYValores);
            ReubicarBotones();
        }

        private void ConfigurarTablaDetalles(Dictionary<string, object> parametrosYValores)
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = parametrosYValores.Count;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            foreach (var detalle in parametrosYValores)
            {
                var labelKey = new Label
                {
                    Text = detalle.Key,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Padding = new Padding(5, 10, 5, 10)
                };

                var labelValue = new Label
                {
                    Text = FormatearValor(detalle.Value),
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Padding = new Padding(5, 10, 5, 10)
                };

                tableLayoutPanel.Controls.Add(labelKey);
                tableLayoutPanel.Controls.Add(labelValue);
            }
        }

        private void ReubicarBotones()
        {
            btnAceptar.Location = new Point(80, tableLayoutPanel.Bottom + 20);
            btnCancelar.Location = new Point(300, tableLayoutPanel.Bottom + 20);
            this.ClientSize = new Size(500, btnCancelar.Bottom + 60);
        }

        private string FormatearValor(object valor)
        {
            return valor switch
            {
                DateTime fecha => fecha.ToString("dd/MM/yyyy hh:mm:ss tt"),
                decimal decimalValue => decimalValue.ToString("N2"),
                _ => valor?.ToString() ?? string.Empty
            };
        }
    }
}
