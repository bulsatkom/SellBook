namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclothes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClothesPublicationDetails", "Size", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClothesPublicationDetails", "Size", c => c.Int(nullable: false));
        }
    }
}
