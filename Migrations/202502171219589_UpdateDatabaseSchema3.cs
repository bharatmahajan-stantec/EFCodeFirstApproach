namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentStatus");
        }
    }
}
