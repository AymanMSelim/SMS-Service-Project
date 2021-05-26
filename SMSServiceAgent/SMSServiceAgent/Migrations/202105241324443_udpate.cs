namespace SMSServiceAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SMS", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SMS", "Message", c => c.String());
        }
    }
}
