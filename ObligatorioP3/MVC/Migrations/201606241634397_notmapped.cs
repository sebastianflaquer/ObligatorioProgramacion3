namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notmapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Registrado", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrado", "ConfirmPassword", c => c.String());
        }
    }
}
