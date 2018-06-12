namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTableAndSomeFixes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Name = c.String(),
                        IsMain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .Index(t => t.PublicationId);
            
            AddColumn("dbo.Publications", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Publications", "IsContracting", c => c.Boolean(nullable: false));
            AddColumn("dbo.Publications", "AddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PublicationId", "dbo.Publications");
            DropIndex("dbo.Images", new[] { "PublicationId" });
            DropColumn("dbo.Publications", "AddedOn");
            DropColumn("dbo.Publications", "IsContracting");
            DropColumn("dbo.Publications", "Price");
            DropTable("dbo.Images");
        }
    }
}
