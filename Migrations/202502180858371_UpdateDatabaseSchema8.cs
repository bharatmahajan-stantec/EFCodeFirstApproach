namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "order_OrderId" });
            RenameColumn(table: "dbo.OrderItems", name: "order_OrderId", newName: "OrderId");
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "order_OrderId");
            CreateIndex("dbo.OrderItems", "order_OrderId");
            AddForeignKey("dbo.OrderItems", "order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
