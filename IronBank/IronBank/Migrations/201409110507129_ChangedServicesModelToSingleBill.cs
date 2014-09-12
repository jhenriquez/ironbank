namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedServicesModelToSingleBill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceBills", "ConfiguredServiceId", "dbo.ConfiguredServices");
            DropIndex("dbo.ServiceBills", new[] { "ConfiguredServiceId" });
            AddColumn("dbo.ConfiguredServices", "Billing_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfiguredServices", "Billing_Id");
            CreateIndex("dbo.ServiceBills", "ConfiguredServiceId");
            AddForeignKey("dbo.ServiceBills", "ConfiguredServiceId", "dbo.ConfiguredServices", "Id", cascadeDelete: false);
        }
    }
}
