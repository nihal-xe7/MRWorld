namespace MRWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShips : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MemberShipType = c.String(),
                        Paid = c.String(),
                        joinDate = c.String(),
                        ExpireDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberShips", "UserId", "dbo.Users");
            DropIndex("dbo.MemberShips", new[] { "UserId" });
            DropTable("dbo.MemberShips");
        }
    }
}
