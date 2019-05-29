using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class SpecialityData
    {
        public static Boolean Crear(string Nombre, int InstitucionId)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var g = new Speciality
            {
                Name = Nombre,
                InstitutionID=InstitucionId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Specialities.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;

            return existe;
        }


        public static List<SpecialityAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from speciality in Contexto.Specialities
                                 where speciality.Status == "1"
                                 select new SpecialityAllModel
                                 {
                                     Nombre = speciality.Name,
                                     InstitucionId=speciality.InstitutionID
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(SpecialityAllModel speciality)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Specialities.First(d => d.SpecialityID == speciality.Id);
            if (consulta != null)
            {
                consulta.Name=speciality.Nombre;
                consulta.InstitutionID = speciality.InstitucionId;
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
            var consulta = data.Specialities.First(d => d.SpecialityID == Id);
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