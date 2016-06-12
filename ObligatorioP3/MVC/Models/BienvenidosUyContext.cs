using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BienvenidosUY;

namespace MVC.Models
{
    public class BienvenidosUyContext : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        virtual public DbSet<Anuncio> Anuncios { get; set; }
        virtual public DbSet<Alojamiento> Alojamientos { get; set; }

        public BienvenidosUyContext() : base("conexionBD") { }
        
        //No usa nombre en plural para crear las tablas en la BD
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}