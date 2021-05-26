namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsSustus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMSStatus", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.SMSStatus", "ApplicationUser_Id");
            AddForeignKey("dbo.SMSStatus", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SMSStatus", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SMSStatus", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.SMSStatus", "ApplicationUser_Id");
        }
    }
}
