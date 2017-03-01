using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Parrot
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Color { get; set; }

        public int CageId { get; set; }
        public virtual Cage Cage { get; set; }
    }
}