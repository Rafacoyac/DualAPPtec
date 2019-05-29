using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class GroupData
    {
        public static Boolean Crear(string Nombre)
        {
            ApptecEntities data = new ApptecEntities();
            Boolean existe = false;
            var g = new Group
            {
                Name = Nombre,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Beatriz",
                UserModification = "Bea",
                Status = "1"
            };
            data.Groups.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;
        
            return existe;
        }

      
        public static List<GroupAllModel> Mostrar()
        {
            using (var Contexto = new ApptecEntities())
            {
                var Resultado = (from grou in Contexto.Groups
                                 where grou.Status == "1"
                                 select new GroupAllModel
                                 {
                                     Nombre = grou.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(GroupAllModel group)
        {
            using (var Contexto = new ApptecEntities())
            {
                Boolean existe = false;

                ApptecEntities data = new ApptecEntities();
                var consulta = data.Groups.First(d => d.GroupsID == group.Id);
                if (consulta != null)
                {
                  
                    consulta.Name = group.Nombre;
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
            var consulta = data.Groups.First(d => d.GroupsID == Id);
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