namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        CantHuespedes = c.Int(nullable: false),
                        TextoConsultas = c.String(),
                        Anuncio_id = c.Int(),
                        Registrado_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anuncio", t => t.Anuncio_id)
                .ForeignKey("dbo.Registrado", t => t.Registrado_id)
                .Index(t => t.Anuncio_id)
                .Index(t => t.Registrado_id);
            
            CreateTable(
                "dbo.Anuncio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        direccion1 = c.String(),
                        direccion2 = c.String(),
                        fotos = c.String(),
                        precioBase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        alojamiento_id = c.Int(),
                        registrado_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alojamiento", t => t.alojamiento_id)
                .ForeignKey("dbo.Registrado", t => t.registrado_id)
                .Index(t => t.alojamiento_id)
                .Index(t => t.registrado_id);
            
            CreateTable(
                "dbo.Alojamiento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        tipoHabitacion = c.String(),
                        banioPrivado = c.Boolean(nullable: false),
                        cantHuespedes = c.Int(nullable: false),
                        barrio = c.String(),
                        calificacion = c.Int(nullable: false),
                        categoria_id = c.Int(),
                        ciudad_id = c.Int(),
                        registrado_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categoria", t => t.categoria_id)
                .ForeignKey("dbo.Ciudad", t => t.ciudad_id)
                .ForeignKey("dbo.Registrado", t => t.registrado_id)
                .Index(t => t.categoria_id)
                .Index(t => t.ciudad_id)
                .Index(t => t.registrado_id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Registrado",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellido = c.String(),
                        mail = c.String(),
                        password = c.String(),
                        salt = c.String(),
                        direccion = c.String(),
                        celular = c.String(),
                        foto = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        Alojamiento_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alojamiento", t => t.Alojamiento_id)
                .Index(t => t.Alojamiento_id);
            
            CreateTable(
                "dbo.RangoFechas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anuncio_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Anuncio", t => t.Anuncio_id)
                .Index(t => t.Anuncio_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "Registrado_id", "dbo.Registrado");
            DropForeignKey("dbo.Reserva", "Anuncio_id", "dbo.Anuncio");
            DropForeignKey("dbo.Anuncio", "registrado_id", "dbo.Registrado");
            DropForeignKey("dbo.RangoFechas", "Anuncio_id", "dbo.Anuncio");
            DropForeignKey("dbo.Anuncio", "alojamiento_id", "dbo.Alojamiento");
            DropForeignKey("dbo.Servicio", "Alojamiento_id", "dbo.Alojamiento");
            DropForeignKey("dbo.Alojamiento", "registrado_id", "dbo.Registrado");
            DropForeignKey("dbo.Alojamiento", "ciudad_id", "dbo.Ciudad");
            DropForeignKey("dbo.Alojamiento", "categoria_id", "dbo.Categoria");
            DropIndex("dbo.RangoFechas", new[] { "Anuncio_id" });
            DropIndex("dbo.Servicio", new[] { "Alojamiento_id" });
            DropIndex("dbo.Alojamiento", new[] { "registrado_id" });
            DropIndex("dbo.Alojamiento", new[] { "ciudad_id" });
            DropIndex("dbo.Alojamiento", new[] { "categoria_id" });
            DropIndex("dbo.Anuncio", new[] { "registrado_id" });
            DropIndex("dbo.Anuncio", new[] { "alojamiento_id" });
            DropIndex("dbo.Reserva", new[] { "Registrado_id" });
            DropIndex("dbo.Reserva", new[] { "Anuncio_id" });
            DropTable("dbo.RangoFechas");
            DropTable("dbo.Servicio");
            DropTable("dbo.Registrado");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Categoria");
            DropTable("dbo.Alojamiento");
            DropTable("dbo.Anuncio");
            DropTable("dbo.Reserva");
        }
    }
}
