namespace QLTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GioHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHang",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenMA = c.String(),
                    Hinh = c.String(),
                    Gia = c.Int(nullable: false),
                    SoLuong = c.Int(nullable: false),
                    ThanhTien = c.Decimal(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.GioHang");
        }
    }
}
