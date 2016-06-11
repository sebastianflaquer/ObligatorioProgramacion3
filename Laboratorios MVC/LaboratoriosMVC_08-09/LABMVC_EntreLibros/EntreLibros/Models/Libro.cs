using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreLibros.Models
{
    public class Libro
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Descripción { get; set; }
        public string NombreArchivoPortada { get; set; }
        //propiedades de navegación
        public virtual Tema MiTema { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual List<Autor> Autores { get; set; }

    }
}
