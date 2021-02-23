using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class Empleado
    {
        public int Id { get; set; }
        [Display(Name = "Nombre", Order = 1,
        Prompt = "Por favor ingrese un nombre", Description = "Nombre")]
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
            if (empleado.Nombre.Equals(string.Empty))
            {
                string name = getDisplayNameProperty(empleado);
                throw new ArgumentException(String.Format("No puede ser vacio el " + name));
            }
            list.Add(empleado);
        }

        private static string getDisplayNameProperty<T>(T empleado)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(empleado);
            string name = string.Empty;
            foreach (PropertyDescriptor property in properties)
            {
                if (property.Name == "Nombre")
                {
                    name = property.DisplayName; 
                }
            }

            return name;
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
