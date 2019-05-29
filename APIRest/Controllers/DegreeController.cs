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
    [RoutePrefix("Api/Degree")]
    public class DegreeController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]DegreeModel degree)
        {
            var consulta = DegreeData.Crear(degree.Nombre);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody]DegreeModel degree)
        {
            var consulta = DegreeData.Actualizar(degree.DegreeId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = DegreeData.Mostrar();
            return Ok(consulta);
        }

    }
}
