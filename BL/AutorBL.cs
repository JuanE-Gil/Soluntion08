using BE;
using DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class AutorBL
    {
        public void Insert(AutorBE autorBE)
        {
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                SqlCon.Open();

                SqlCommand sqlCmd = SqlCon.CreateCommand();
                sqlCmd.CommandText = "insert into " +
                    "Autores(Apellido, Nombre, FechaNacimiento, Nacionalidad) " +
                    "values(@Apellido, @Nombre, @FechaNacimiento, @Nacionalidad)";

                sqlCmd.Parameters.AddWithValue("@Apellido", autorBE.Apellido);
                sqlCmd.Parameters.AddWithValue("@Nombre", autorBE.Nombre);
                sqlCmd.Parameters.AddWithValue("@FechaNacimiento", autorBE.FechaNacimiento);
                sqlCmd.Parameters.AddWithValue("@Nacionalidad", autorBE.Nacionalidad);

                int rows = sqlCmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    Exception exception = new Exception("Error Insert Autor! como todo lo que haces");
                    throw exception;
                }

                SqlCon.Close();
            }

        }

        public DataTable ObtenerListadoAutores(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable TablaAutores = new DataTable();
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("LISTADO_AUTORES", SqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                    SqlCon.Open();
                    Resultado = sqlCmd.ExecuteReader();
                    TablaAutores.Load(Resultado);
                    return TablaAutores;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                }
            }
        }
        public DataTable ObtenerListadoPaises()
        {
            SqlDataReader Resultado;
            DataTable tablaPaises = new DataTable();
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("LISTADO_PAISES", SqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCon.Open();
                    Resultado = sqlCmd.ExecuteReader();
                    tablaPaises.Load(Resultado);
                    return tablaPaises;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                }
            }
        }
    }
}
