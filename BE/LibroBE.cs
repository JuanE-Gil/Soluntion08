using System;

namespace BE
{
    public class LibroBE
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int Edicion { get; set; }
        public int Genero { get; set; }
        public int Editorial { get; set; }

        public LibroBE() { }

        public LibroBE(string iSBN, string titulo, int edicion, int genero, int editorial)
        {
            ISBN = iSBN;
            Titulo = titulo;
            Edicion = edicion;
            Genero = genero;
            Editorial = editorial;
        }
    }
}
