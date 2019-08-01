using System.Collections.Generic;
using Modelo;
using Xunit;
namespace Test
{
    public class TestSueldo
    {
        public Sueldos sueldos;
        public TestSueldo()
        {
            sueldos = new Sueldos(new Sueldos() { SueldoBruto = 60000, Empleado = new Modelo.Empleado() { Dni = 32638916, Nombre = "Lucas", Id = 1,
                HorasExtras = new List<Modelo.HorasExtras>() { new Modelo.HorasExtras { HoraInicio=new System.TimeSpan(18,0,0),HoraFin=new System.TimeSpan(23,0,0),EsFeriado=false} }
            } });
        }

        [Fact]
        public void CalcularSueldoNeto()
        {
            decimal sueldo = sueldos.CalcularSuedoNeto(sueldos.SueldoBruto);
            Assert.True(49800 == sueldo);
        }

        [Fact]
        public void CalcularHora()
        {
            decimal horaNeta = sueldos.CalcularSuedoNeto(sueldos.SueldoBruto);
            decimal horasueldo = sueldos.CalcularHoraSueldo(horaNeta);
            decimal hora = decimal.Parse("311.25");
            Assert.True(hora == horasueldo);
        }

        [Fact]
        public void CalcularHorasExtrasDespuesDeLas18ConCargas()
        {
            decimal horaExtra = sueldos.CalcularHoraExtra(sueldos.SueldoBruto,sueldos.Empleado.HorasExtras);

            Assert.True(horaExtra == decimal.Parse("3750"));

        }

    }
}
