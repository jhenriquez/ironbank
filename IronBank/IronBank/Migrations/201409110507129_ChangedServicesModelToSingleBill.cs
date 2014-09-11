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
            CreateIndex("dbo.ConfiguredServices", "Billing_Id");
            AddForeignKey("dbo.ConfiguredServices", "Billing_Id", "dbo.ServiceBills", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfiguredServices", "Billing_Id", "dbo.ServiceBills");
            DropIndex("dbo.ConfiguredServices", new[] { "Billing_Id" });
            DropColumn("dbo.ConfiguredServices", "Billing_Id");
            CreateIndex("dbo.ServiceBills", "ConfiguredServiceId");
            AddForeignKey("dbo.ServiceBills", "ConfiguredServiceId", "dbo.ConfiguredServices", "Id", cascadeDelete: true);
        }
    }
}
