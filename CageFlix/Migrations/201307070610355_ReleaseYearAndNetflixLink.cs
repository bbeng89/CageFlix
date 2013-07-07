namespace CageFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleaseYearAndNetflixLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "ReleaseYear", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "NetflixLink", c => c.String());
            DropColumn("dbo.Movie", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movie", "NetflixLink");
            DropColumn("dbo.Movie", "ReleaseYear");
        }
    }
}
