using Xunit;
using Xunit.Extensions;
using Modelo;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    public class TestCliente
    {
        private Cliente Clientes = new Cliente();
        public TestCliente()
        {
            Clientes = new Cliente("IBMA", new List<Direccion>() { new Direccion("Peron 4200", null, "1650", "CABA", "Buenos Aires", 2048) }, null);            
        }

        [Fact]
        public void AgregarCliente()
        {
            List<Cliente> listcliente = Clientes.AgregarCliente(new Cliente("IBMA", new List<Direccion>() { new Direccion("Cerrito 4300", null, "1651", "CABA", "Buenos Aires", 2098) }, null));

            Assert.True(listcliente.Count()==1);
            Assert.True(listcliente.Select(x => x.Entrega).ToList()[0] == null);
        }

        [Fact]
        public void BuscarProximasEntregas()
        {
            var entrega = new List<Entrega>() { new Entrega() { Entregado = false, FechaEntrega = new System.DateTime(2018, 10, 10), Orden = new Orden() } };
            Clientes.AgregarCliente(new Cliente("Cetil",new List<Direccion>() { new Direccion("Parana",2,"1650","CABA","Buenos Aires",2040)},entrega));

            List<Entrega> lista=Clientes.OrdenesParaEntragar();
            Assert.True(lista.Count() == 1);
        }
    }
}
