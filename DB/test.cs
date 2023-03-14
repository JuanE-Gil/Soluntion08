using System;

// Import
using System.Data.SqlClient;

namespace DB
{
    public class test
    {
        // Método ejecutable
        public static void Main(string[] args)
        {
            using (SqlConnection SqlCon = Conexion.getInstancia().CrearConexion())
            {
                // abrir conexión
                SqlCon.Open();

                // mensaje de prueba
                Console.WriteLine("!Conexión OK¡");

                // cerrar conexión
                SqlCon.Close();

                Console.ReadKey();
            }
        }

    }
}
