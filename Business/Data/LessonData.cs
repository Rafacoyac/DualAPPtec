using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class LessonData
    {

        public static Boolean Crear(string Dia, int EmpleadoID, TimeSpan HoraIn, TimeSpan HoraFin, int AulaId, int MateriaId, int GrupoId)
        {
         ApptecEntities data = new ApptecEntities();
        Boolean existe = false;
        var s = new Lesson
        {
            Days=Dia,
            EmployersID=EmpleadoID,
            HousStart=HoraIn,
            HourFinish=HoraFin,
            ClassroomID=AulaId,
            SubjectsID=MateriaId,
            GroupsID=GrupoId,
            DateTimeCreation = DateTime.Now,
            DateTimeModification = DateTime.Now,
            UserCreation = "Beatriz",
            UserModification = "Bea",
            Status = "1"
        };
        data.Lessons.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


    public static List<LessonAllModel> Mostrar()
    {
        using (var Contexto = new ApptecEntities())
        {
            var Resultado = (from lesson in Contexto.Lessons
                             where lesson.Status == "1"
                             select new LessonAllModel
                             {
                                 Dia=lesson.Days,
                                 EmpleadosId=lesson.EmployersID,
                                 HoraIn=lesson.HousStart,
                                 HoraFin=lesson.HourFinish,
                                 AulaId=lesson.ClassroomID,
                                 MateriaId=lesson.SubjectsID,
                                 GrupoId=lesson.GroupsID
                             }).ToList();
            return Resultado;
        }
    }

        public static Boolean Actualizar(LessonAllModel lesson)
        {
            using (var Contexto = new ApptecEntities())
            {
                Boolean existe = false;

                ApptecEntities data = new ApptecEntities();
                var consulta = data.Lessons.First(d => d.LessonsID == lesson.Id);
                if (consulta != null)
                {

                    consulta.Days = lesson.Dia;
                    consulta.EmployersID = lesson.EmpleadosId;
                    consulta.HousStart = lesson.HoraIn;
                    consulta.HourFinish = lesson.HoraFin;
                    consulta.ClassroomID = lesson.AulaId;
                    consulta.SubjectsID = lesson.MateriaId;
                    consulta.GroupsID = lesson.GrupoId;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = "Nuevo";
                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }

        }



        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Lessons.First(d => d.LessonsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }
    }
}