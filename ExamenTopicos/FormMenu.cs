﻿using System;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormMenu : Form
    {
        private Usuario user;

        public FormMenu(Usuario user)
        {
            InitializeComponent();
            this.user = user;
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            // Todos los botones son visibles, pero las restricciones se manejan en los eventos.
        }

        private void MostrarMensajeAccesoDenegado(string mensaje)
        {
            Form mensajeForm = new Form
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Acceso Restringido",
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label mensajeLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = mensaje,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Dock = DockStyle.Bottom,
                Height = 40,
                DialogResult = DialogResult.OK
            };

            mensajeForm.Controls.Add(mensajeLabel);
            mensajeForm.Controls.Add(btnAceptar);

            mensajeForm.AcceptButton = btnAceptar;
            mensajeForm.ShowDialog();
        }

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            if (user.Rol == UserRole.Empleado || user.Rol == UserRole.Cliente)
            {
                MostrarMensajeAccesoDenegado("Acceso denegado. Solo gerentes y administradores tienen permiso para esta sección.");
                return;
            }

            FormJobs formJobs = new FormJobs(user.Rol);
            formJobs.Show();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            FormPublisher formPublisher = new FormPublisher();
            formPublisher.Show();
        }

        private void btnRegalias_Click(object sender, EventArgs e)
        {
            if (user.Rol == UserRole.Empleado || user.Rol == UserRole.Cliente)
            {
                FormRegalias formRegalias = new FormRegalias();
                formRegalias.Show();
            }

            MessageBox.Show("Bienvenido a la sección de Regalías.", "Regalías", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormEmpleados formEmpleados = new FormEmpleados(user.Rol);
            formEmpleados.Show();
        }

        private void btnTitulos_Click(object sender, EventArgs e)
        {
            FormAutorTitulo formAutorTitulo = new FormAutorTitulo(user.Rol);
            formAutorTitulo.Show();
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            FormDescuentos formDescuentos = new FormDescuentos();
            formDescuentos.Show();
        }

        private void btnTiendas_Click(object sender, EventArgs e)
        {
            FormTiendas formTiendas=new FormTiendas();
            formTiendas.Show();
        }

        private void btnInfoEditorial_Click(object sender, EventArgs e)
        {
            FormInfoEditorial formInfoEditorial = new FormInfoEditorial();
            formInfoEditorial.Show();
        }

        private void btnAutoresLibros_Click(object sender, EventArgs e)
        {
            FormAutorTitulo formAutorTitulo = new FormAutorTitulo(user.Rol);
            formAutorTitulo.Show();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            FormAutores formAutores = new FormAutores();
            formAutores.Show();
        }

        private void btnAgregarEditorial_Click(object sender, EventArgs e)
        {
            FormAgregarPub agregarPub = new FormAgregarPub();
            agregarPub.Show();
        }
    }
}
