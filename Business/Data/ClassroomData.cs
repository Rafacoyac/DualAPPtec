using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class ClassroomData
    {
        public static Boolean Crear(string clave, string nombre, string descripcion, int intitutoId, int tipoAula)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var c = new Classroom
            {
                Clave = clave,
                Name = nombre,
                Description = descripcion,
                InstitutionID = intitutoId,
                ClassRoomTypeID = tipoAula,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Classrooms.Add(c);
            data.SaveChanges();

            if (c != null)
                existe = true;


            return existe;
        }


        public static List<ClassroomAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from classroom in Contexto.Classrooms
                                 where classroom.Status == "1"
                                 select new ClassroomAllModel
                                 {
                                     Clave = classroom.Clave,
                                     Nombre = classroom.Name,
                                     Descripcion = classroom.Description,
                                     IntitucionId = classroom.InstitutionID,
                                     TipoAula = classroom.ClassRoomTypeID
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Atualizar(ClassroomAllModel classroom)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Classrooms.First(d => d.ClassroomID == classroom.Id);
            if (consulta != null)
            {
                consulta.Clave = classroom.Clave;
                consulta.Name = classroom.Nombre;
                consulta.Description = classroom.Descripcion;
                consulta.InstitutionID = classroom.IntitucionId;
                consulta.ClassRoomTypeID = classroom.TipoAula;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = "Nuevo";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }


        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Classrooms.First(d => d.ClassroomID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /*
        public static List<ClassroomTypeAllModel> ObtenerAula()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from classroomType in Contexto.ClassRoomTypes

                                 select new ClassroomTypeAllModel
                                 {
                                     Nombre = classroomType.Name,
                                 }).ToList();
                return Resultado;
            }
        }
        */
    }
}