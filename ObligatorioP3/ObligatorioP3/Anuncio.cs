using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Anuncio
    {
        public int id { get; set; }
        public static int ultId { get; set; }
        public string nombre { get; set; }
        public Alojamiento alojamiento { get; set; }
        public string descripcion { get; set; }
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }
        public string fotos { get; set; }
        public decimal precioBase { get; set; }
        public List<RangoFechas> rangosFechas { get; set; }

    }
}
