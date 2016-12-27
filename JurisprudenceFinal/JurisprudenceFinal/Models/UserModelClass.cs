using System;

namespace JurisprudenceFinal.Models
{
    public class UserModelClass
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