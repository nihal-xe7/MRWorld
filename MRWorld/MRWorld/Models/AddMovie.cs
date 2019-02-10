using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRWorld.Models
{
    public class AddMovie
    {
        [NotMapped]
        public List<Movie> Movies { get; set; }

        [NotMapped] 
        public List<Users> User { get; set; }

        [NotMapped]
        public List<AddMovie> MovieList { set; get; }


        public int ID { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Date { get; set; }
        public string Description { set; get; }

    }
}