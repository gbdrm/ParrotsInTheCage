using WebApplication7.Models;

namespace WebApplication7.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication7.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication7.Models.DataContext";
        }

        protected override void Seed(WebApplication7.Models.DataContext context)
        {
            
        }
    }
}
