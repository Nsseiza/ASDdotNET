namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Gigid", "dbo.Gigs");
            AddForeignKey("dbo.Attendances", "Gigid", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Gigid", "dbo.Gigs");
            AddForeignKey("dbo.Attendances", "Gigid", "dbo.Gigs", "Id", cascadeDelete: true);
        }
    }
}
