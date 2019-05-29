using API.Models;
using Business.Data;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("Api/DegreeSubject")]
    public class DegreeSubjectController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]DegreeSubjectModel degreeSubject)
        {
            var consulta = DegreeSubjectData.Crear(degreeSubject.DegreeId, degreeSubject.SubjectId);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = DegreeSubjectData.Mostrar();
            return Ok(consulta);
        }

    }
}
