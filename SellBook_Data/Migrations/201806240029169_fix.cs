namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChildrensPublicationDetails", "Number", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChildrensPublicationDetails", "Number", c => c.Int(nullable: false));
        }
    }
}
