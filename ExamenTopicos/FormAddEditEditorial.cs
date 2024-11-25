using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamenTopicos
{
    public partial class FormAddEditEditorial : MetroForm
    {
        private Datos datos = new Datos();
        private string editorialId;
        private Utils.Operacion operacion;

        public FormAddEditEditorial(Utils.Operacion operacion, string id = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.editorialId = id;

            LlenarComboPais();
            ConfigurarComboBox(cboPais, cboEstado);
            ConfigurarEventos();

            if (operacion == Utils.Operacion.Editar && id != null)
            {
                CargarDatosEditorial(id);
                this.Text = "Editar Editorial";
            }
            else if (operacion == Utils.Operacion.Agregar)
            {
                this.Text = "Agregar Editorial";
                lblID.Text = GenerarNuevoId();
                LlenarComboEstado("Mexico");
                cboPais.SelectedIndex = 2;
                cboEstado.SelectedIndex = 6;
            }

            this.Shown += FormAddEditEditorial_Shown;
        }

        private void FormAddEditEditorial_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void LlenarComboPais()
        {
            try
            {
                string query = "SELECT DISTINCT pais FROM paises_estados";
                DataSet ds = datos.consulta(query);

                cboPais.Items.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string pais = row["pais"].ToString().Trim();
                        cboPais.Items.Add(pais);
                    }
                }

                if (cboPais.Items.Count > 0)
                {
                    cboPais.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los países: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEditorial(string id)
        {
            try
            {
                string query = "SELECT * FROM publishers WHERE pub_id = @pubId";
                SqlParameter[] parametros = {
                    new SqlParameter("@pubId", SqlDbType.Char, 4) { Value = id }
                };
                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtNombre.Text = ds.Tables[0].Rows[0]["pub_name"].ToString();
                    txtCiudad.Text = ds.Tables[0].Rows[0]["city"].ToString();

                    string paisSeleccionado = ds.Tables[0].Rows[0]["country"]?.ToString()?.Trim() ?? string.Empty;
                    string estadoSeleccionado = ds.Tables[0].Rows[0]["state"]?.ToString()?.Trim().ToUpper() ?? string.Empty;

                    if (!string.IsNullOrEmpty(paisSeleccionado) && cboPais.Items.Contains(paisSeleccionado))
                    {
                        cboPais.SelectedItem = paisSeleccionado;

                        LlenarComboEstado(paisSeleccionado);

                        var estadoItem = cboEstado.Items.Cast<ComboBoxItem>()
                            .FirstOrDefault(item => item.Value.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase));

                        if (estadoItem != null)
                        {
                            cboEstado.SelectedItem = estadoItem;
                        }
                    }
                    lblID.Text = id;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para la editorial especificada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboEstado(string pais)
        {
            try
            {
                string query = "SELECT estado, nombre_estado FROM paises_estados WHERE pais = @pais";
                SqlParameter[] parametros = {
                    new SqlParameter("@pais", SqlDbType.VarChar, 100) { Value = pais }
                };
                DataSet ds = datos.consulta(query, parametros);

                cboEstado.Items.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string estado = row["estado"].ToString();
                        string nombreEstado = row["nombre_estado"].ToString();
                        cboEstado.Items.Add(new ComboBoxItem { Text = nombreEstado, Value = estado });
                    }
                }

                if (cboEstado.Items.Count > 0)
                {
                    cboEstado.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = lblID.Text;
            string nombre = txtNombre.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string estado = (cboEstado.SelectedItem as ComboBoxItem)?.Value;
            string pais = cboPais.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(pais))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool resultado = false;

                if (operacion == Utils.Operacion.Agregar)
                {
                    string queryInsert = @"
                    INSERT INTO publishers (pub_id, pub_name, city, state, country) 
                    VALUES (@pubId, @pubName, @city, @state, @country)";
                    SqlParameter[] parametros = {
                        new SqlParameter("@pubId", SqlDbType.Char, 4) { Value = id },
                        new SqlParameter("@pubName", SqlDbType.VarChar, 40) { Value = nombre },
                        new SqlParameter("@city", SqlDbType.VarChar, 20) { Value = ciudad },
                        new SqlParameter("@state", SqlDbType.Char, 2) { Value = estado },
                        new SqlParameter("@country", SqlDbType.VarChar, 30) { Value = pais }
                    };
                    resultado = datos.ejecutarABC(queryInsert, parametros);
                    if (resultado)
                    {
                        MessageBox.Show("Editorial agregada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (operacion == Utils.Operacion.Editar)
                {
                    string queryUpdate = @"
                    UPDATE publishers 
                    SET pub_name = @pubName, city = @city, state = @state, country = @country 
                    WHERE pub_id = @pubId";
                    SqlParameter[] parametros = {
                        new SqlParameter("@pubId", SqlDbType.Char, 4) { Value = id },
                        new SqlParameter("@pubName", SqlDbType.VarChar, 40) { Value = nombre },
                        new SqlParameter("@city", SqlDbType.VarChar, 20) { Value = ciudad },
                        new SqlParameter("@state", SqlDbType.Char, 2) { Value = estado },
                        new SqlParameter("@country", SqlDbType.VarChar, 30) { Value = pais }
                    };
                    resultado = datos.ejecutarABC(queryUpdate, parametros);
                    if (resultado)
                    {
                        MessageBox.Show("Editorial actualizada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEventos()
        {
            txtNombre.TextChanged += Utils.agregarEvento;
            txtCiudad.TextChanged += Utils.agregarEvento;
            cboPais.SelectedIndexChanged += (sender, e) =>
            {
                string paisSeleccionado = cboPais.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(paisSeleccionado))
                {
                    LlenarComboEstado(paisSeleccionado);
                }
            };
        }

        private void ConfigurarComboBox(params ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private string GenerarNuevoId()
        {
            try
            {
                string query = "SELECT pub_id FROM publishers";
                DataSet ds = datos.consulta(query);
                var idsExistentes = ds.Tables[0].AsEnumerable()
                    .Select(row => row.Field<string>("pub_id"))
                    .ToList();

                for (int i = 9900; i <= 9999; i++)
                {
                    string nuevoId = i.ToString("D4");
                    if (!idsExistentes.Contains(nuevoId))
                    {
                        return nuevoId;
                    }
                }

                throw new Exception("No se pudo generar un nuevo ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}