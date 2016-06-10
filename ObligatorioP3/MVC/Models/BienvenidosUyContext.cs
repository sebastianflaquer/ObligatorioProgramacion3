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

        public BienvenidosUyContext() : base("conexionBD") { }


        //No usa nombre en plural para crear las tablas en la BD
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}