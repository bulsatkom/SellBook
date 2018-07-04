namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfewtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalsPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContracting = c.Boolean(nullable: false),
                        delivery = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        SubCategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.ChildrensPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                        Condition = c.String(nullable: false),
                        Delivery = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        SuitableFor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClothesPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                        Condition = c.String(nullable: false),
                        Delivery = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.electronicsPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                        Condition = c.String(nullable: false),
                        Delivery = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExcursionsAndHolidaysPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InitialPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                        Condition = c.String(nullable: false),
                        Delivery = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoesPublicationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        IsContacting = c.Boolean(nullable: false),
                        Condition = c.String(nullable: false),
                        Delivery = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Publications", "SubSubCategoryId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubSubCategories", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.SubSubCategories", new[] { "SubCategoryId" });
            DropColumn("dbo.Publications", "SubSubCategoryId");
            DropTable("dbo.ShoesPublicationDetails");
            DropTable("dbo.InitialPublicationDetails");
            DropTable("dbo.ExcursionsAndHolidaysPublicationDetails");
            DropTable("dbo.electronicsPublicationDetails");
            DropTable("dbo.ClothesPublicationDetails");
            DropTable("dbo.ChildrensPublicationDetails");
            DropTable("dbo.SubSubCategories");
            DropTable("dbo.AnimalsPublicationDetails");
        }
    }
}
