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
    [RoutePrefix("Api/Speciality")]
    public class SpecialityController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]SpecialityModel speciality)
        {
            var consulta = SpecialityData.Crear(speciality.Nombre, speciality.InstitucionId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = GroupData.Mostrar();
            return Ok(consulta);
        }
    }
}
