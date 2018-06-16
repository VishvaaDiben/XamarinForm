namespace HLSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDetail = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        ProductImage = c.Binary(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
