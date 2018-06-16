namespace HLSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Products", "ProductDetail", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary(nullable: false));
            CreateIndex("dbo.Products", "ProductName", unique: true, name: "Product_Idx");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", "Product_Idx");
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary());
            AlterColumn("dbo.Products", "ProductDetail", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
