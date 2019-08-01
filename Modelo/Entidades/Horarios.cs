using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Horarios
    {
        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
