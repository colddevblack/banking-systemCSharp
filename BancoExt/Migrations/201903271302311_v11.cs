namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClienteModels", "dataNascimento");
            DropColumn("dbo.ClienteModels", "dataCriacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClienteModels", "dataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClienteModels", "dataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
