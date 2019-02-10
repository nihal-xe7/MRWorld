using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRWorld.Models
{
    public class Movie
    {

        
        public int Id { get; set; }
        [Required] 
        [StringLength(255)]
        public string Name { get; set; }

        public string Genre { get; set; }

        public string  ReleaseDate { get; set; }

        public string Rating { get; set; }

        public string Description { get; set; }


        

        

        
    }
}