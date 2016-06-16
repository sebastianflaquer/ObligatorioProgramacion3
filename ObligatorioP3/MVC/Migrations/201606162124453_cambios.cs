namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Anuncio", new[] { "alojamiento_id" });
            DropIndex("dbo.Anuncio", new[] { "registrado_id" });
            DropIndex("dbo.Alojamiento", new[] { "categoria_id" });
            DropIndex("dbo.Alojamiento", new[] { "ciudad_id" });
            DropIndex("dbo.Alojamiento", new[] { "registrado_id" });
            DropIndex("dbo.Servicio", new[] { "Alojamiento_id" });
            DropIndex("dbo.RangoFechas", new[] { "Anuncio_id" });
            DropIndex("dbo.Reserva", new[] { "Registrado_id" });
            CreateIndex("dbo.Alojamiento", "Categoria_Id");
            CreateIndex("dbo.Alojamiento", "Ciudad_Id");
            CreateIndex("dbo.Alojamiento", "Registrado_Id");
            CreateIndex("dbo.Servicio", "Alojamiento_Id");
            CreateIndex("dbo.Anuncio", "Alojamiento_Id");
            CreateIndex("dbo.Anuncio", "Registrado_Id");
            CreateIndex("dbo.RangoFechas", "Anuncio_Id");
            CreateIndex("dbo.Reserva", "Registrado_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reserva", new[] { "Registrado_Id" });
            DropIndex("dbo.RangoFechas", new[] { "Anuncio_Id" });
            DropIndex("dbo.Anuncio", new[] { "Registrado_Id" });
            DropIndex("dbo.Anuncio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Servicio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Registrado_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Ciudad_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Categoria_Id" });
            CreateIndex("dbo.Reserva", "Registrado_id");
            CreateIndex("dbo.RangoFechas", "Anuncio_id");
            CreateIndex("dbo.Servicio", "Alojamiento_id");
            CreateIndex("dbo.Alojamiento", "registrado_id");
            CreateIndex("dbo.Alojamiento", "ciudad_id");
            CreateIndex("dbo.Alojamiento", "categoria_id");
            CreateIndex("dbo.Anuncio", "registrado_id");
            CreateIndex("dbo.Anuncio", "alojamiento_id");
        }
    }
}
