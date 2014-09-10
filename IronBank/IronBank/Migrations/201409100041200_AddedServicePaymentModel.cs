namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServicePaymentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceInstancePayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfiguredServiceInstanceId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConfiguredServiceInstances", t => t.ConfiguredServiceInstanceId, cascadeDelete: true)
                .Index(t => t.ConfiguredServiceInstanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceInstancePayments", "ConfiguredServiceInstanceId", "dbo.ConfiguredServiceInstances");
            DropIndex("dbo.ServiceInstancePayments", new[] { "ConfiguredServiceInstanceId" });
            DropTable("dbo.ServiceInstancePayments");
        }
    }
}
