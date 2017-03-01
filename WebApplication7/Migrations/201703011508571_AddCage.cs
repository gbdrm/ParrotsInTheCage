namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cages",
                c => new
                    {
                        CageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CageId);
            
            AddColumn("dbo.Parrots", "CageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parrots", "CageId");
            AddForeignKey("dbo.Parrots", "CageId", "dbo.Cages", "CageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parrots", "CageId", "dbo.Cages");
            DropIndex("dbo.Parrots", new[] { "CageId" });
            DropColumn("dbo.Parrots", "CageId");
            DropTable("dbo.Cages");
        }
    }
}
