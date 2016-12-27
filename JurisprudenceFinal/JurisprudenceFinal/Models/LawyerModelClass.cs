using System;
using System.Web.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JurisprudenceFinal.Models
{
    public class LawyerModelClass
    {
        public int LawyerID { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public Nullable<int> CasesSolved { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Specialty { get; set; }
        public string DateJoined { get; set; }
        public Nullable<int> Age { get; set; }
        
    }
        
    }
