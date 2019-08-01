using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Stock
    {
        public MateriasPrima Materias { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }

    }
}
