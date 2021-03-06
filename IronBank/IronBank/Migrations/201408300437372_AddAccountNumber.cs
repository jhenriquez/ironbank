namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AccountNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AccountNumber");
        }
    }
}
