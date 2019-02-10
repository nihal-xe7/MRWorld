using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MRWorld.Models
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MemberShipType { get; set; }
        
        [Required]
        public string Password { set; get; }

        [Compare("Password")]
        public string ConfirmPassword { set; get; }
    }
}