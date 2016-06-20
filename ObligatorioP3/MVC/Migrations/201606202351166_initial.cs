namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alojamiento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TipoHabitacion = c.String(),
                        BanioPrivado = c.Boolean(nullable: false),
                        CantHuespedes = c.Int(nullable: false),
                        Barrio = c.String(),
                        Categoria_Id = c.Int(),
                        Ciudad_Id = c.Int(),
                        Registrado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .ForeignKey("dbo.Ciudad", t => t.Ciudad_Id)
                .ForeignKey("dbo.Registrado", t => t.Registrado_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Ciudad_Id)
                .Index(t => t.Registrado_Id);
            
            CreateTable(
                "dbo.Calificacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Puntaje = c.Int(nullable: false),
                        Comentario = c.String(),
                        Alojamiento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alojamiento", t => t.Alojamiento_Id)
                .Index(t => t.Alojamiento_Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        Salt = c.String(),
                        Direccion = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Foto = c.String(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Alojamiento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alojamiento", t => t.Alojamiento_Id)
                .Index(t => t.Alojamiento_Id);
            
            CreateTable(
                "dbo.Anuncio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Direccion1 = c.String(),
                        Direccion2 = c.String(),
                        Fotos = c.String(),
                        PrecioBase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alojamiento_Id = c.Int(),
                        Registrado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alojamiento", t => t.Alojamiento_Id)
                .ForeignKey("dbo.Registrado", t => t.Registrado_Id)
                .Index(t => t.Alojamiento_Id)
                .Index(t => t.Registrado_Id);
            
            CreateTable(
                "dbo.RangoFechas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anuncio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anuncio", t => t.Anuncio_Id)
                .Index(t => t.Anuncio_Id);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        CantHuespedes = c.Int(nullable: false),
                        TextoConsultas = c.String(),
                        Anuncio_Id = c.Int(),
                        Registrado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anuncio", t => t.Anuncio_Id)
                .ForeignKey("dbo.Registrado", t => t.Registrado_Id)
                .Index(t => t.Anuncio_Id)
                .Index(t => t.Registrado_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "Registrado_Id", "dbo.Registrado");
            DropForeignKey("dbo.Reserva", "Anuncio_Id", "dbo.Anuncio");
            DropForeignKey("dbo.Anuncio", "Registrado_Id", "dbo.Registrado");
            DropForeignKey("dbo.RangoFechas", "Anuncio_Id", "dbo.Anuncio");
            DropForeignKey("dbo.Anuncio", "Alojamiento_Id", "dbo.Alojamiento");
            DropForeignKey("dbo.Servicio", "Alojamiento_Id", "dbo.Alojamiento");
            DropForeignKey("dbo.Alojamiento", "Registrado_Id", "dbo.Registrado");
            DropForeignKey("dbo.Alojamiento", "Ciudad_Id", "dbo.Ciudad");
            DropForeignKey("dbo.Alojamiento", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.Calificacion", "Alojamiento_Id", "dbo.Alojamiento");
            DropIndex("dbo.Reserva", new[] { "Registrado_Id" });
            DropIndex("dbo.Reserva", new[] { "Anuncio_Id" });
            DropIndex("dbo.RangoFechas", new[] { "Anuncio_Id" });
            DropIndex("dbo.Anuncio", new[] { "Registrado_Id" });
            DropIndex("dbo.Anuncio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Servicio", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Calificacion", new[] { "Alojamiento_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Registrado_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Ciudad_Id" });
            DropIndex("dbo.Alojamiento", new[] { "Categoria_Id" });
            DropTable("dbo.Reserva");
            DropTable("dbo.RangoFechas");
            DropTable("dbo.Anuncio");
            DropTable("dbo.Servicio");
            DropTable("dbo.Registrado");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Categoria");
            DropTable("dbo.Calificacion");
            DropTable("dbo.Alojamiento");
        }
    }
}
