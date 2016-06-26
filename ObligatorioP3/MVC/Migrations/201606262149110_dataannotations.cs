namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calificacion", "Comentario", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calificacion", "Comentario", c => c.String());
        }
    }
}
