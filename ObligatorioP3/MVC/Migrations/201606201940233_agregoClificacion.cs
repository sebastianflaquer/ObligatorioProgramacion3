namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregoClificacion : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Registrado", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Registrado", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Celular", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Foto", c => c.String(nullable: false));
            AlterColumn("dbo.Registrado", "Descripcion", c => c.String(nullable: false));
            DropColumn("dbo.Alojamiento", "Calificacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alojamiento", "Calificacion", c => c.Int(nullable: false));
            DropForeignKey("dbo.Calificacion", "Alojamiento_Id", "dbo.Alojamiento");
            DropIndex("dbo.Calificacion", new[] { "Alojamiento_Id" });
            AlterColumn("dbo.Registrado", "Descripcion", c => c.String());
            AlterColumn("dbo.Registrado", "Foto", c => c.String());
            AlterColumn("dbo.Registrado", "Celular", c => c.String());
            AlterColumn("dbo.Registrado", "Direccion", c => c.String());
            AlterColumn("dbo.Registrado", "Password", c => c.String());
            AlterColumn("dbo.Registrado", "Mail", c => c.String());
            AlterColumn("dbo.Registrado", "Apellido", c => c.String());
            AlterColumn("dbo.Registrado", "Nombre", c => c.String());
            DropColumn("dbo.Registrado", "ConfirmPassword");
            DropTable("dbo.Calificacion");
        }
    }
}
