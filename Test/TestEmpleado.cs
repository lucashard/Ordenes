using Xunit;
using Modelo;
using System.Linq;
using System;

namespace Test
{
    public class TestEmpleado
    {

        private Empleado empleado =new Empleado();
        public TestEmpleado()
        {
            
            
        }

        [Fact]
        public void HayEmpleados()
        {
            Assert.NotNull(empleado.Get());
            Assert.True(empleado.Get().Count() == 0);
        }

        [Fact]
        public void AgregarEmpleado()
        {
            empleado.Add(new Modelo.Empleado { Nombre = "Lucas", Dni = 32638916, Id = 1 });
            Assert.NotNull(empleado.Get());
            Assert.True(empleado.Get().Count() == 1);
            
        }

        [Fact]
        public void AgregarEmpleadoConError()
        {
            
            ArgumentException ex = Assert.Throws<ArgumentException>(() => empleado.Add(new Modelo.Empleado { Nombre = "", Dni = 32638916, Id = 1 }));
            Assert.Equal("No puede ser vacio el Nombre", ex.Message);

        }

        [Fact]
        public void RemoverEmpleado()
        {
            empleado.Add(new Modelo.Empleado { Nombre = "Lucas", Dni = 32638916, Id = 1 });
            Assert.True(empleado.Get().Count() == 1);
            empleado.Delete(0);
            Assert.NotNull(empleado.Get());
            Assert.True(empleado.Get().Count() == 0);

        }


    }
}
