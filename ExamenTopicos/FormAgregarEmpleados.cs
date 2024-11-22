﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static ExamenTopicos.Utils;

namespace ExamenTopicos
{
    public partial class FormAgregarEmpleados : Form
    {
        private Operacion operacion;
        private string empId;
        private Datos datos = new Datos();
        private const int ID_MIN_LENGTH = 8;
        private const int ID_MAX_LENGTH = 10;

        public FormAgregarEmpleados(Operacion operacion, string empId = null)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.empId = empId;

            ConfigurarRangoNivel();
            CargarDatosComboBox();
            ConfigurarFormulario();
            this.Shown += FormAgregarEmpleados_Shown;
        }

        private void ConfigurarFormulario()
        {
            if (operacion == Operacion.Editar)
            {
                this.Text = "Editar Empleado";
                btnAceptar.Text = "Actualizar";
                ConfigurarCamposEdicion();
                CargarDatosEmpleado(empId);
                cmbPuesto.Focus(); // Foco en "Puesto" al editar
            }
            else
            {
                this.Text = "Agregar Empleado";
                btnAceptar.Text = "Agregar";
                ConfigurarCamposAgregar();
                GenerarIdAlfanumerico();
                txtNombre.Focus(); // Foco en "Nombre" al agregar
            }
        }

        private void FormAgregarEmpleados_Shown(object sender, EventArgs e)
        {
            if (operacion == Operacion.Agregar)
            {
                txtNombre.BeginInvoke((Action)(() => txtNombre.Focus()));
            }
            else if (operacion == Operacion.Editar)
            {
                cmbPuesto.BeginInvoke((Action)(() => cmbPuesto.Focus()));
            }
        }

        private void ConfigurarCamposEdicion()
        {
            mskIdEmpleado.ReadOnly = true;
            txtNombre.ReadOnly = true;
            mskInicialSNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            dtpFecha.Enabled = false;

            cmbPuesto.Enabled = true;
            nudNivel.Enabled = true;
            cmbEditorial.Enabled = true;
        }

        private void ConfigurarCamposAgregar()
        {
            mskIdEmpleado.ReadOnly = true;

            txtNombre.ReadOnly = false;
            mskInicialSNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            cmbPuesto.Enabled = true;
            nudNivel.Enabled = true;
            cmbEditorial.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void GenerarIdAlfanumerico()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            int length = random.Next(ID_MIN_LENGTH, ID_MAX_LENGTH + 1);

            string nuevoId = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            mskIdEmpleado.Text = nuevoId;
            mskIdEmpleado.ReadOnly = true;
        }

        private void ConfigurarRangoNivel()
        {
            try
            {
                string query = "SELECT MIN(min_lvl) AS MinLevel, MAX(max_lvl) AS MaxLevel FROM jobs";
                DataSet ds = datos.consulta(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    nudNivel.Minimum = Convert.ToInt32(row["MinLevel"]);
                    nudNivel.Maximum = Convert.ToInt32(row["MaxLevel"]);
                }
                else
                {
                    nudNivel.Minimum = 10;
                    nudNivel.Maximum = 250;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el rango de nivel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudNivel.Minimum = 10;
                nudNivel.Maximum = 250;
            }
        }

        private void CargarDatosComboBox()
        {
            try
            {
                string queryPuestos = "SELECT job_id, job_desc FROM jobs";
                DataSet dsPuestos = datos.consulta(queryPuestos);
                if (dsPuestos != null && dsPuestos.Tables.Count > 0)
                {
                    cmbPuesto.DataSource = dsPuestos.Tables[0];
                    cmbPuesto.DisplayMember = "job_desc";
                    cmbPuesto.ValueMember = "job_id";
                    cmbPuesto.SelectedIndex = -1;
                }

                string queryEditoriales = "SELECT pub_id, pub_name FROM publishers";
                DataSet dsEditoriales = datos.consulta(queryEditoriales);
                if (dsEditoriales != null && dsEditoriales.Tables.Count > 0)
                {
                    cmbEditorial.DataSource = dsEditoriales.Tables[0];
                    cmbEditorial.DisplayMember = "pub_name";
                    cmbEditorial.ValueMember = "pub_id";
                    cmbEditorial.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEmpleado(string empId)
        {
            try
            {
                string query = @"
                    SELECT emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date
                    FROM employee
                    WHERE emp_id = @empId";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@empId", empId)
                };

                DataSet ds = datos.consulta(query, parametros);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    mskIdEmpleado.Text = row["emp_id"].ToString();
                    txtNombre.Text = row["fname"].ToString();
                    mskInicialSNombre.Text = row["minit"]?.ToString();
                    txtApellido.Text = row["lname"].ToString();

                    cmbPuesto.SelectedValue = row["job_id"];
                    cmbEditorial.SelectedValue = row["pub_id"];

                    nudNivel.Value = Convert.ToInt32(row["job_lvl"]);
                    dtpFecha.Value = Convert.ToDateTime(row["hire_date"]);

                    mskIdEmpleado.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los datos del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
                            INSERT INTO employee (emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date)
                            VALUES (@empId, @fname, @minit, @lname, @jobId, @jobLvl, @pubId, @hireDate)";
                        parametros = ObtenerParametros(false);
                    }
                    else
                    {
                        query = @"
                            UPDATE employee
                            SET job_id = @jobId, 
                                job_lvl = @jobLvl, 
                                pub_id = @pubId
                            WHERE emp_id = @empId";
                        parametros = ObtenerParametros(true);
                    }

                    bool resultado = datos.ejecutarABC(query, parametros);

                    if (resultado)
                    {
                        MessageBox.Show($"Empleado {(operacion == Operacion.Agregar ? "agregado" : "actualizado")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo {(operacion == Operacion.Agregar ? "agregar" : "actualizar")} el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (cmbPuesto.SelectedIndex == -1)
            {
                MessageBox.Show("El puesto es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEditorial.SelectedIndex == -1)
            {
                MessageBox.Show("La editorial es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private SqlParameter[] ObtenerParametros(bool incluirId)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@jobId", cmbPuesto.SelectedValue),
                new SqlParameter("@jobLvl", (int)nudNivel.Value),
                new SqlParameter("@pubId", cmbEditorial.SelectedValue)
            };

            if (incluirId || operacion == Operacion.Agregar)
            {
                parametros.Insert(0, new SqlParameter("@empId", mskIdEmpleado.Text));
            }

            return parametros.ToArray();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
