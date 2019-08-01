using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class DniIncorrecto : ExcepcionesDeDominio
    {
        internal DniIncorrecto(string ReglaNegocio) : base(ReglaNegocio)
        {
        }
    }
}
