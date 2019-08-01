using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Modelo;
using Modelo.ValueObjects;
using System.Linq;

namespace Test
{
    public class TestProcesoProductivo
    {
        private Orden orden;
     
        public TestProcesoProductivo()
        {
            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1, Puesto = new Puestos() { Nombre = "Carpintero" } }, new Etapas(20, "Cerrucho")) };


            orden = new Orden(new List<Orden>() {new Orden( empleadosEtapas,
                                                                        new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } },DateTime.Now,"Fiat") });
        }

        [Fact]
        public void SePuedeAgregarOrden()
        {
            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1 }, new Etapas(20, "Cerrucho")) };

            Orden ProcesoProductivo = new Orden(new List<Orden>() { new Orden(empleadosEtapas,
                                                                        new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } },DateTime.Now,"Fiat") });


            bool opcion = ProcesoProductivo.SePuedeAgregarOrden();

            Assert.True(opcion == true);

        }

        [Fact]
        public void AgregarOrden()
        {
            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1 }, new Etapas(20, "Cerrucho")) };

            var list = orden.AgregarOrden(new Orden(empleadosEtapas,
                                                            new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } }, DateTime.Now,"Fiat"));
            Assert.True(list.Count == 2);

        }

        [Fact]
        public void ErrorAlAgregarOrdenErronea()
        {

            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "", Dni = 32638916, Id = 1 }, new Etapas(20, "Cerrucho")) };

            Orden proc = new Orden(new List<Orden>() { new Orden(empleadosEtapas,
                                                                        new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } },DateTime.Now,"Fiat") });
            List<String> listaErrores = new List<String>();
            foreach (Orden orden in proc.ListOrdenes)
            {
                foreach (var item in orden.EmpleadosEtapas)
                {
                    var ex = Assert.Throws<ExcepcionesDeDominio>(
                    () => new Nombre(item.Empleado.Nombre)).Message.ToString();
                }
            }

        }

        [Fact]
        public void CalcularDuracionEnHorasProceso()
        {
            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1 }, new Etapas(20, "Cerrucho")) };

            Orden proc = new Orden(new List<Orden>() { new Orden(empleadosEtapas,
                                                                        new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } },DateTime.Now,"Fiat") });

            decimal duracion = proc.CalcularDuracionProducto();
            Assert.True(20 == duracion);
        }

        [Fact]
        public void CalcularCostoDelProductoDeMateriales()
        {

            List<EmpleadosEtapas> empleadosEtapas = new List<EmpleadosEtapas>() { new EmpleadosEtapas(new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1 }, new Etapas(20, "Cerrucho")) };

            Orden proc = new Orden(new List<Orden>() { new Orden(empleadosEtapas,
                                                                        new List<MateriasPrima>() { new MateriasPrima() { Nombre = "Pintura", Id = 1, Cantidad = 30, Costo = 1000 } },DateTime.Now,"Fiat") });

            decimal costo = proc.CalcularCostoProducto();
            Assert.True(30000 == costo);
        }

        [Fact]
        public void CalcularDuracionEnDias()
        {
            DateTime duracion = orden.CalcularFechaProducto();

            Assert.True(DateTime.Now.AddDays(3).Date == duracion.Date);
        }

        [Fact]
        public void SePuedeCerrarOrden()
        {
            DateTime duracion = orden.CalcularFechaProducto();
            Assert.False(DateTime.Now.Date > duracion);
        }

        [Fact]
        public void CalcularAsignacionDeOperarios()
        {
            Dictionary<Empleado, List<Procesos>> empleado = orden.CalcularAsignacionPorPuesto("Carpintero");
            var emp = new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1, Puesto = new Puestos() { Descripcion = "Hacer Muebles", Nombre = "Carpintero" } };

            List<Procesos> valor = empleado.Where(x => x.Key.Nombre.Equals("lucas")).Select(x => x.Value).ToList()[0];


            Assert.True(valor[0].FechaDesde.Date.Equals(DateTime.Now.Date));
            Assert.True(valor[0].FechaHasta.Date.Equals(DateTime.Now.Date.AddDays(2).Date));
        }

        [Fact]
        public void SeleccionarEmpleadosPorEtapas()
        {
            Dictionary<List<Empleado>, List<Procesos>> empleados = orden.CalcularEmpleadosPorOT("Fiat");
            var empleado = new Empleado() { Nombre = "lucas", Dni = 32638916, Id = 1, Puesto = new Puestos() { Nombre = "Carpintero" } };
            Assert.True(empleados.Keys.First().First().Dni.Equals(empleado.Dni));
            Assert.Equal(empleados.Keys.First().First().Puesto.Nombre, empleado.Puesto.Nombre);

            Assert.True(empleados.Values.First().First().FechaHasta.Date.Equals(DateTime.Now.AddDays(2).Date));
        }


    }
}

