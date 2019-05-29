using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class EmployerData
    {
        public static Boolean Crear(string Nombre, string Apellidop, string Apellidom, string Rfc, int RolId, int InstitucioId)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var s = new Employer
            {
                Name = Nombre,
                LastNameP= Apellidop,
                LastNameM = Apellidom,
                RFC = Rfc,
                RolesID=RolId,
                InstitutionID=InstitucioId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Employers.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        public static List<EmployerAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from employer in Contexto.Employers
                                 where employer.Status == "1"
                                 select new EmployerAllModel
                                 {
                                     Nombre = employer.Name,
                                     Apellidop = employer.LastNameP,
                                     Apellidom = employer.LastNameM,
                                     Rfc = employer.RFC,
                                     RolId = employer.RolesID,
                                     IntitucionId = employer.InstitutionID
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(EmployerAllModel employer)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Employers.First(d => d.EmployersID == employer.Id);
            if (consulta != null)
            {
                consulta.Name=employer.Nombre;
                consulta.LastNameP = employer.Apellidop;
                consulta.LastNameM = employer.Apellidom;
                consulta.RFC = employer.Rfc;
                consulta.RolesID = employer.RolId;
                consulta.InstitutionID = employer.IntitucionId;
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
            var consulta = data.Employers.First(d => d.EmployersID == Id);
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