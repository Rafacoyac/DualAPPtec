//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        public int AdminsID { get; set; }
        public string Name { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }
        public string Users { get; set; }
        public string Pass { get; set; }
        public int InstitutionID { get; set; }
        public string Photo { get; set; }
        public System.DateTime DateTimeCreation { get; set; }
        public System.DateTime DateTimeModification { get; set; }
        public string UserCreation { get; set; }
        public string UserModification { get; set; }
        public bool Status { get; set; }
    
        public virtual Institution Institution { get; set; }
    }
}
