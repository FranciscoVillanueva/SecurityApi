using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class NewUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}