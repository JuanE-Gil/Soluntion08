using System;

namespace BE
{
    public class AutorBE
    {
        public int ID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nacionalidad { get; set; }

        public AutorBE() { }

        public AutorBE(int iD, string apellido, string nombre, DateTime fechaNacimiento, int nacionalidad)
        {
            ID = iD;
            Apellido = apellido;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Nacionalidad = nacionalidad;
        }

        public AutorBE(string apellido, string nombre, DateTime fechaNacimiento, int nacionalidad)
        {
            Apellido = apellido;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Nacionalidad = nacionalidad;
        }
    }
}
