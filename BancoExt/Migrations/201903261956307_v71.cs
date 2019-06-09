namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v71 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransacaoModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Double(nullable: false),
                        contaid = c.Int(nullable: false),
                        tipotransacaoid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TipoTransacaoModels", t => t.tipotransacaoid)
                .ForeignKey("dbo.ContaModels", t => t.contaid)
                .Index(t => t.contaid)
                .Index(t => t.tipotransacaoid);
            
            AddColumn("dbo.ContaModels", "transacaoid", c => c.Int(nullable: false));
            AddColumn("dbo.ContaModels", "TransacaoModel_id", c => c.Int());
            CreateIndex("dbo.ContaModels", "TransacaoModel_id");
            AddForeignKey("dbo.ContaModels", "TransacaoModel_id", "dbo.TransacaoModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransacaoModels", "contaid", "dbo.ContaModels");
            DropForeignKey("dbo.TransacaoModels", "tipotransacaoid", "dbo.TipoTransacaoModels");
            DropForeignKey("dbo.ContaModels", "TransacaoModel_id", "dbo.TransacaoModels");
            DropIndex("dbo.TransacaoModels", new[] { "tipotransacaoid" });
            DropIndex("dbo.TransacaoModels", new[] { "contaid" });
            DropIndex("dbo.ContaModels", new[] { "TransacaoModel_id" });
            DropColumn("dbo.ContaModels", "TransacaoModel_id");
            DropColumn("dbo.ContaModels", "transacaoid");
            DropTable("dbo.TransacaoModels");
        }
    }
}
