namespace Sparkles.GenericRestService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Document = c.String(),
                        CreatedTimestamp = c.DateTime(nullable: false),
                        UpdatedTimestamp = c.DateTime(nullable: false),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objects", "Resource_Id", "dbo.Resources");
            DropIndex("dbo.Objects", new[] { "Resource_Id" });
            DropTable("dbo.Resources");
            DropTable("dbo.Objects");
        }
    }
}
