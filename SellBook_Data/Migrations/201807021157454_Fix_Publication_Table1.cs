namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Publication_Table1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Publications", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Publications", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publications", "IsDeleted");
            DropColumn("dbo.Publications", "IsArchived");
            DropColumn("dbo.Publications", "IsActive");
        }
    }
}
