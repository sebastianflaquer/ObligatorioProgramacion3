namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attEnRegs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrado", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrado", "Foto", c => c.String(nullable: false));
        }
    }
}
