namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SMSStatus", name: "ApplicationUser_Id", newName: "ApplicationId");
            RenameIndex(table: "dbo.SMSStatus", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SMSStatus", name: "IX_ApplicationId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.SMSStatus", name: "ApplicationId", newName: "ApplicationUser_Id");
        }
    }
}
