namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalUserNameAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentedBy", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Rentals", "ReceivedBy", c => c.String(nullable: false, maxLength: 200));
            Sql("update dbo.Rentals set RentedBy = UserName,ReceivedBy=' ' ");
            DropColumn("dbo.Rentals", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "UserName", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Rentals", "ReceivedBy");
            DropColumn("dbo.Rentals", "RentedBy");
        }
    }
}
