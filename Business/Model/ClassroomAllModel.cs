using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class ClassroomAllModel
    {
        public int Id { get; set; }
        public string Clave { get; set; }
       public string Nombre { get; set; }
       public string Descripcion { get; set; }
       public int IntitucionId { get; set; }
       public int TipoAula { get; set; }
       public DateTime FechaCreacion { get; set; }
       public DateTime FechaMod { get; set; }
       public string UsuarioCreacion { get; set; }
       public string UsuarioMod { get; set; }
       public string Estado { get; set; }
    }
}