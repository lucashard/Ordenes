using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modelo
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public List<Direccion> Direccion { get; set; }
        public List<Entrega> Entrega { get; set; }
        private List<Cliente> ListaClientes { get; set; } = new List<Cliente>();


        public Cliente(string nombre, List<Direccion> direccion, List<Entrega> entrega)
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

        public List<Entrega> OrdenesParaEntragar()
        {
            List<Entrega> entregas=new List<Entrega>();
            foreach (Cliente item in ListaClientes)
            {
                entregas = item.Entrega.Where(x => x.Entregado == false).ToList();
            }
            return entregas;
        }
    }
}
