using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Registrado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        public List<Anuncio> anuncios { get; set; }
        public List<Reserva> reservas { get; set; }

    }
}
