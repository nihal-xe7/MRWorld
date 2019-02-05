namespace MRWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddMovies");
        }
    }
}
