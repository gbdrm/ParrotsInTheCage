using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Cage
    {
        public int CageId { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Parrot> Parrots { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser CageOwner { get; set; }

        public string OwnerId { get; set; }
    }
}