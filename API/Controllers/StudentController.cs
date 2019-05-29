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
    [RoutePrefix("Api/Student")]
    public class StudentController : ApiController
    {

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]StudentModel student)
        {
            var consulta = StudentData.Crear(student.Matricula, student.Nombre, student.Apellidop, student.Apellidom, student.Telefono, student.InstitucionId, student.GrupoId, student.Password);
            return Ok(consulta);
        }

       
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            var consulta = StudentData.Mostrar();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(StudentModel student)
        {
            var consulta = StudentData.Eliminar(student.StudentId);
            return Ok(consulta);
        }

    }
}
