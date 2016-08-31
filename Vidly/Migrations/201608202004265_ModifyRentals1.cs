namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRentals1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "MyProperty", c => c.DateTime());
            DropColumn("dbo.Rentals", "DateReturned");
        }
    }
}
