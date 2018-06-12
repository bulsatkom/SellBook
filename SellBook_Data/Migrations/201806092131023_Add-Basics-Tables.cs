namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        SenderId = c.Guid(nullable: false),
                        ReceiverId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        IsFavourite = c.Boolean(nullable: false),
                        IsDelеted = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SenderId = c.Guid(nullable: false),
                        ReceiverId = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                        SendedOn = c.DateTime(nullable: false),
                        Chat_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.Chat_Id)
                .Index(t => t.Chat_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegionId = c.Guid(nullable: false),
                        IsCity = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 70),
                        Description = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        CategoryId = c.Guid(nullable: false),
                        SubCategoryId = c.Guid(nullable: false),
                        PhoneNumber = c.String(),
                        Views = c.Int(nullable: false),
                        ViewPhone = c.Int(nullable: false),
                        AddAssFavourite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "RegionId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "CityId", c => c.Guid(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publications", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Messages", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Publications", new[] { "ApplicationUserId" });
            DropIndex("dbo.Cities", new[] { "RegionId" });
            DropIndex("dbo.Messages", new[] { "Chat_Id" });
            DropIndex("dbo.Chats", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "CityId");
            DropColumn("dbo.AspNetUsers", "RegionId");
            DropTable("dbo.Regions");
            DropTable("dbo.Publications");
            DropTable("dbo.Cities");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
    }
}
