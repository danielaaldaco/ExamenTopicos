using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamenTopicos
{
    public partial class FormJobs : Form
    {
        DataSet ds;
        UserRole userRole;
        Datos datos = new Datos();
        private Dictionary<int, OriginalRowData> originalRows = new Dictionary<int, OriginalRowData>();
        private bool isUpdatingGrid = false;

        public FormJobs(UserRole role)
        {
            InitializeComponent();
            this.userRole = role;
            ConfigurarAccesoPorRol();
        }

        private void ConfigurarAccesoPorRol()
        {
            btnAgregar.Visible = false;
            dgvPuestos.ReadOnly = true;

            switch (userRole)
            {
                case UserRole.Cliente:
                    break;

                case UserRole.Empleado:
                    dgvPuestos.ReadOnly = true;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.GerenteVentas:
                    dgvPuestos.ReadOnly = false;
                    btnAgregar.Visible = true;
                    break;

                case UserRole.Administrador:
                    btnAgregar.Visible = true;
                    dgvPuestos.ReadOnly = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                isUpdatingGrid = true;

                ds = datos.consulta("SELECT job_id, job_desc, min_lvl, max_lvl FROM jobs");

                if (ds != null)
                {
                    dgvPuestos.DataSource = ds.Tables[0];
                    dgvPuestos.Columns["job_id"].HeaderText = "ID Puesto";
                    dgvPuestos.Columns["job_desc"].HeaderText = "Descripción";
                    dgvPuestos.Columns["min_lvl"].HeaderText = "Nivel Mínimo";
                    dgvPuestos.Columns["max_lvl"].HeaderText = "Nivel Máximo";
                    dgvPuestos.Columns["job_id"].ReadOnly = true;
                }

                originalRows.Clear();
            }
            finally
            {
                isUpdatingGrid = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                isUpdatingGrid = true;

                string searchValue = txtBuscar.Text;

                string searchValueTrimmed = searchValue.Trim();
                string searchValueSingleSpaces = Regex.Replace(searchValueTrimmed, @"\s+", " ");
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                string searchValueTransformed = textInfo.ToTitleCase(searchValueSingleSpaces.ToLower());

                ds = datos.consulta("SELECT * FROM jobs WHERE CAST(job_id AS VARCHAR) LIKE '%" + searchValueTransformed + "%' OR job_desc LIKE '%" + searchValueTransformed + "%'");

                if (ds != null)
                {
                    dgvPuestos.DataSource = ds.Tables[0];
                }

                originalRows.Clear();
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isUpdatingGrid = false;
            }
        }

        private void FormJobs_Load(object sender, EventArgs e)
        {
            ActualizarGrid();

            dgvPuestos.EditMode = DataGridViewEditMode.EditOnEnter;

            dgvPuestos.CellBeginEdit += dgvPuestos_CellBeginEdit;
            dgvPuestos.RowValidating += dgvPuestos_RowValidating;
            dgvPuestos.EditingControlShowing += dgvPuestos_EditingControlShowing;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[\w\s\b]$"))
            {
                e.Handled = true;
                return;
            }

            if (char.IsWhiteSpace(e.KeyChar))
            {
                TextBox tb = sender as TextBox;
                int selectionStart = tb.SelectionStart;
                if (selectionStart > 0 && char.IsWhiteSpace(tb.Text[selectionStart - 1]))
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvPuestos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= TextBox_KeyPress;
                tb.KeyPress += TextBox_KeyPress;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvPuestos.CurrentCell.ColumnIndex == dgvPuestos.Columns["job_desc"].Index)
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\b]$"))
                {
                    e.Handled = true;
                    return;
                }

                if (char.IsWhiteSpace(e.KeyChar))
                {
                    TextBox tb = sender as TextBox;
                    int selectionStart = tb.SelectionStart;
                    if (selectionStart > 0 && char.IsWhiteSpace(tb.Text[selectionStart - 1]))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (dgvPuestos.CurrentCell.ColumnIndex == dgvPuestos.Columns["min_lvl"].Index ||
                     dgvPuestos.CurrentCell.ColumnIndex == dgvPuestos.Columns["max_lvl"].Index)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarJob agregar = new FormAgregarJob();
            agregar.Show();
            agregar.FormClosed += (s, args) => ActualizarGrid();
        }

        private void dgvPuestos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                var row = dgvPuestos.Rows[e.RowIndex];

                if (!originalRows.ContainsKey(e.RowIndex))
                {
                    OriginalRowData originalData = new OriginalRowData
                    {
                        JobDesc = row.Cells["job_desc"].Value?.ToString(),
                        MinLvl = Convert.ToInt32(row.Cells["min_lvl"].Value),
                        MaxLvl = Convert.ToInt32(row.Cells["max_lvl"].Value)
                    };

                    originalRows[e.RowIndex] = originalData;
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al iniciar la edición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPuestos_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (isUpdatingGrid)
                {
                    return;
                }

                var row = dgvPuestos.Rows[e.RowIndex];

                if (row.IsNewRow || row.Index < 0)
                {
                    return;
                }

                if (!originalRows.ContainsKey(e.RowIndex))
                {
                    return;
                }

                OriginalRowData originalData = originalRows[e.RowIndex];

                int id = Convert.ToInt32(row.Cells["job_id"].Value);
                string newDescripcion = row.Cells["job_desc"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(newDescripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (!int.TryParse(row.Cells["min_lvl"].Value?.ToString(), out int newMinLvl))
                {
                    MessageBox.Show("El nivel mínimo debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (!int.TryParse(row.Cells["max_lvl"].Value?.ToString(), out int newMaxLvl))
                {
                    MessageBox.Show("El nivel máximo debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (newMinLvl > newMaxLvl)
                {
                    MessageBox.Show("El nivel mínimo debe ser menor o igual al nivel máximo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                string descripcionTrimmed = newDescripcion.Trim();
                string descripcionConEspacios = Regex.Replace(descripcionTrimmed, @"\s+", " ");
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                string descripcionLimpia = textInfo.ToTitleCase(descripcionConEspacios.ToLower());

                if (originalData.JobDesc != descripcionLimpia || originalData.MinLvl != newMinLvl || originalData.MaxLvl != newMaxLvl)
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("¿Deseas guardar los siguientes cambios?\n");

                    if (originalData.JobDesc != descripcionLimpia)
                    {
                        mensaje.AppendLine($"• Descripción: '{originalData.JobDesc}' ➔ '{descripcionLimpia}'");
                    }
                    if (originalData.MinLvl != newMinLvl)
                    {
                        mensaje.AppendLine($"• Nivel mínimo: {originalData.MinLvl} ➔ {newMinLvl}");
                    }
                    if (originalData.MaxLvl != newMaxLvl)
                    {
                        mensaje.AppendLine($"• Nivel máximo: {originalData.MaxLvl} ➔ {newMaxLvl}");
                    }

                    var confirmResult = MessageBox.Show(
                        mensaje.ToString(),
                        "Confirmar Cambios",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        string safeDescripcion = descripcionLimpia.Replace("'", "''");

                        string consulta = $"UPDATE jobs SET job_desc = '{safeDescripcion}', min_lvl = {newMinLvl}, max_lvl = {newMaxLvl} WHERE job_id = {id}";
                        bool resultado = datos.ejecutarABC(consulta);

                        if (resultado)
                        {
                            MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                ActualizarGrid();
                            }));
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el registro. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                ActualizarGrid();
                            }));
                        }
                    }
                    else
                    {
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ActualizarGrid();
                        }));
                    }
                }

                originalRows.Remove(e.RowIndex);
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al validar los datos. Verifique la información ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ActualizarGrid();
                }));
            }
        }
    }

    public class OriginalRowData
    {
        public string JobDesc { get; set; }
        public int MinLvl { get; set; }
        public int MaxLvl { get; set; }
    }
}