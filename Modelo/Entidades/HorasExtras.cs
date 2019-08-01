using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class HorasExtras
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public Boolean EsFeriado { get; set; }
    }
}
