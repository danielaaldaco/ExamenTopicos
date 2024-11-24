using System;
using System.Data;
using System.Text;
using System.Globalization;


namespace ExamenTopicos
{
    public static class Utils
    {
        private const string ColumnaEliminar = "'' AS [Eliminar]";

        private static readonly Datos datos = new Datos();

        public static DataSet TablaConEliminar(params string[] args)
        {
            if (args.Length < 3 || args.Length % 2 != 1)
            {
                throw new ArgumentException("Parámetros incorrectos. Debe incluir pares de columnas y alias, seguidos del nombre de la tabla.");
            }

            var columnas = new StringBuilder();
            var table = args[args.Length - 1];
            formatearConsulta(args, columnas, true);

            var sql = $"SELECT {columnas} FROM {table}";
            return datos.consulta(sql);
        }

        public static DataSet Tabla(params string[] args)
        {
            if (args.Length < 3 || args.Length % 2 != 1)
            {
                throw new ArgumentException("Parámetros incorrectos. Debe incluir pares de columnas y alias, seguidos del nombre de la tabla.");
            }

            var columnas = new StringBuilder();
            var table = args[args.Length - 1];
            formatearConsulta(args, columnas, false);

            var sql = $"SELECT {columnas} FROM {table}";
            return datos.consulta(sql);
        }

        private static void formatearConsulta(string[] args, StringBuilder columnas, bool incluirEliminar)
        {

            for (int i = 0; i < args.Length - 1; i += 2)
            {
                var nombreColumna = args[i];
                var aliasColumna = char.ToUpper(args[i + 1][0]) + args[i + 1].Substring(1);
                columnas.Append($"{(i > 0 ? ", " : string.Empty)}{nombreColumna} AS [{aliasColumna}]");
            }

            if (incluirEliminar)
            {
                columnas.Append($", {ColumnaEliminar}");
            }
        }

        public static void activarPlaceholders(TextBox txtBuscar, string placeholder)
        {
            txtBuscar.Text = placeholder;
            txtBuscar.ForeColor = Color.Gray;

            txtBuscar.Enter += (sender, e) =>
            {
                if (txtBuscar.ForeColor == Color.Gray)
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = placeholder;
                    txtBuscar.ForeColor = Color.Gray;
                }
            };

            txtBuscar.TextChanged += (sender, e) =>
            {
                if (txtBuscar.ForeColor == Color.Black)
                {
                    agregarEvento(sender, e);
                }
            };
        }

        public static string GenerarMensajeConParametros(Dictionary<string, object> parametrosYValores)
        {
            if (parametrosYValores == null || parametrosYValores.Count == 0)
                throw new ArgumentException("El diccionario de parámetros no puede estar vacío.");

            var mensaje = new StringBuilder();
            int maxKeyLength = parametrosYValores.Keys.Max(k => k.Length);

            foreach (var parametro in parametrosYValores)
            {
                string clave = parametro.Key.PadRight(maxKeyLength);
                string valor = FormatearValor(parametro.Value);

                mensaje.AppendLine($"{clave}: {valor}");
            }

            return mensaje.ToString();
        }

        private static string FormatearValor(object valor)
        {
            return valor switch
            {
                DateTime fecha => fecha.ToString("yyyy/MM/dd"),
                decimal decimalValue => decimalValue.ToString("N2"),
                _ => valor?.ToString() ?? string.Empty
            };
        }

        public static bool confirmarEliminacion(Dictionary<string, object> parametrosYValores)
        {
            string mensaje = GenerarMensajeConParametros(parametrosYValores);

            using (var formConfirmacion = new FormConfirmacion(parametrosYValores))
            {
                return formConfirmacion.ShowDialog() == DialogResult.OK;
            }
        }

        private static void TransformarComboBoxTexto(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string textoActual = System.Text.RegularExpressions.Regex.Replace(comboBox.Text, @"\s{2,}", " ");
                textoActual = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textoActual.ToLower()).Trim();
                int posicionCursor = comboBox.SelectionStart;
                comboBox.Text = textoActual;
                comboBox.SelectionStart = Math.Min(posicionCursor, comboBox.Text.Length);
            }
        }

        public static void agregarEvento(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                int posicionCursor = textBox.SelectionStart;
                string textoActual = textBox.Text;

                textoActual = textoActual.TrimStart();
                textoActual = System.Text.RegularExpressions.Regex.Replace(textoActual, @" {2,}", " ");
                textoActual = System.Text.RegularExpressions.Regex.Replace(textoActual, @"\b[a-zA-Z]", m => m.Value.ToUpper());

                textBox.Text = textoActual;
                textBox.SelectionStart = Math.Min(posicionCursor, textBox.Text.Length);
            }
        }

        public enum Operacion
        {
            Agregar,
            Editar
        }

        public static bool placeholderActivo(string searchValue, string placeholder)
        {
            return string.IsNullOrWhiteSpace(searchValue) || searchValue.Equals(placeholder, StringComparison.OrdinalIgnoreCase);
        }

        public static void crearHeader(DataGridView dgv, params string[] columnas)
        {
            if (columnas == null || columnas.Length == 0)
                throw new ArgumentException("Debe proporcionar al menos un nombre de columna.");

            var tablaVacia = new DataTable();

            foreach (var columna in columnas)
            {
                tablaVacia.Columns.Add(columna);
            }

            dgv.DataSource = tablaVacia;
        }

        public static void EliminarHoraDeFecha(DataGridView dgv, string columnaFecha)
        {
            if (!dgv.Columns.Contains(columnaFecha)) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnaFecha].Value is DateTime fecha)
                {
                    row.Cells[columnaFecha].Value = fecha.ToString("dd/MM/yyyy");
                }
            }
        }
    }
}