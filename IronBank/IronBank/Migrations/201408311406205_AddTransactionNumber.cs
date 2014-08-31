namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Number");
        }
    }
}
