﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JurisprudenceFinal.Models.ModelClasses
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime AddedDate { get; set; }
    }
}