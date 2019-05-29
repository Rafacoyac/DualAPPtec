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
    [RoutePrefix("Api/Classroom")]
    public class ClassroomController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]ClassroomModel classroom)
        {
            var consulta = ClassroomData.Crear(classroom.Clave,classroom.Nombre,classroom.Descripcion,classroom.Institucion,classroom.TipoAula);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = ClassroomData.Mostrar();
            return Ok(consulta);
        }

    }
}
