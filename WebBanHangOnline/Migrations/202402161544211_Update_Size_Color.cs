namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Size_Color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Colors", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Colors", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Colors", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Colors", "Modifiedby", c => c.String());
            AddColumn("dbo.tb_Sizes", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Sizes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Sizes", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Sizes", "Modifiedby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Sizes", "Modifiedby");
            DropColumn("dbo.tb_Sizes", "ModifiedDate");
            DropColumn("dbo.tb_Sizes", "CreatedDate");
            DropColumn("dbo.tb_Sizes", "CreatedBy");
            DropColumn("dbo.tb_Colors", "Modifiedby");
            DropColumn("dbo.tb_Colors", "ModifiedDate");
            DropColumn("dbo.tb_Colors", "CreatedDate");
            DropColumn("dbo.tb_Colors", "CreatedBy");
        }
    }
}
