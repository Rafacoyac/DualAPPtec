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
    [RoutePrefix("Api/Group")]
    public class GroupController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]GroupModel group)
        {
            var consulta = GroupData.Crear(group.Nombre);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = GroupData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(GroupModel group)
        {
            var consulta = GroupData.Eliminar(group.GroupId);
            return Ok(consulta);
        }

    }
}
