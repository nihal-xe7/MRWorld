namespace MRWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddMovies", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddMovies", "UserId");
        }
    }
}
