namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalReceivedByNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "ReceivedBy", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "ReceivedBy", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
