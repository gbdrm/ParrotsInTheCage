namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Owner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parrots", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parrots", "OwnerId");
            AddForeignKey("dbo.Parrots", "OwnerId", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Parrots", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Parrots", new[] { "OwnerId" });
            DropColumn("dbo.Parrots", "OwnerId");
        }
    }
}
