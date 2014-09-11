namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedServicePayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id", "dbo.ServiceBills");
            RenameTable(name: "dbo.ServiceInstancePayments", newName: "ServicePayments");
            DropIndex("dbo.ServicePayments", new[] { "ConfiguredServiceInstace_Id" });
            RenameColumn(table: "dbo.ServicePayments", name: "ConfiguredServiceInstace_Id", newName: "ServiceBillId");
            AlterColumn("dbo.ServicePayments", "ServiceBillId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServicePayments", "ServiceBillId");
            AddForeignKey("dbo.ServicePayments", "ServiceBillId", "dbo.ServiceBills", "Id", cascadeDelete: true);
            DropColumn("dbo.ServicePayments", "ConfiguredServiceInstanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServicePayments", "ConfiguredServiceInstanceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ServicePayments", "ServiceBillId", "dbo.ServiceBills");
            DropIndex("dbo.ServicePayments", new[] { "ServiceBillId" });
            AlterColumn("dbo.ServicePayments", "ServiceBillId", c => c.Int());
            RenameColumn(table: "dbo.ServicePayments", name: "ServiceBillId", newName: "ConfiguredServiceInstace_Id");
            CreateIndex("dbo.ServicePayments", "ConfiguredServiceInstace_Id");
            RenameTable(name: "dbo.ServicePayments", newName: "ServiceInstancePayments");
            AddForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id", "dbo.ServiceBills", "Id");
        }
    }
}
