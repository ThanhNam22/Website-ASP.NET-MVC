namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuanlity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Quantity", c => c.Int(nullable: false));
        }
    }
}
