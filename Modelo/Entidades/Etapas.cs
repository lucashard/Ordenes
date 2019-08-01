using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Etapas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Duracion { get; set; }
     

        public Etapas(decimal duracion, string nombre)
        {      
            Nombre = nombre;
            Duracion = duracion;
        }


    }
}
