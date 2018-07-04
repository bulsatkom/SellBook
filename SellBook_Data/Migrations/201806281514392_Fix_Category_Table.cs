namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Category_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageSrc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImageSrc");
        }
    }
}
