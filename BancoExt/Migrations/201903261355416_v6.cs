namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ContaModels", new[] { "ClienteModel_id" });
            DropColumn("dbo.ContaModels", "clienteid");
            RenameColumn(table: "dbo.ContaModels", name: "ClienteModel_id", newName: "clienteid");
            AlterColumn("dbo.ContaModels", "clienteid", c => c.Int(nullable: false));
            CreateIndex("dbo.ContaModels", "clienteid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContaModels", new[] { "clienteid" });
            AlterColumn("dbo.ContaModels", "clienteid", c => c.Int());
            RenameColumn(table: "dbo.ContaModels", name: "clienteid", newName: "ClienteModel_id");
            AddColumn("dbo.ContaModels", "clienteid", c => c.Int(nullable: false));
            CreateIndex("dbo.ContaModels", "ClienteModel_id");
        }
    }
}
