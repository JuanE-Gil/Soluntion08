using BE;
using DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class LibroBL
    {
        public void Insert(LibroBE libroBE)
        {
            string Rpta = "";
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                SqlCon.Open();

                SqlCommand sqlCmd = SqlCon.CreateCommand();
                sqlCmd.CommandText = "insert into " +
                                     "Libros(ISBN, Titulo, Edicion, IdGenero, IdEditorial) " +
                                     "Values(@ISBN, @Titulo, @Edicion, @IdGenero, @IdEditorial)";

                sqlCmd.Parameters.AddWithValue("@ISBN", libroBE.ISBN);
                sqlCmd.Parameters.AddWithValue("@Titulo", libroBE.Titulo);
                sqlCmd.Parameters.AddWithValue("@Edicion", libroBE.Edicion);
                sqlCmd.Parameters.AddWithValue("@IdGenero", libroBE.Genero);
                sqlCmd.Parameters.AddWithValue("@IdEditorial", libroBE.Editorial);

                int rows = sqlCmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    Exception exception = new Exception("Error Insert Autor! como todo lo que haces");
                    throw exception;
                }
                SqlCon.Close();
            }
        }

        public DataTable ObtenerListadoLibros(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable TablaLibros = new DataTable();
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("LISTADO_LIBROS", SqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                    SqlCon.Open();
                    Resultado = sqlCmd.ExecuteReader();
                    TablaLibros.Load(Resultado);
                    return TablaLibros;
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
        public DataTable ObtenerListadoGeneros()
        {
            DataTable tablaGeneros = new DataTable();
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("LISTADO_GENERO", SqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    adapter.Fill(tablaGeneros);
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
            return tablaGeneros;
        }
        public DataTable ObtenerListadoEditorial()
        {
            SqlDataReader Resultado;
            DataTable tablaEditorial = new DataTable();
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("LISTADO_EDITORIAL", SqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCon.Open();
                    Resultado = sqlCmd.ExecuteReader();
                    tablaEditorial.Load(Resultado);
                    return tablaEditorial;
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
