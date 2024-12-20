﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormConfirmacion : Form
    {
        public bool Confirmacion { get; private set; }

        public FormConfirmacion(Dictionary<string, object> parametrosYValores, string tittle)
        {
            InitializeComponent(tittle);
            ConfigurarFormulario(parametrosYValores);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Confirmacion = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Confirmacion = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}