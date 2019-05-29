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
    [RoutePrefix("Api/Lesson")]
    public class LessonsController : ApiController
    {

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]LessonModel lessons)
        {
            var consulta = LessonData.Crear(lessons.Dia, lessons.EmpleadosId, lessons.HoraIn, lessons.HoraFin, lessons.AulaId, lessons.MateriaId, lessons.GrupoId);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = LessonData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(LessonModel lesson)
        {
            var consulta = LessonData.Eliminar(lesson.LessonId);
            return Ok(consulta);
        }
    }
}
