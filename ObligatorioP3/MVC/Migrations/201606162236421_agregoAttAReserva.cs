namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregoAttAReserva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserva", "Anuncio_Id", c => c.Int());
            CreateIndex("dbo.Reserva", "Anuncio_Id");
            AddForeignKey("dbo.Reserva", "Anuncio_Id", "dbo.Anuncio", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "Anuncio_Id", "dbo.Anuncio");
            DropIndex("dbo.Reserva", new[] { "Anuncio_Id" });
            DropColumn("dbo.Reserva", "Anuncio_Id");
        }
    }
}
