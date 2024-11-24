namespace ExamenTopicos
{
    partial class FormConfirmacion
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TableLayoutPanel tableLayoutPanel;
        private Button btnEliminar;
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
            lblTitulo = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            btnEliminar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            //lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(0, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(441, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¿Confirmar Eliminación?";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Location = new Point(11, 65);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(418, 0);
            tableLayoutPanel.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom;
            btnEliminar.BackColor = Color.FromArgb(34, 139, 34);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(3, 173);
            btnEliminar.Margin = new Padding(0, 27, 0, 27);
            btnEliminar.Name = "btnAceptar";
            btnEliminar.Size = new Size(322, 53);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Confirmar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom;
            btnCancelar.BackColor = Color.FromArgb(220, 50, 50);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(326, 173);
            btnCancelar.Margin = new Padding(0, 27, 0, 27);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(322, 53);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // FormConfirmacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(441, 227);
            Controls.Add(lblTitulo);
            Controls.Add(tableLayoutPanel);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormConfirmacion";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarFormulario(Dictionary<string, object> parametrosYValores)
        {
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
                    Text = FormatearValor(detalle.Key, detalle.Value),
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Padding = new Padding(5, 10, 5, 10)
                };

                tableLayoutPanel.Controls.Add(labelKey);
                tableLayoutPanel.Controls.Add(labelValue);
            }

            AjustarTamanoFormulario();
        }

        private void ReubicarBotones()
        {
            int margenIzquierdo = tableLayoutPanel.Left + tableLayoutPanel.Padding.Left;
            int margenDerecho = tableLayoutPanel.Right - tableLayoutPanel.Padding.Right;

            int espacioDisponible = margenDerecho - margenIzquierdo;
            int buttonWidth = (espacioDisponible / 2) - 10;

            btnEliminar.Width = buttonWidth;
            btnCancelar.Width = buttonWidth;

            btnCancelar.Location = new Point(margenDerecho - buttonWidth, tableLayoutPanel.Bottom + 20);
            btnEliminar.Location = new Point(margenIzquierdo, tableLayoutPanel.Bottom + 20);
        }

        private void AjustarTamanoFormulario()
        {
            int requiredWidth = tableLayoutPanel.PreferredSize.Width + 20;
            int requiredHeight = tableLayoutPanel.Bottom + btnEliminar.Height + 40;

            this.ClientSize = new Size(requiredWidth, requiredHeight);
        }

        private string FormatearValor(string key, object valor)
        {
            if (key.ToLower().Contains("fecha"))
            {
                if (DateTime.TryParse(valor.ToString(), out DateTime fecha))
                {
                    return fecha.ToString("dd/MM/yyyy");
                }
            }
            return valor switch
            {
                decimal decimalValue => decimalValue.ToString("N2"),
                _ => valor?.ToString() ?? string.Empty
            };
        }
    }
}
