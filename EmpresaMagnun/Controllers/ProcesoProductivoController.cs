using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaMagnun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoProductivoController : ControllerBase
    {
        private List<ProcesoProductivoController> list;

        public ProcesoProductivoController():this(new List<ProcesoProductivoController>())
        {

        }

        public ProcesoProductivoController(List<ProcesoProductivoController> list)
        {
            this.list = list;
        }


    }
}