namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContaModels", "clienteid", "dbo.ClienteModels");
            AddForeignKey("dbo.ContaModels", "clienteid", "dbo.ClienteModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContaModels", "clienteid", "dbo.ClienteModels");
            AddForeignKey("dbo.ContaModels", "clienteid", "dbo.ClienteModels", "id");
        }
    }
}
