namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFK : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cages", new[] { "CageOwner_Id" });
            DropColumn("dbo.Cages", "OwnerId");
            RenameColumn(table: "dbo.Cages", name: "CageOwner_Id", newName: "OwnerId");
            AlterColumn("dbo.Cages", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cages", "OwnerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cages", new[] { "OwnerId" });
            AlterColumn("dbo.Cages", "OwnerId", c => c.String());
            RenameColumn(table: "dbo.Cages", name: "OwnerId", newName: "CageOwner_Id");
            AddColumn("dbo.Cages", "OwnerId", c => c.String());
            CreateIndex("dbo.Cages", "CageOwner_Id");
        }
    }
}
