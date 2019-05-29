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
    [RoutePrefix("Api/Subject")]
    public class SubjectController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]SubjectModel subject)
        {
            var consulta = SubjectData.Crear(subject.Clave, subject.Nombre, subject.Creditos, subject.CarreraId, subject.EspecialidadId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = SubjectData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(SubjectModel subject)
        {
            var consulta = SubjectData.Eliminar(subject.SubjectId);
            return Ok(consulta);
        }
    }
}
