namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceAndWorkPublicationDetailTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publications", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Publications", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        SalaryFrom = c.Int(nullable: false),
                        SalaryTo = c.Int(nullable: false),
                        IsContracting = c.Boolean(nullable: false),
                        Bussyness = c.String(nullable: false),
                        Kind = c.String(nullable: false),
                        ForInvalids = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Publications", "PublicationDetailsId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Publications", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Publications", "ApplicationUserId");
            AddForeignKey("dbo.Publications", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Publications", "Price");
            DropColumn("dbo.Publications", "IsContracting");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publications", "IsContracting", c => c.Boolean(nullable: false));
            AddColumn("dbo.Publications", "Price", c => c.Double(nullable: false));
            DropForeignKey("dbo.Publications", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Publications", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Publications", "ApplicationUserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Publications", "PublicationDetailsId");
            DropTable("dbo.WorkPublicationDetails");
            DropTable("dbo.Services");
            CreateIndex("dbo.Publications", "ApplicationUserId");
            AddForeignKey("dbo.Publications", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
