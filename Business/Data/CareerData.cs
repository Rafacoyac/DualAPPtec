using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class CareerData
    {
        public static Boolean Crear(string clave, string nombre, int intitutoId)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var ca = new Career
            {
                Key = clave,
                Name = nombre,
                InstitutionID = intitutoId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Careers.Add(ca);
            data.SaveChanges();

            if (ca != null)
                existe = true;


            return existe;
        }


        public static List<CareerAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from career in Contexto.Careers
                                 where career.Status == "1"
                                 select new CareerAllModel
                                 {
                                     Clave = career.Key,
                                     Nombre = career.Name,
                                     InstitucionId = career.InstitutionID,
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(CareerAllModel career)
        {
            using (var Contexto = new ApptecEntities())
            {
                Boolean existe = false;

                ApptecEntities data = new ApptecEntities();
                var consulta = data.Careers.First(d => d.CareersID == career.Id);
                if (consulta != null)
                {
                    consulta.Key=career.Clave;
                    consulta.Name = career.Nombre;
                    consulta.InstitutionID = career.InstitucionId;
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
            var consulta = data.Careers.First(d => d.CareersID == Id);
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
