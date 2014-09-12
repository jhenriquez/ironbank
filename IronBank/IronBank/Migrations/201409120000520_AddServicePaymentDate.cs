namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServicePaymentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServicePayments", "PaymentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServicePayments", "PaymentDate");
        }
    }
}
