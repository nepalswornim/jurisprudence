//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JurisprudenceFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AddedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Role { get; set; }
    }
}
