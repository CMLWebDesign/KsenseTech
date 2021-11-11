using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KsenseChallenge.Models
{
    public class Users
    {
        [Key]
        [Required]

        public int id { get; set; }

        [Required]
        public string name { get; set; }
      

    }
}