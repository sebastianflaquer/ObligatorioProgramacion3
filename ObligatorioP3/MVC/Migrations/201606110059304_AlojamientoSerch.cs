namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlojamientoSerch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reserva", "Anuncio_id", "dbo.Anuncio");
            DropIndex("dbo.Reserva", new[] { "Anuncio_id" });
            DropColumn("dbo.Reserva", "Anuncio_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserva", "Anuncio_id", c => c.Int());
            CreateIndex("dbo.Reserva", "Anuncio_id");
            AddForeignKey("dbo.Reserva", "Anuncio_id", "dbo.Anuncio", "id");
        }
    }
}
