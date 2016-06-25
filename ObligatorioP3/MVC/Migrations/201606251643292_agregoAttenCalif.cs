namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregoAttenCalif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncio", "Registrado_Id", "dbo.Registrado");
            DropIndex("dbo.Anuncio", new[] { "Registrado_Id" });
            AddColumn("dbo.Calificacion", "Registrado_Id", c => c.Int());
            CreateIndex("dbo.Calificacion", "Registrado_Id");
            AddForeignKey("dbo.Calificacion", "Registrado_Id", "dbo.Registrado", "Id");
            DropColumn("dbo.Anuncio", "Registrado_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncio", "Registrado_Id", c => c.Int());
            DropForeignKey("dbo.Calificacion", "Registrado_Id", "dbo.Registrado");
            DropIndex("dbo.Calificacion", new[] { "Registrado_Id" });
            DropColumn("dbo.Calificacion", "Registrado_Id");
            CreateIndex("dbo.Anuncio", "Registrado_Id");
            AddForeignKey("dbo.Anuncio", "Registrado_Id", "dbo.Registrado", "Id");
        }
    }
}
