namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Quantity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductQuantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductQuantities", "SizeId", "dbo.tb_Sizes");
            DropForeignKey("dbo.tb_ProductQuantities", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_ProductQuantities", "ColorId", "dbo.tb_Colors");
            DropIndex("dbo.tb_ProductQuantities", new[] { "ColorId" });
            DropIndex("dbo.tb_ProductQuantities", new[] { "SizeId" });
            DropIndex("dbo.tb_ProductQuantities", new[] { "ProductId" });
            DropTable("dbo.tb_ProductQuantities");
        }
    }
}
