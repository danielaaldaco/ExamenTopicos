using System;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormEditarPub : Form
    {
        private string pubId;
        private Datos datos = new Datos();

        public FormEditarPub(string pubId, string pubName, string city, string state, string country)
        {
            InitializeComponent();
            this.pubId = pubId;
            txtPubId.Text = pubId;
            txtPubName.Text = pubName;
            txtCity.Text = city;
            txtState.Text = state;
            txtCountry.Text = country;

            // Hacer el campo pub_id de solo lectura
            txtPubId.ReadOnly = true;

            // Asignar manejadores de eventos
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string newPubName = txtPubName.Text.Trim();
                string newCity = txtCity.Text.Trim();
                string newState = txtState.Text.Trim();
                string newCountry = txtCountry.Text.Trim();

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(newPubName))
                {
                    MessageBox.Show("El nombre de la editorial es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construir la consulta SQL de actualización
                string query = $"UPDATE publishers SET pub_name = '{newPubName}', city = '{newCity}', state = '{newState}', country = '{newCountry}' " +
                               $"WHERE pub_id = '{pubId}'";

                // Ejecutar la consulta de actualización
                bool exito = datos.ejecutarABC(query);

                if (exito)
                {
                    MessageBox.Show("Editorial actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario después de guardar
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la editorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin guardar cambios
        }
    }

    /// <summary>
    /// Clase de respaldo de datos de fila para manejar actualizaciones.
    /// </summary>
    public class PublisherBackupData
    {
        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
