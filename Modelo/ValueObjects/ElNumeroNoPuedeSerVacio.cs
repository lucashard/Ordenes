using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class ElNumeroNoPuedeSerVacio : ExcepcionesDeDominio
    {
        internal ElNumeroNoPuedeSerVacio(string ReglaNegocio) : base(ReglaNegocio)
        {
        }
    }
}
