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

        public static void activarPlaceholders(TextBox txtBuscar, string texto)
        {
            txtBuscar.Enter += (sender, e) =>
            {
                if (txtBuscar.Text == texto)
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };
            txtBuscar.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = texto;
                    txtBuscar.ForeColor = Color.Gray;
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

        public static bool MostrarConfirmacion(string titulo, Dictionary<string, object> parametrosYValores)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título no puede estar vacío.", nameof(titulo));

            string mensaje = GenerarMensajeConParametros(parametrosYValores);

            using (var formConfirmacion = new FormConfirmacion(titulo, parametrosYValores))
            {
                return formConfirmacion.ShowDialog() == DialogResult.OK;
            }
        }

        public enum Operacion
        {
            Agregar,
            Editar
        }
    }
}