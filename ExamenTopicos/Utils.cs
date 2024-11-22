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

        public enum Operacion
        {
            Agregar,
            Editar
        }
    }
}