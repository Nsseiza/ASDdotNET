namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Gigid = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attende_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Gigid, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Attende_Id)
                .ForeignKey("dbo.Gigs", t => t.Gigid, cascadeDelete: true)
                .Index(t => t.Gigid)
                .Index(t => t.Attende_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Gigid", "dbo.Gigs");
            DropForeignKey("dbo.Attendances", "Attende_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Attende_Id" });
            DropIndex("dbo.Attendances", new[] { "Gigid" });
            DropTable("dbo.Attendances");
        }
    }
}
