using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
}