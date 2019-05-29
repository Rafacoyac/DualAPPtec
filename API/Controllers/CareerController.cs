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
    [RoutePrefix("Api/Career")]
    public class CareerController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]CareerModel career)
        {
            var consulta = CareerData.Crear(career.Clave, career.Nombre, career.InstitucionId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = CareerData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(CareerModel career)
        {
            var consulta = CareerData.Eliminar(career.CareerId);
            return Ok(consulta);
        }
    }
}
