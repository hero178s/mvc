namespace QLTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableMonAnAndLoaiThucAn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiThucAns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenTL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenMA = c.String(),
                        NguoiNau = c.String(),
                        Hinh = c.String(),
                        Gio = c.DateTime(nullable: false),
                        Gia = c.String(),
                        SoLuong = c.String(),
                        MaTL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiThucAns", t => t.MaTL, cascadeDelete: true)
                .Index(t => t.MaTL);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonAns", "MaTL", "dbo.LoaiThucAns");
            DropIndex("dbo.MonAns", new[] { "MaTL" });
            DropTable("dbo.MonAns");
            DropTable("dbo.LoaiThucAns");
        }
    }
}
