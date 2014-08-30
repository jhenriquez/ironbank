namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductBalanceField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Balance");
        }
    }
}
