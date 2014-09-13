namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceAndBillAssociation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConfiguredServices", "Billing_Id", "dbo.ServiceBills");
            DropIndex("dbo.ConfiguredServices", new[] { "Billing_Id" });
            RenameColumn(table: "dbo.ConfiguredServices", name: "Billing_Id", newName: "ServiceBillId");
            AddColumn("dbo.ServiceBills", "ConfiguredServiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.ConfiguredServices", "ServiceBillId", c => c.Int(nullable: true));
            CreateIndex("dbo.ConfiguredServices", "ServiceBillId");
            //AddForeignKey("dbo.ConfiguredServices", "ServiceBillId", "dbo.ServiceBills", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ConfiguredServices", "ServiceBillId", "dbo.ServiceBills");
            DropIndex("dbo.ConfiguredServices", new[] { "ServiceBillId" });
            AlterColumn("dbo.ConfiguredServices", "ServiceBillId", c => c.Int());
            DropColumn("dbo.ServiceBills", "ConfiguredServiceId");
            RenameColumn(table: "dbo.ConfiguredServices", name: "ServiceBillId", newName: "Billing_Id");
            CreateIndex("dbo.ConfiguredServices", "Billing_Id");
            AddForeignKey("dbo.ConfiguredServices", "Billing_Id", "dbo.ServiceBills", "Id");
        }
    }
}
