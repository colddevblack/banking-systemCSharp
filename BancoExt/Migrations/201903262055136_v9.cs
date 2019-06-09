namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoTransacaoModels", "TransacaoModel_id", c => c.Int());
            CreateIndex("dbo.TipoTransacaoModels", "TransacaoModel_id");
            AddForeignKey("dbo.TipoTransacaoModels", "TransacaoModel_id", "dbo.TransacaoModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoTransacaoModels", "TransacaoModel_id", "dbo.TransacaoModels");
            DropIndex("dbo.TipoTransacaoModels", new[] { "TransacaoModel_id" });
            DropColumn("dbo.TipoTransacaoModels", "TransacaoModel_id");
        }
    }
}
