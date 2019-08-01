using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class EmpleadosEtapas
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public Etapas Etapas { get; set; }

        public EmpleadosEtapas(Empleado empleado,Etapas etapas)
        {
            this.Empleado = empleado;
            this.Etapas = etapas;
        }
    }
}
