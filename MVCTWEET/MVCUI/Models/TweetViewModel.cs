using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCUI.Models
{
    public class TweetViewModel
    {
        [Required]
       
        public int TweetID { get; set; } 
        [StringLength(100)]
        public string message { get; set; }

        public DateTime created { get; set; }
        
        public string userid { get; set; }

    }
}