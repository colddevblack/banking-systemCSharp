namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClienteModels", "dataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClienteModels", "dataCriacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClienteModels", "dataCriacao");
            DropColumn("dbo.ClienteModels", "dataNascimento");
        }
    }
}
