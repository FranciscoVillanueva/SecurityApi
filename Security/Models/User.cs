using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class User
    {
        [Required(ErrorMessage = "enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "enter Password")]
        public string Password { get; set; }
    }
}