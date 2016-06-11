using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreLibros.Models
{
    public class Tema
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //propiedades de navegación
        public virtual IEnumerable<Libro> Libros { get; set; }
    }
}
