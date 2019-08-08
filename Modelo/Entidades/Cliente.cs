using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public List<Direccion> Direccion { get; set; }
        public List<Entrega> Entrega { get; set; }

        public Cliente(string nombre, List<Direccion> direccion, List<Entrega> entrega)
        {
            Nombre = nombre;
            Direccion = direccion;
            Entrega = entrega;
        }
    }
}
