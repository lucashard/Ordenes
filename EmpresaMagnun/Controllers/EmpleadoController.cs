using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace EmpresaMagnun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        

        // GET api/values
        private EmpresaMagnun.Dominio dominio=new EmpresaMagnun.Dominio();
        private List<Empleado> list;

        /// <summary>
        /// Devuelve la lista de todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Empleado> Get()
        {
            return dominio.empleados;
        }

        // GET api/values/5
        /// <summary>
        /// Trae los empleados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// 1
        /// </remarks>
        [HttpGet("{id}")]
        public Modelo.Empleado Get(int id)
        {
            dominio.empleados = new List<Empleado>();
            dominio.empleados.Add(new Empleado() { Dni = 32638916, Id = 1, Nombre = "Lucas" });
            return dominio.empleados[0];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Modelo.Empleado value)
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
