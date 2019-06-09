namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoTransacaoModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nometr = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoTransacaoModels");
        }
    }
}
