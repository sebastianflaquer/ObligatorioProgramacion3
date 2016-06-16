using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC.Models
{
    public class BienvenidosUyContext : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Alojamiento> Alojamientos { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<RangoFechas> RangoFechas { get; set; }
        public DbSet<Registrado> Registrados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        public BienvenidosUyContext() : base("conexionBD") { }
        
        //No usa nombre en plural para crear las tablas en la BD
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}