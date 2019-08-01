using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace EmpresaMagnun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public EmpleadoController() : this(new List<Empleado>()) { }
        
        public EmpleadoController(List<Empleado> list)
        {
            dominio.empleados = list;
       
        }

        // GET api/values
        private EmpresaMagnun.Dominio dominio=new EmpresaMagnun.Dominio();
        private List<Empleado> list;

        [HttpGet]
        public List<Empleado> Get()
        {
            return dominio.empleados;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Modelo.Empleado Get(int id)
        {
            return dominio.empleados.Find(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post(Modelo.Empleado value)
        {
            dominio.empleados.Add(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dominio.empleados.Remove(dominio.empleados.Find(x=>x.Id==id));
        }
    }
}
