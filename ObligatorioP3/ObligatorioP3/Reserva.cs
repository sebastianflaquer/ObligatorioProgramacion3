using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Reserva
    {
        public int id { get; set; }
        public Anuncio anuncio { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public Registrado registrado { get; set; }

    }
}
