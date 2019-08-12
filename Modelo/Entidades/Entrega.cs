using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Entrega
    {
        public Cliente Cliente { get; set; }
        public Orden Orden { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Entregado { get; set; }
        public string Observaciones { get; set; }

        public Entrega(Cliente cliente, Orden orden, DateTime fechaEntrega, bool entregado, string observaciones)
        {
            Cliente = cliente;
            Orden = orden;
            FechaEntrega = fechaEntrega;
            Entregado = entregado;
            Observaciones = observaciones;
        }
    }
}
