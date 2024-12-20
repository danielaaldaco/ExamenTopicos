using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ExamenTopicos
{
    internal class Datos
    {
        private const string ALFREDO = @"Data Source=ALFREDO\SQLEXPRESS;
                Integrated Security=true;initial catalog=pubs";

        private const string DANI = @"Data Source=DESKTOP-VR4NTPA;
                Integrated Security=true;initial catalog=pubs";

        String cadenaConexion = DANI;

        SqlConnection conexion;

        private SqlConnection abrirConexion()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        private void cerrarConexion()
        {
            try
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public bool ejecutarABC(String comando)
        {
            try
            {
                SqlCommand command = new SqlCommand(comando, abrirConexion());
                command.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public DataSet consulta(String comando)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando, abrirConexion());
                da.Fill(ds);
                cerrarConexion();
                return ds;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public bool ejecutarABC(String comando, SqlParameter[] parametros)
        {
            try
            {
                SqlConnection conn = abrirConexion();
                if (conn == null)
                    return false;
                SqlCommand cmd = new SqlCommand(comando, conn);
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public DataSet consulta(String comando, SqlParameter[] parametros)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection conn = abrirConexion();
                if (conn == null)
                    return ds;
                SqlCommand cmd = new SqlCommand(comando, conn);
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cerrarConexion();
                return ds;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
    }
}