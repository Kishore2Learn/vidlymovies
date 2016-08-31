namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailablStockToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Byte(nullable: false));
            Sql("update dbo.movies set AvailableStock = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
