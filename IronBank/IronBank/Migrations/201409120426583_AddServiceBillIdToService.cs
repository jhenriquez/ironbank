namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceBillIdToService : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceBills", "ConfiguredServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceBills", "ConfiguredServiceId", c => c.Int(nullable: false));
        }
    }
}
