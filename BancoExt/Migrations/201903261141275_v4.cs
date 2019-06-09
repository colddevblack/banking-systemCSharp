namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoContaModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nomeconta = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.ContaModels", "tipocontaid", c => c.Int(nullable: false));
            AddColumn("dbo.ContaModels", "tipocontamodel_id", c => c.Int());
            CreateIndex("dbo.ContaModels", "tipocontamodel_id");
            AddForeignKey("dbo.ContaModels", "tipocontamodel_id", "dbo.TipoContaModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContaModels", "tipocontamodel_id", "dbo.TipoContaModels");
            DropIndex("dbo.ContaModels", new[] { "tipocontamodel_id" });
            DropColumn("dbo.ContaModels", "tipocontamodel_id");
            DropColumn("dbo.ContaModels", "tipocontaid");
            DropTable("dbo.TipoContaModels");
        }
    }
}
