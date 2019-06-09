namespace BancoExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContaModels", "numero", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContaModels", "numero", c => c.Int(nullable: false));
        }
    }
}
