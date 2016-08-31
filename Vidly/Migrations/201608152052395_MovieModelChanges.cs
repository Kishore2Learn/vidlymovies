namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenreTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        GenreType = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "MovieGenreTypesID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreTypesID");
            AddForeignKey("dbo.Movies", "MovieGenreTypesID", "dbo.MovieGenreTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreTypesID", "dbo.MovieGenreTypes");
            DropIndex("dbo.Movies", new[] { "MovieGenreTypesID" });
            DropColumn("dbo.Movies", "MovieGenreTypesID");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.MovieGenreTypes");
        }
    }
}
