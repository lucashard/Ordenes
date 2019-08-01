using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class ElNombreNoPuedeEstarVacio : ExcepcionesDeDominio
    {
        internal ElNombreNoPuedeEstarVacio(string ReglaNegocio) : base(ReglaNegocio)
        {
        }
    }
}
