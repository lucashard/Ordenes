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
        public bool EnParalelo { get; set; } = true;
     

        public Etapas(decimal duracion, string nombre,bool enParalelo)
        {      
            Nombre = nombre;
            Duracion = duracion;
            EnParalelo = enParalelo;
        }


    }
}
