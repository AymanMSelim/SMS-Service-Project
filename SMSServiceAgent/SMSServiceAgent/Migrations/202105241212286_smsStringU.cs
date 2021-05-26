namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsStringU : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SMS", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SMS", "Message", c => c.Int(nullable: false));
        }
    }
}
