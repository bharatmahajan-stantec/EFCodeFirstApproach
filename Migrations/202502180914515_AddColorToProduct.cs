namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerEmail", c => c.String(nullable:false, defaultValue:"White"));
            AddColumn("dbo.Products", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Color");
            DropColumn("dbo.Orders", "CustomerEmail");
        }
    }
}
