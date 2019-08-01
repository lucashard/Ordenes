using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Modelo;
namespace Test
{
    public class TestStock
    {
        private MateriasPrima materiaPrima;
        public TestStock()
        {
            materiaPrima = new MateriasPrima(new MateriasPrima() { Cantidad = 20, Costo = 30, Nombre = "Cerrucho" }, 30, 40);
        }

        [Fact]
        public void AgregarMateriaPrimaNoExistenteEnStock()
        {
            var lista = materiaPrima.AgregaMateriaPrima(new MateriasPrima() { Cantidad = 20, Costo = 30, Nombre = "Madera" }, 30, 40);
            Assert.True(lista.Count == 2);
        }

        [Fact]
        public void AgregarStockCantidadMateriaPrima()
        {
            int materia = materiaPrima.AgregarMateriaPrimaQueYaExiste("Cerrucho" ,10);
            Assert.True(materia == 40);
        }

  




            

    }
}
