using System.Data.Entity;

namespace WebApplication7.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Parrot> Parrots { get; set; }

        public DbSet<Cage> Cages { get; set; }
    }
}