namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Category_Table_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Color", c => c.String());
            AlterColumn("dbo.Categories", "ImageSrc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ImageSrc", c => c.String());
            DropColumn("dbo.Categories", "Color");
        }
    }
}
