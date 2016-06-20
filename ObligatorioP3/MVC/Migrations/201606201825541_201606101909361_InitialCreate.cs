namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201606101909361_InitialCreate : DbMigration
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
            AddColumn("dbo.Registrado", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Reserva", "Anuncio_Id", c => c.Int());
            AlterColumn("dbo.Registrado", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Celular", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Foto", c => c.String(nullable: false));
            CreateIndex("dbo.Alojamiento", "Categoria_Id");
            CreateIndex("dbo.Alojamiento", "Ciudad_Id");
            CreateIndex("dbo.Alojamiento", "Registrado_Id");
            CreateIndex("dbo.Servicio", "Alojamiento_Id");
            CreateIndex("dbo.Anuncio", "Alojamiento_Id");
            CreateIndex("dbo.Anuncio", "Registrado_Id");
            CreateIndex("dbo.RangoFechas", "Anuncio_Id");
            CreateIndex("dbo.Reserva", "Anuncio_Id");
            CreateIndex("dbo.Reserva", "Registrado_Id");
            AddForeignKey("dbo.Reserva", "Anuncio_Id", "dbo.Anuncio", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "Anuncio_Id", "dbo.Anuncio");
            DropIndex("dbo.Reserva", new[] { "Registrado_Id" });
            DropIndex("dbo.Reserva", new[] { "Anuncio_Id" });
            DropIndex("dbo.RangoFechas", new[] { "Anuncio_Id" });
            DropIndex("dbo.Anuncio", new[] { "Registrado_Id" });
            DropIndex("dbo.Anuncio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Servicio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Registrado_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Ciudad_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Categoria_Id" });
            AlterColumn("dbo.Registrado", "Foto", c => c.String());
            AlterColumn("dbo.Registrado", "Celular", c => c.String());
            AlterColumn("dbo.Registrado", "Direccion", c => c.String());
            AlterColumn("dbo.Registrado", "Password", c => c.String());
            AlterColumn("dbo.Registrado", "Mail", c => c.String());
            AlterColumn("dbo.Registrado", "Apellido", c => c.String());
            AlterColumn("dbo.Registrado", "Nombre", c => c.String());
            DropColumn("dbo.Reserva", "Anuncio_Id");
            DropColumn("dbo.Registrado", "ConfirmPassword");
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
