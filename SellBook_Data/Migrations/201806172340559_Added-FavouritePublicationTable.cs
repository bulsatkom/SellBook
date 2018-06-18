namespace SellBook_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFavouritePublicationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouritePublications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        PublicationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FavouritePublications");
        }
    }
}
