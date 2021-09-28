using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Security
{
    public class JwtObject
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Expire { get; set; }
    }
}