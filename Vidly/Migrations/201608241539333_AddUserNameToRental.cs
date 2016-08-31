namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "UserName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "UserName");
        }
    }
}
