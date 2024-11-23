using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormAddEditEditorial : Form
    {
        private Datos datos = new Datos();
        private string editorialId; // ID para edición
        private Utils.Operacion operacion;

        public FormAddEditEditorial(Utils.Operacion operacion, string id = null)
        {
            InitializeComponent();

            this.operacion = operacion;
            this.editorialId = id;

            // Configurar ComboBoxes
            LlenarComboIds();
            LlenarComboPais();

            // Configurar formulario según operación
            if (operacion == Utils.Operacion.Editar && id != null)
            {
                CargarDatosEditorial(id);
                cboEditorialId.Enabled = false; // Evitar cambiar el ID en edición
            }
            else if (operacion == Utils.Operacion.Agregar)
            {
                if (cboEditorialId.Items.Count > 0)
                {
                    cboEditorialId.SelectedIndex = 0; // Selecciona el primer ID por defecto
                }
            }

            this.Shown += FormAddEditEditorial_Shown;
            cboPais.SelectedIndexChanged += CboPais_SelectedIndexChanged; // Actualizar estados al cambiar país
            
        }

        private void FormAddEditEditorial_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus(); // Establecer el foco en el nombre
        }

        private void LlenarComboIds()
        {
            try
            {
                // IDs válidos definidos en la restricción CHECK
                string[] idsValidos = { "1389", "0736", "0877", "1622", "1756" };
                cboEditorialId.Items.Clear();
                foreach (var id in idsValidos)
                {
                    cboEditorialId.Items.Add(id);
                }
                if (cboEditorialId.Items.Count > 0)
                {
                    cboEditorialId.SelectedIndex = 0; // Seleccionar el primer ID por defecto
                }
                cboEditorialId.DropDownStyle = ComboBoxStyle.DropDownList; // Hacerlo de solo lectura
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboPais()
        {
            try
            {
                string query = "SELECT DISTINCT pais FROM paises_estados";
                DataSet ds = datos.consulta(query);

                cboPais.Items.Clear(); // Limpiar elementos anteriores
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string pais = row["pais"].ToString().Trim();
                        cboPais.Items.Add(pais); // Agregar el país al ComboBox
                    }
                }

                if (cboPais.Items.Count > 0)
                {
                    cboPais.SelectedIndex = 0; // Seleccionar el primer país por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los países: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedItem != null)
            {
                string paisSeleccionado = cboPais.SelectedItem.ToString();
                LlenarComboEstado(paisSeleccionado);
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

                cboEstado.Items.Clear(); // Limpiar elementos anteriores
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string estado = row["estado"].ToString(); // Código de estado (2 caracteres)
                        string nombreEstado = row["nombre_estado"].ToString(); // Nombre completo del estado

                        // Agregar el nombre del estado y almacenar el código de estado
                        cboEstado.Items.Add(new ComboBoxItem { Text = nombreEstado, Value = estado });
                    }
                }

                if (cboEstado.Items.Count > 0)
                {
                    cboEstado.SelectedIndex = 0; // Seleccionar el primer estado por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Asignar valores a los campos
                    cboEditorialId.SelectedItem = ds.Tables[0].Rows[0]["pub_id"].ToString();
                    txtNombre.Text = ds.Tables[0].Rows[0]["pub_name"].ToString();
                    txtCiudad.Text = ds.Tables[0].Rows[0]["city"].ToString();

                    // Seleccionar el país
                    string paisSeleccionado = ds.Tables[0].Rows[0]["country"]?.ToString()?.Trim() ?? string.Empty;

                    if (!string.IsNullOrEmpty(paisSeleccionado) && cboPais.Items.Contains(paisSeleccionado))
                    {
                        cboPais.SelectedItem = paisSeleccionado;

                        // Seleccionar el estado
                        string estadoSeleccionado = ds.Tables[0].Rows[0]["state"]?.ToString()?.Trim().ToUpper() ?? string.Empty;
                        var estadoItem = cboEstado.Items.Cast<ComboBoxItem>()
                            .FirstOrDefault(item => item.Value.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase));

                        if (estadoItem != null)
                        {
                            cboEstado.SelectedItem = estadoItem;
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"El país '{paisSeleccionado}' no se encuentra en la lista de países.");
                    }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = cboEditorialId.SelectedItem?.ToString();
            string nombre = txtNombre.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string estado = (cboEstado.SelectedItem as ComboBoxItem)?.Value;
            string pais = cboPais.SelectedItem?.ToString();

            // Depuración: Mostrar los valores que se intentarán insertar
            Debug.WriteLine($"Insertando/Actualizando Editorial:");
            Debug.WriteLine($"ID: {id}");
            Debug.WriteLine($"Nombre: {nombre}");
            Debug.WriteLine($"Ciudad: {ciudad}");
            Debug.WriteLine($"Estado: {estado}");
            Debug.WriteLine($"País: {pais}");

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(pais))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Verificar si el ID ya existe
                string queryCheckId = "SELECT COUNT(*) FROM publishers WHERE pub_id = @pubId";
                SqlParameter[] parametrosCheck = {
            new SqlParameter("@pubId", SqlDbType.Char, 4) { Value = id }
        };

                DataSet ds = datos.consulta(queryCheckId, parametrosCheck);

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
                    Debug.WriteLine($"Resultado de INSERT: {resultado}");
                    if (resultado)
                    {
                        MessageBox.Show("Editorial agregada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la editorial. Revisa los datos e intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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
                    Debug.WriteLine($"Resultado de UPDATE: {resultado}");
                    if (resultado)
                    {
                        MessageBox.Show("Editorial actualizada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la editorial. Revisa los datos e intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
