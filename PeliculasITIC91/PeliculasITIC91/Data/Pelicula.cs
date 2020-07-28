using System;
using System.Collections.Generic;
using System.Text;

namespace PeliculasITIC91.Data
{
    public class Pelicula
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracion { get; set; }

        public int Anio { get; set; }

        public override string ToString()
        {
            return "Genero: " + Genero + "  Duracion: " + Duracion + " min.  Año: " + Anio;

        }

    }
}
