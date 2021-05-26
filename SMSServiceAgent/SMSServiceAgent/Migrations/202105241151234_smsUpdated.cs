namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SMS", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.SMS", new[] { "ApplicationId" });
            AddColumn("dbo.SMS", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SMS", "ApplicationId", c => c.String());
            CreateIndex("dbo.SMS", "ApplicationUser_Id");
            AddForeignKey("dbo.SMS", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SMS", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SMS", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.SMS", "ApplicationId", c => c.String(maxLength: 128));
            DropColumn("dbo.SMS", "ApplicationUser_Id");
            CreateIndex("dbo.SMS", "ApplicationId");
            AddForeignKey("dbo.SMS", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
