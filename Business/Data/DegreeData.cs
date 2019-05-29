using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Model;
using Data;

namespace Business.Data
{
    public class DegreeData
    {
        public static Boolean Crear(string Nombre)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var d = new Degree
            {
                Name = Nombre,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Degrees.Add(d);
            data.SaveChanges();

            if (d != null)
                existe = true;

            return existe;
        }

        public static List<DegreeAllModel> Update(int ID)
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from degree in Contexto.Degrees
                                 where degree.Status == "1"
                                 select new DegreeAllModel
                                 {
                                     Nombre = degree.Name
                                 }).ToList();
                return Resultado;

            }

           
        }

        public static Boolean Update2(DegreeAllModel degree)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            DegreeAllModel deg = new DegreeAllModel();
            var consulta = data.Degrees.First(d => d.DegreeID == degree.Id);
            if (consulta != null)
            {
                consulta.Name = degree.Nombre;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = "Nuevo";
                data.SaveChanges();
                existe = true;
            }
          
            return existe;
        }


        public static List<DegreeAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from degree in Contexto.Degrees
                                 where degree.Status == "1"
                                 select new DegreeAllModel
                                 {
                                     Nombre = degree.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            ApptecEntities data = new ApptecEntities();
            var consulta = data.Degrees.First(d => d.DegreeID == Id);
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
