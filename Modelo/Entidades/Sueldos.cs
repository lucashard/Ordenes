using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Sueldos
    {
        public Empleado Empleado { get; set; }
        public decimal SueldoBruto { get; set; }
        public decimal SueldoNeto { get; set; }

        public Sueldos(Sueldos sueldo)
        {
            SueldoBruto = sueldo.SueldoBruto;
            SueldoNeto = sueldo.SueldoNeto;
            Empleado = sueldo.Empleado;
        }

        public Sueldos()
        {
        }

        public decimal CalcularSuedoNeto(decimal SueldoBruto)
        {
            this.SueldoNeto = SueldoBruto - (SueldoBruto * 17) / 100;

            return this.SueldoNeto;
        }

        public decimal CalcularHoraExtra(decimal sueldoBruto, List<HorasExtras> horasExtras)
        {
            decimal costo = 0;
            foreach (var item in horasExtras)
            {
                int cantidad = item.HoraFin.Hours - item.HoraInicio.Hours;
                if (item.HoraInicio.Hours >= 18)
                {
                    costo += (CalcularHoraSueldo(sueldoBruto) * 2) * cantidad;
                }
                else
                {
                    costo += (CalcularHoraSueldo(sueldoBruto) * Convert.ToDecimal("1.5")) * cantidad;
                }
            }
            return costo;
        }

        public decimal CalcularHoraSueldo(decimal sueldoBruto)
        {
            var hora = sueldoBruto / 160;
            return hora;
        }
    }
}
