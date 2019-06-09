namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        cpf = c.String(),
                        endereco = c.String(),
                        dataNascimento = c.DateTime(nullable: false),
                        dataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ContaModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        agencia = c.Int(nullable: false),
                        saldo = c.Double(nullable: false),
                        clienteid = c.Int(nullable: false),
                        ClienteModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ClienteModels", t => t.ClienteModel_id)
                .Index(t => t.ClienteModel_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContaModels", "ClienteModel_id", "dbo.ClienteModels");
            DropIndex("dbo.ContaModels", new[] { "ClienteModel_id" });
            DropTable("dbo.ContaModels");
            DropTable("dbo.ClienteModels");
        }
    }
}
