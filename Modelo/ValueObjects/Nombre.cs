using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class Nombre
    {
        public  Nombre(string Nombre)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new ExcepcionesDeDominio("El nombre de la persona no puede ser vacio");
            }
            
        }
        public Nombre()
        { }
    }
}
