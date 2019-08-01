using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class Numero
    {
        public Numero() { }

        public void NumeroDecimal(decimal numero)
        {
            if (string.IsNullOrEmpty(numero.ToString()))
            {
                throw new ElNumeroNoPuedeSerVacio("El Numero no puede puede ser vacio");
            }
        }

        public void NumeroEntero(int numero)
        {
            if (string.IsNullOrEmpty(numero.ToString()))
            {
                throw new ElNumeroNoPuedeSerVacio("El numero no puede puede ser vacio");
            }
        }

        public void NumeroDni(long numero)
        {
            if (string.IsNullOrEmpty(numero.ToString()))
            {
                throw new ElNumeroNoPuedeSerVacio("El Dni no puede puede ser vacio");
            }
        }
    }
}
