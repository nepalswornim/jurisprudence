
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JurisprudenceFinal.Models
{
    public class CaseModelClass
    {
        public int CaseID { get; set; }
        public string CaseName { get; set; }
        public string Lawyer { get; set; }
        public Nullable<int> UserID { get; set; }
        public string CaseType { get; set; }
        public string CaseDetails { get; set; }
        public Nullable<bool> Solved { get; set; }
        public int LawyerId { get; set; }
       
    }
}