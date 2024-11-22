using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ExamenTopicos
{
    internal class Datos
    {
        String cadenaConexion = @"Data Source=DESKTOP-VR4NTPA;
                Integrated Security=true;initial catalog=pubs";

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
        public void LlenarComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                DataSet ds = consulta(query); 
                if (ds != null && ds.Tables.Count > 0)
                {
                    comboBox.DataSource = ds.Tables[0];
                    comboBox.DisplayMember = displayMember; 
                    comboBox.ValueMember = valueMember;
                }
                else
                {
                    Debug.WriteLine("No se obtuvieron resultados de la consulta.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al llenar el ComboBox: {ex.Message}");
            }
        }

    }
}