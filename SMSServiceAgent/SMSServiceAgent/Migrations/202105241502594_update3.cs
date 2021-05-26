namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SMSStatus", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.SMSStatus", new[] { "ApplicationId" });
            RenameColumn(table: "dbo.Customers", name: "ApplicationId", newName: "UserId");
            RenameColumn(table: "dbo.SMS", name: "ApplicationId", newName: "UserId");
            RenameIndex(table: "dbo.Customers", name: "IX_ApplicationId", newName: "IX_UserId");
            RenameIndex(table: "dbo.SMS", name: "IX_ApplicationId", newName: "IX_UserId");
            DropColumn("dbo.SMSStatus", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SMSStatus", "ApplicationId", c => c.String(maxLength: 128));
            RenameIndex(table: "dbo.SMS", name: "IX_UserId", newName: "IX_ApplicationId");
            RenameIndex(table: "dbo.Customers", name: "IX_UserId", newName: "IX_ApplicationId");
            RenameColumn(table: "dbo.SMS", name: "UserId", newName: "ApplicationId");
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "ApplicationId");
            CreateIndex("dbo.SMSStatus", "ApplicationId");
            AddForeignKey("dbo.SMSStatus", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
