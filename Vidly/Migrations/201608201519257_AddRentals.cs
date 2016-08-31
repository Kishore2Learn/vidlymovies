namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        MyProperty = c.DateTime(),
                        Customer_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                        UserID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID_Id)
                .Index(t => t.Customer_ID)
                .Index(t => t.Movie_ID)
                .Index(t => t.UserID_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "UserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rentals", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "UserID_Id" });
            DropIndex("dbo.Rentals", new[] { "Movie_ID" });
            DropIndex("dbo.Rentals", new[] { "Customer_ID" });
            DropTable("dbo.Rentals");
        }
    }
}
