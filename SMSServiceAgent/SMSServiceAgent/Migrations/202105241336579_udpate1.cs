namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SMS", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.SMS", "ApplicationId");
            RenameColumn(table: "dbo.SMS", name: "ApplicationUser_Id", newName: "ApplicationId");
            AlterColumn("dbo.SMS", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SMS", "ApplicationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SMS", new[] { "ApplicationId" });
            AlterColumn("dbo.SMS", "ApplicationId", c => c.String());
            RenameColumn(table: "dbo.SMS", name: "ApplicationId", newName: "ApplicationUser_Id");
            AddColumn("dbo.SMS", "ApplicationId", c => c.String());
            CreateIndex("dbo.SMS", "ApplicationUser_Id");
        }
    }
}
