namespace CageFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserMovie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserProfileID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.UserProfileID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        ReleaseDate = c.DateTime(nullable: false),
                        ImdbLink = c.String(),
                        RottenTomatoesLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserMovie", new[] { "MovieID" });
            DropIndex("dbo.UserMovie", new[] { "UserProfileID" });
            DropForeignKey("dbo.UserMovie", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.UserMovie", "UserProfileID", "dbo.UserProfile");
            DropTable("dbo.Movie");
            DropTable("dbo.UserMovie");
            DropTable("dbo.UserProfile");
        }
    }
}
