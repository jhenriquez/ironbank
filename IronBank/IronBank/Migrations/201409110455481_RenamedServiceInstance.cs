namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedServiceInstance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConfiguredServiceInstances", newName: "ServiceBills");
            DropForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstanceId", "dbo.ConfiguredServiceInstances");
            DropIndex("dbo.ServiceInstancePayments", new[] { "ConfiguredServiceInstanceId" });
            AddColumn("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id", c => c.Int());
            CreateIndex("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id");
            AddForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id", "dbo.ServiceBills", "Id");
            DropColumn("dbo.ServiceBills", "IsPending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceBills", "IsPending", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id", "dbo.ServiceBills");
            DropIndex("dbo.ServiceInstancePayments", new[] { "ConfiguredServiceInstace_Id" });
            DropColumn("dbo.ServiceInstancePayments", "ConfiguredServiceInstace_Id");
            CreateIndex("dbo.ServiceInstancePayments", "ConfiguredServiceInstanceId");
            AddForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstanceId", "dbo.ConfiguredServiceInstances", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ServiceBills", newName: "ConfiguredServiceInstances");
        }
    }
}
