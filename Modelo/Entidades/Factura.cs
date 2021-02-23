using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Factura
    {
        public Factura(decimal total, Stock stock)
        {
            Total = total;
            Stock = stock;
        }


        public decimal Total { get; set; }
        public Stock Stock { get; set; }


    }
}
