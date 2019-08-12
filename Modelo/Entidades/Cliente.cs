using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public List<Direccion> Direccion { get; set; }
        public List<Entrega> Entrega { get; set; }
        private List<Cliente> ListaClientes { get; set; } = new List<Cliente>();


        public Cliente(string nombre, List<Direccion> direccion, List<Entrega> entrega = null)
        {
            Nombre = nombre;
            Direccion = direccion;
            Entrega = entrega;
        }      

        public Cliente()
        {
        }

        public List<Cliente> AgregarCliente(Cliente cliente)
        {
            ListaClientes.Add(cliente);
            return ListaClientes;
        }
    }
}
