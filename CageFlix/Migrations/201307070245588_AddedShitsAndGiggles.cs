namespace CageFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShitsAndGiggles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMovie", "Shits", c => c.String());
            AddColumn("dbo.UserMovie", "Giggles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMovie", "Giggles");
            DropColumn("dbo.UserMovie", "Shits");
        }
    }
}
