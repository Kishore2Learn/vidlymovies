namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRentals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "UserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "UserID_Id" });
            DropColumn("dbo.Rentals", "UserID_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "UserID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rentals", "UserID_Id");
            AddForeignKey("dbo.Rentals", "UserID_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
