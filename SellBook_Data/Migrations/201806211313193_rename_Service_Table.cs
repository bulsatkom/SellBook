namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_Service_Table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Services", newName: "ServicePublicationDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ServicePublicationDetails", newName: "Services");
        }
    }
}
