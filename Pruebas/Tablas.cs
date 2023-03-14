using BL;
using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Tablas
    {
        private static readonly AutorBL autorBL = new AutorBL();

        static void Main(string[] args)
        {

            List<string> tablas = autorBL.Obtener_tablas();

            if (tablas.Count == 0)
            {
                Console.WriteLine("No se encontraron tablas en la base de datos .");
            }
            else
            {
                Console.WriteLine($"Se encontraron {tablas.Count} tablas en la base de datos:");
                foreach (string tabla in tablas)
                {
                    Console.WriteLine($"- {tabla}");
                }
            }

            Console.ReadLine();
        }

    }
}
