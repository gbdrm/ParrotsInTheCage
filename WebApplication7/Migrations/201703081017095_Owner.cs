namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Owner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cages", "OwnerId", c => c.String());
            AddColumn("dbo.Cages", "CageOwner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cages", "CageOwner_Id");
            AddForeignKey("dbo.Cages", "CageOwner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cages", "CageOwner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cages", new[] { "CageOwner_Id" });
            DropColumn("dbo.Cages", "CageOwner_Id");
            DropColumn("dbo.Cages", "OwnerId");
        }
    }
}
