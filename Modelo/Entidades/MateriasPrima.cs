﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class MateriasPrima
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }

        private List<Stock> lista = new List<Stock>();

        public MateriasPrima()
        {

        }

        public MateriasPrima(MateriasPrima materiasPrima, int cantidad, int stockminimo)
        {
            lista.Add(new Stock() { Materias = materiasPrima,  StockMinimo = stockminimo });
        }

        public List<Stock> AgregaMateriaPrima(MateriasPrima materiasPrima, int cantidad, int stockminimo)
        {
            if (!lista.Exists(x => x.Materias.Nombre == materiasPrima.Nombre))
            {
                lista.Add(new Stock() { Materias = materiasPrima,  StockMinimo = stockminimo });
            }
            return lista;
        }

        public int CalcularStockByMateriaPrima(string v)
        {
            int cantidad = 0;
            foreach (var item in lista)
            {
                if(item.Materias.Nombre.Equals(v))
                {
                    cantidad += item.Materias.Cantidad;
                }
            }
            return cantidad;
        }

        public int AgregarMateriaPrimaQueYaExiste(string materiasPrima, int cantidad)
        {
           // int cant1 = lista.Find(x => x.Materias.Nombre == materiasPrima).Cantidad + cantidad;
            //lista.Find(x => x.Materias.Nombre == materiasPrima).Cantidad = cant1;
            return 1;
        }
    }
}
