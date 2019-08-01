using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.ValueObjects
{
    public class ExcepcionesDeDominio:Exception
    {
        internal ExcepcionesDeDominio(string ReglaNegocio)
            :base(ReglaNegocio)
        { }

    }
}
