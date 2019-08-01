using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Dni { get; set; }
        public Horarios Horarios { get; set; }
        public Puestos Puesto { get; set; }
        public List<HorasExtras> HorasExtras { get; set; }

        private List<Empleado> list;

        public Empleado() : this(new List<Empleado>())
        {

        }

        public Empleado(List<Empleado> list)
        {
            this.list = list;
        }

        public void Add(Empleado empleado)
        {
            list.Add(empleado);
        }

        public void BorrarEmpleado(Empleado empleado)
        {
            list.Remove(list.Find(x => x.Id == empleado.Id));
        }

        public Empleado Get(int id)
        {
            return list.Find(x => x.Id == id);
        }

        public List<Empleado> Get()
        {
            return list;
        }

        public void Delete(int id)
        {
            list.RemoveAt(id);
        }
    }
}
