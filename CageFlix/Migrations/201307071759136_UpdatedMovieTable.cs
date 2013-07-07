namespace CageFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "ThumnailImageUrl", c => c.String());
            AddColumn("dbo.Movie", "ProfileImageUrl", c => c.String());
            AddColumn("dbo.Movie", "DetailedImageUrl", c => c.String());
            AddColumn("dbo.Movie", "OriginalImageUrl", c => c.String());
            AddColumn("dbo.Movie", "MpaaRating", c => c.String(maxLength: 10));
            AddColumn("dbo.Movie", "Runtime", c => c.Int());
            AddColumn("dbo.Movie", "CriticsConsensus", c => c.String());
            AddColumn("dbo.Movie", "Synopsis", c => c.String());
            AddColumn("dbo.Movie", "RottenTomatoesApiUrl", c => c.String());
            AlterColumn("dbo.Movie", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Movie", "ReleaseYear", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "ReleaseYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Movie", "Title", c => c.String(maxLength: 250));
            DropColumn("dbo.Movie", "RottenTomatoesApiUrl");
            DropColumn("dbo.Movie", "Synopsis");
            DropColumn("dbo.Movie", "CriticsConsensus");
            DropColumn("dbo.Movie", "Runtime");
            DropColumn("dbo.Movie", "MpaaRating");
            DropColumn("dbo.Movie", "OriginalImageUrl");
            DropColumn("dbo.Movie", "DetailedImageUrl");
            DropColumn("dbo.Movie", "ProfileImageUrl");
            DropColumn("dbo.Movie", "ThumnailImageUrl");
        }
    }
}
