using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAddEditTitle : Form
    {
        private Operacion operacion;
        private string titleId;
        private Datos datos = new Datos();

        public FormAddEditTitle(Operacion operacion, string titleId = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.titleId = titleId;

            ConfigurarFormulario();
            CargarDatosComboBox();
            this.Shown += FormAddEditTitle_Shown;
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Título";
                btnGuardar.Text = "Actualizar";
                ConfigurarCamposEdicion();
                CargarDatosTitulo(titleId);
                txtTitle.Focus();
            }
            else
            {
                this.Text = "Agregar Título";
                btnGuardar.Text = "Agregar";
                ConfigurarCamposAgregar();
                GenerarNuevoTitleId();
                txtTitle.Focus();
            }
        }

        private void FormAddEditTitle_Shown(object sender, EventArgs e)
        {
            txtTitle.BeginInvoke((Action)(() => txtTitle.Focus()));
        }

        private void ConfigurarCamposEdicion()
        {
            txtTitleId.ReadOnly = true;
            txtTitle.ReadOnly = false;
            cmbType.Enabled = true;
            cmbPubId.Enabled = true;
            txtPrice.ReadOnly = false;
            txtAdvance.ReadOnly = false;
            txtRoyalty.ReadOnly = false;
            txtYtdSales.ReadOnly = false;
            txtNotes.ReadOnly = false;
            dtpPubDate.Enabled = false; // Bloquear la fecha en modo "Editar"
        }

        private void ConfigurarCamposAgregar()
        {
            txtTitleId.ReadOnly = true;
            txtTitle.ReadOnly = false;
            cmbType.Enabled = true;
            cmbPubId.Enabled = true;
            txtPrice.ReadOnly = false;
            txtAdvance.ReadOnly = false;
            txtRoyalty.ReadOnly = false;
            txtYtdSales.ReadOnly = false;
            txtNotes.ReadOnly = false;
            dtpPubDate.Enabled = true; // Permitir la edición de la fecha en modo "Agregar"
        }

        private void GenerarNuevoTitleId()
        {
            try
            {
                string query = "SELECT MAX(title_id) AS MaxId FROM titles";
                DataSet ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string maxId = ds.Tables[0].Rows[0]["MaxId"].ToString();

                    if (!string.IsNullOrEmpty(maxId) && maxId.Length >= 4)
                    {
                        string prefix = maxId.Substring(0, 3);
                        int number = int.Parse(maxId.Substring(3)) + 1;
                        txtTitleId.Text = $"{prefix}{number:D4}";
                    }
                    else
                    {
                        txtTitleId.Text = "T0001";
                    }
                }
                else
                {
                    txtTitleId.Text = "T0001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar nuevo ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosComboBox()
        {
            try
            {
                string queryTypes = "SELECT DISTINCT type FROM titles";
                DataSet dsTypes = datos.consulta(queryTypes);
                if (dsTypes != null && dsTypes.Tables.Count > 0)
                {
                    cmbType.DataSource = dsTypes.Tables[0];
                    cmbType.DisplayMember = "type";
                    cmbType.ValueMember = "type";
                    cmbType.SelectedIndex = -1;
                }

                string queryEditoriales = "SELECT pub_id, pub_name FROM publishers";
                DataSet dsEditoriales = datos.consulta(queryEditoriales);
                if (dsEditoriales != null && dsEditoriales.Tables.Count > 0)
                {
                    cmbPubId.DataSource = dsEditoriales.Tables[0];
                    cmbPubId.DisplayMember = "pub_name";
                    cmbPubId.ValueMember = "pub_id";
                    cmbPubId.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosTitulo(string titleId)
        {
            try
            {
                string query = @"
            SELECT 
                title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate
            FROM 
                titles
            WHERE 
                title_id = @titleId";

                SqlParameter[] parametros = { new SqlParameter("@titleId", titleId) };

                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtTitleId.Text = row["title_id"].ToString();
                    txtTitle.Text = row["title"].ToString();
                    txtPrice.Text = row["price"].ToString();
                    txtAdvance.Text = row["advance"].ToString();
                    txtRoyalty.Text = row["royalty"].ToString();
                    txtYtdSales.Text = row["ytd_sales"].ToString();
                    txtNotes.Text = row["notes"].ToString();
                    dtpPubDate.Value = Convert.ToDateTime(row["pubdate"]);

                    // Seleccionar el tipo en el ComboBox
                    string tipo = row["type"].ToString();
                    if (!string.IsNullOrEmpty(tipo))
                    {
                        cmbType.SelectedItem = tipo;
                    }

                    // Seleccionar la editorial en el ComboBox
                    string pubId = row["pub_id"].ToString();
                    if (!string.IsNullOrEmpty(pubId))
                    {
                        cmbPubId.SelectedValue = pubId;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos del título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del título: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Los datos son correctos?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (!ValidarCampos())
                        return;

                    string query;
                    SqlParameter[] parametros;

                    if (operacion == Operacion.Agregar)
                    {
                        query = @"
                            INSERT INTO titles (title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate)
                            VALUES (@titleId, @title, @type, @pubId, @price, @advance, @royalty, @ytdSales, @notes, @pubdate)";
                        parametros = ObtenerParametros();
                    }
                    else
                    {
                        query = @"
                            UPDATE titles
                            SET title = @title,
                                type = @type,
                                pub_id = @pubId,
                                price = @price,
                                advance = @advance,
                                royalty = @royalty,
                                ytd_sales = @ytdSales,
                                notes = @notes,
                                pubdate = @pubdate
                            WHERE title_id = @titleId";
                        parametros = ObtenerParametros();
                    }

                    bool resultado = datos.ejecutarABC(query, parametros);

                    if (resultado)
                    {
                        MessageBox.Show($"Título {(operacion == Operacion.Agregar ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo {(operacion == Operacion.Agregar ? "agregar" : "actualizar")} el título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("El campo 'Título' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("El campo 'Tipo' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPubId.SelectedIndex == -1)
            {
                MessageBox.Show("El campo 'Editorial' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _) || !decimal.TryParse(txtAdvance.Text, out _))
            {
                MessageBox.Show("Los campos 'Precio' y 'Anticipo' deben ser números válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtRoyalty.Text, out _) || !int.TryParse(txtYtdSales.Text, out _))
            {
                MessageBox.Show("Los campos 'Regalías' y 'Ventas YTD' deben ser números válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private SqlParameter[] ObtenerParametros()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@titleId", txtTitleId.Text),
                new SqlParameter("@title", txtTitle.Text),
                new SqlParameter("@type", cmbType.SelectedItem?.ToString()),
                new SqlParameter("@pubId", cmbPubId.SelectedValue),
                new SqlParameter("@price", decimal.Parse(txtPrice.Text)),
                new SqlParameter("@advance", decimal.Parse(txtAdvance.Text)),
                new SqlParameter("@royalty", int.Parse(txtRoyalty.Text)),
                new SqlParameter("@ytdSales", int.Parse(txtYtdSales.Text)),
                new SqlParameter("@notes", txtNotes.Text),
                new SqlParameter("@pubdate", dtpPubDate.Value)
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}