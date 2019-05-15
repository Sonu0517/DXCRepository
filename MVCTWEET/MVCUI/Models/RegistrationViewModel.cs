using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCUI.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(25)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50),DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(50),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(40),DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime Joined { get; set; }
    }
}