namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenreTypesMetaData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenreTypes (ID,GenreType) VALUES (1,'Action')");
            Sql("INSERT INTO MovieGenreTypes (ID,GenreType) VALUES (2,'Comedy')");
            Sql("INSERT INTO MovieGenreTypes (ID,GenreType) VALUES (3,'Family')");
            Sql("INSERT INTO MovieGenreTypes (ID,GenreType) VALUES (4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
