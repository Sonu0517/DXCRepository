using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCUI.Models
{
    public class loginViewModel
    {
        [Required]
        [StringLength(25)]
        public string Username { get; set; }

        [Required]
        [StringLength(50),DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}