using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class SubjectData
    {
        public static Boolean Crear(string Clave, string Nombre, int Creditos, int Carreraid, int EspecialidadId)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var s = new Subject
            {
                Clave = Clave,
                Name = Nombre,
                Credits = Creditos,
                CareersID = Carreraid,
                SpecialityID = EspecialidadId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Subjects.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        public static List<SubjectAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from subject in Contexto.Subjects
                                 where subject.Status == "1"
                                 select new SubjectAllModel
                                 {
                                     Clave = subject.Clave,
                                     Nombre = subject.Name,
                                     Creditos = subject.Credits,
                                     CarreraId = subject.CareersID,
                                     EspecialidadId = subject.SpecialityID
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(SubjectAllModel subject)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Subjects.First(d => d.SubjectsID == subject.Id);
            if (consulta != null)
            {
                consulta.Clave = subject.Clave;
                consulta.Name = subject.Nombre;
                consulta.Credits = subject.Creditos;
                consulta.CareersID = subject.CarreraId;
                consulta.SpecialityID = subject.EspecialidadId;
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
            var consulta = data.Subjects.First(d => d.SubjectsID == Id);
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
