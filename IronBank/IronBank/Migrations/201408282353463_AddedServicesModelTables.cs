namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServicesModelTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConfiguredServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ServiceId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdateAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AvailableServices", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.ConfiguredServiceInstances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfiguredServiceId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        GeneratedAt = c.DateTime(nullable: false),
                        PayBefore = c.DateTime(),
                        IsPending = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConfiguredServices", t => t.ConfiguredServiceId, cascadeDelete: true)
                .Index(t => t.ConfiguredServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfiguredServices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConfiguredServices", "ServiceId", "dbo.AvailableServices");
            DropForeignKey("dbo.ConfiguredServiceInstances", "ConfiguredServiceId", "dbo.ConfiguredServices");
            DropIndex("dbo.ConfiguredServiceInstances", new[] { "ConfiguredServiceId" });
            DropIndex("dbo.ConfiguredServices", new[] { "ServiceId" });
            DropIndex("dbo.ConfiguredServices", new[] { "UserId" });
            DropTable("dbo.ConfiguredServiceInstances");
            DropTable("dbo.ConfiguredServices");
            DropTable("dbo.AvailableServices");
        }
    }
}
