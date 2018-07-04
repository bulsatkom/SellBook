namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclothessss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClothesPublicationDetails", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClothesPublicationDetails", "Size", c => c.String(nullable: false));
        }
    }
}
