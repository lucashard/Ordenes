using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Entrega
    {
        public Orden Orden { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Entregado { get; set; }
        public string Observaciones { get; set; }

        public Entrega()
        {
        }

        public Entrega( Orden orden, DateTime fechaEntrega, bool entregado, string observaciones)
        {            
            Orden = orden;
            FechaEntrega = fechaEntrega;
            Entregado = entregado;
            Observaciones = observaciones;
        }
    }
}
