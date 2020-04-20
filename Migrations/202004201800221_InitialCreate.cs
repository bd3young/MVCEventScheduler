namespace MVCEventScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventModel", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.EventModel",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EventName = c.String(nullable: false),
                        EventType = c.String(maxLength: 20),
                        EventHost = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EventDateTime = c.DateTime(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 12),
                        Location = c.String(maxLength: 24),
                        Email = c.String(nullable: false),
                        junk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "UserID", "dbo.User");
            DropForeignKey("dbo.Attendance", "EventID", "dbo.EventModel");
            DropIndex("dbo.Attendance", new[] { "UserID" });
            DropIndex("dbo.Attendance", new[] { "EventID" });
            DropTable("dbo.User");
            DropTable("dbo.EventModel");
            DropTable("dbo.Attendance");
        }
    }
}
