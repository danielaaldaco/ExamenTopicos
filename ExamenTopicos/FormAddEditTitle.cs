    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    namespace ExamenTopicos
    {
        public partial class FormAddEditTitle : Form
        {
            private readonly Datos datos = new Datos();
            private readonly string titleId;
            private ErrorProvider errorProvider;
            private TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            public FormAddEditTitle(string id = null)
            {
                InitializeComponent();
                titleId = id;
                errorProvider = new ErrorProvider
                {
                    BlinkStyle = ErrorBlinkStyle.NeverBlink
                };

                cmbPubId.DropDownStyle = ComboBoxStyle.DropDownList;
                LoadPublishers();

                if (!string.IsNullOrEmpty(titleId))
                {
                    dtpPubDate.Enabled = false;
                    CargarDatos();
                }
                else
                {
                    dtpPubDate.Enabled = true; // El control sigue habilitado
                    dtpPubDate.Format = DateTimePickerFormat.Custom; // Formato personalizado
                    dtpPubDate.CustomFormat = "yyyy-MM-dd"; // Formato de la fecha
                    dtpPubDate.ShowUpDown = false; // Mostrar el calendario desplegable
                    dtpPubDate.Value = DateTime.Now.Date; // Establecer la fecha predeterminada

                    // Evitar que el texto sea editable con el teclado
                    dtpPubDate.KeyPress += (s, e) => e.Handled = true;
                }

                SuscribirEventosValidacion();
            }

            private void LoadPublishers()
            {
                DataSet ds = datos.consulta("SELECT pub_id, pub_name FROM publishers");
                if (ds != null && ds.Tables.Count > 0)
                {
                    cmbPubId.DataSource = ds.Tables[0];
                    cmbPubId.DisplayMember = "pub_name";
                    cmbPubId.ValueMember = "pub_id";
                    cmbPubId.SelectedIndex = -1;
                }
            }

            private void SuscribirEventosValidacion()
            {
                txtTitle.Validating += txtTitle_Validating;
                txtType.Validating += txtType_Validating;
                cmbPubId.Validating += cmbPubId_Validating;
                txtPrice.Validating += txtPrice_Validating;
                txtAdvance.Validating += txtAdvance_Validating;
                txtRoyalty.Validating += txtRoyalty_Validating;
                txtYtdSales.Validating += txtYtdSales_Validating;
            }

            private void CargarDatos()
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@titleId", titleId)
                };
                DataSet ds = datos.consulta("SELECT * FROM titles WHERE title_id = @titleId", parametros);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtTitle.Text = row["title"].ToString();
                    txtType.Text = row["type"].ToString();
                    string pubId = row["pub_id"]?.ToString();
                    if (!string.IsNullOrEmpty(pubId))
                    {
                        cmbPubId.SelectedValue = pubId;
                    }
                    txtPrice.Text = row["price"]?.ToString();
                    txtAdvance.Text = row["advance"]?.ToString();
                    txtRoyalty.Text = row["royalty"]?.ToString();
                    txtYtdSales.Text = row["ytd_sales"]?.ToString();
                    txtNotes.Text = row["notes"]?.ToString();

                    if (DateTime.TryParse(row["pubdate"]?.ToString(), out DateTime pubDate))
                    {
                        dtpPubDate.Value = pubDate.Date;
                        dtpPubDate.Format = DateTimePickerFormat.Custom;
                        dtpPubDate.CustomFormat = "yyyy-MM-dd";
                    }
                    else
                    {
                        dtpPubDate.Format = DateTimePickerFormat.Custom;
                        dtpPubDate.CustomFormat = " ";
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el título especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!this.ValidateChildren())
                    {
                        MessageBox.Show("Por favor, corrija los errores antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string title = textInfo.ToTitleCase(Regex.Replace(txtTitle.Text.Trim(), @"\s{2,}", " ").ToLower());
                    string type = textInfo.ToTitleCase(Regex.Replace(txtType.Text.Trim(), @"\s{2,}", " ").ToLower());
                    string pubId = cmbPubId.SelectedValue?.ToString();
                    string notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

                    string consulta;
                    bool esEdicion = !string.IsNullOrEmpty(titleId);

                    if (esEdicion)
                    {
                        consulta = @"
                            UPDATE titles 
                            SET title = @title, 
                                type = @type, 
                                pub_id = @pubId, 
                                price = @price, 
                                advance = @advance, 
                                royalty = @royalty, 
                                ytd_sales = @ytdSales, 
                                notes = @notes 
                            WHERE title_id = @titleId";
                    }
                    else
                    {
                        consulta = @"
                            INSERT INTO titles (title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate)
                            VALUES (@titleId, @title, @type, @pubId, @price, @advance, @royalty, @ytdSales, @notes, @pubdate)";
                    }

                    List<SqlParameter> parametros = new List<SqlParameter>
                    {
                        new SqlParameter("@title", title),
                        new SqlParameter("@type", type),
                        new SqlParameter("@pubId", string.IsNullOrEmpty(pubId) ? (object)DBNull.Value : pubId),
                        new SqlParameter("@price", decimal.Parse(txtPrice.Text)),
                        new SqlParameter("@advance", decimal.Parse(txtAdvance.Text)),
                        new SqlParameter("@royalty", int.Parse(txtRoyalty.Text)),
                        new SqlParameter("@ytdSales", int.Parse(txtYtdSales.Text)),
                        new SqlParameter("@notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes)
                    };

                    if (esEdicion)
                    {
                        parametros.Add(new SqlParameter("@titleId", titleId));
                    }
                    else
                    {
                        string newTitleId = GenerateTitleId();
                        parametros.Add(new SqlParameter("@titleId", newTitleId));
                        parametros.Add(new SqlParameter("@pubdate", dtpPubDate.Value.Date));
                    }

                    if (datos.ejecutarABC(consulta, parametros.ToArray()))
                    {
                        MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show($"Error en el formato de los datos ingresados: {fe.Message}", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private string GenerateTitleId()
            {
                Random random = new Random();
                string newTitleId;
                bool exists = false;

                do
                {
                    string letters = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";
                    string numbers = random.Next(0, 10000).ToString("D4");
                    newTitleId = $"{letters}{numbers}";

                    SqlParameter[] parametros = new SqlParameter[]
                    {
                        new SqlParameter("@titleId", newTitleId)
                    };
                    DataSet ds = datos.consulta("SELECT COUNT(*) AS Count FROM titles WHERE title_id = @titleId", parametros);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                        exists = count > 0;
                    }
                    else
                    {
                        exists = false;
                    }

                } while (exists);

                return newTitleId;
            }

            #region Validación de Controles

            private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                string input = Regex.Replace(txtTitle.Text.Trim(), @"\s{2,}", " ");
                txtTitle.Text = textInfo.ToTitleCase(input.ToLower());

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    errorProvider.SetError(txtTitle, "El título no puede estar vacío.");
                    e.Cancel = true;
                }
                else if (!Regex.IsMatch(txtTitle.Text, @"^[A-ZÁÉÍÓÚÑ][A-Za-zÁÉÍÓÚñÑ\s]+$"))
                {
                    errorProvider.SetError(txtTitle, "El título solo puede contener letras y espacios, y debe comenzar con una letra mayúscula.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtTitle, string.Empty);
                }
            }

            private void txtType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                string input = Regex.Replace(txtType.Text.Trim(), @"\s{2,}", " ");
                txtType.Text = textInfo.ToTitleCase(input.ToLower());

                if (string.IsNullOrWhiteSpace(txtType.Text))
                {
                    errorProvider.SetError(txtType, "El tipo no puede estar vacío.");
                    e.Cancel = true;
                }
                else if (!Regex.IsMatch(txtType.Text, @"^[A-ZÁÉÍÓÚÑ][A-Za-zÁÉÍÓÚñÑ\s]+$"))
                {
                    errorProvider.SetError(txtType, "El tipo solo puede contener letras y espacios, y debe comenzar con una letra mayúscula.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtType, string.Empty);
                }
            }

            private void cmbPubId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (cmbPubId.SelectedIndex == -1)
                {
                    errorProvider.SetError(cmbPubId, "Seleccione un Pub ID válido.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(cmbPubId, string.Empty);
                }
            }

            private void txtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                txtPrice.Text = txtPrice.Text.Trim();

                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    errorProvider.SetError(txtPrice, "El precio no puede estar vacío.");
                    e.Cancel = true;
                }
                else if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
                {
                    errorProvider.SetError(txtPrice, "Ingrese un precio válido y positivo.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPrice, string.Empty);
                }
            }

            private void txtAdvance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                txtAdvance.Text = txtAdvance.Text.Trim();

                if (string.IsNullOrWhiteSpace(txtAdvance.Text))
                {
                    errorProvider.SetError(txtAdvance, "El adelanto no puede estar vacío.");
                    e.Cancel = true;
                }
                else if (!decimal.TryParse(txtAdvance.Text, out decimal advance) || advance < 0)
                {
                    errorProvider.SetError(txtAdvance, "Ingrese un adelanto válido y positivo.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtAdvance, string.Empty);
                }
            }

            private void txtRoyalty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                txtRoyalty.Text = txtRoyalty.Text.Trim();

                if (string.IsNullOrWhiteSpace(txtRoyalty.Text))
                {
                    errorProvider.SetError(txtRoyalty, "Las regalías no pueden estar vacías.");
                    e.Cancel = true;
                }
                else if (!int.TryParse(txtRoyalty.Text, out int royalty) || royalty < 0)
                {
                    errorProvider.SetError(txtRoyalty, "Ingrese un valor de regalías válido y positivo.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtRoyalty, string.Empty);
                }
            }

            private void txtYtdSales_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                txtYtdSales.Text = txtYtdSales.Text.Trim();

                if (string.IsNullOrWhiteSpace(txtYtdSales.Text))
                {
                    errorProvider.SetError(txtYtdSales, "Las ventas YTD no pueden estar vacías.");
                    e.Cancel = true;
                }
                else if (!int.TryParse(txtYtdSales.Text, out int ytdSales) || ytdSales < 0)
                {
                    errorProvider.SetError(txtYtdSales, "Ingrese un valor de ventas YTD válido y positivo.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtYtdSales, string.Empty);
                }
            }

            #endregion
        }
    }
