namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Publication_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "RegionId", c => c.Guid(nullable: false));
            AddColumn("dbo.Publications", "CityId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Color", c => c.String(nullable: false));
            CreateIndex("dbo.Publications", "CategoryId");
            AddForeignKey("dbo.Publications", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publications", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Publications", new[] { "CategoryId" });
            AlterColumn("dbo.Categories", "Color", c => c.String());
            DropColumn("dbo.Publications", "CityId");
            DropColumn("dbo.Publications", "RegionId");
        }
    }
}
