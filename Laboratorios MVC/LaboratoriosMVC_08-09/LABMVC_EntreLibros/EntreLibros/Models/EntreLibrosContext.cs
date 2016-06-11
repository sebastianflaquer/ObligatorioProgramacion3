using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace EntreLibros.Models
{
    public class EntreLibrosContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public EntreLibrosContext()
            : base("Data Source = (local); Initial Catalog = EntreLibros; Integrated Security = SSPI;")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
