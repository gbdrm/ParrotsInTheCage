using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication7.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Parrot> Parrots { get; set; }

        public DbSet<Cage> Cages { get; set; }
        
    }

    public class ApplicationUser : IdentityUser
    {
    }
}