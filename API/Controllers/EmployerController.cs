using API.Models;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("Api/Employer")]
    public class EmployerController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]EmployerModel employer)
        {
            var consulta = EmployerData.Crear(employer.Nombre, employer.Apellidop, employer.Apellidom, employer.Rfc, employer.RolId, employer.IntitucionId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = EmployerData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Update(EmployerModel employer)
        {
            var consulta = EmployerData.Eliminar(employer.EmployerId);
            return Ok(consulta);
        }

        
    }
}

