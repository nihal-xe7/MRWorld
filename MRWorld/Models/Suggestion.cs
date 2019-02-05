using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRWorld.Models
{
    public class Suggestion
    {
        public List<Movie> Movies { set; get; }


        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string AddedBy { get; set; }
        public string Rating { set;get; }

        public string ReleaseDate { get; set; }

        [NotMapped]
        public int Id { get; set; }
    }
}