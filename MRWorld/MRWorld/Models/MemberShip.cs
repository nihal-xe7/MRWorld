using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRWorld.Models
{
    public class MemberShip
    {
        public int  Id { get; set; }
        public int  UserId { get; set; }


        [ForeignKey("UserId")]
        public virtual Users Users { set; get; }

        public string MemberShipType { get; set; }

        public string Paid { get; set; }

        public string joinDate  { get; set; }

        public string  ExpireDate { get; set; }
    }
}