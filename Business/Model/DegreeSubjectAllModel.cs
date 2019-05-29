using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class DegreeSubjectAllModel
    {
        public int Id { get; set; }
        public int DegreeId { get; set; }
        public int SubjectId { get; set; }
    }
}