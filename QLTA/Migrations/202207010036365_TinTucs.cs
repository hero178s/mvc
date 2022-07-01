namespace QLTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TinTucs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        TacGia = c.String(),
                        Hinh = c.String(),
                        GioDang = c.DateTime(nullable: false),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTucs");
        }
    }
}
