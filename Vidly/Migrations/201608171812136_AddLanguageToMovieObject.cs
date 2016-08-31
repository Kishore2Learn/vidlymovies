namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguageToMovieObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Language");
        }
    }
}
