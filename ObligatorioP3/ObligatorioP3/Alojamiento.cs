using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Alojamiento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Categoria categoria { get; set; }
        public string tipoHabitacion { get; set; }
        public bool banioPrivado { get; set; }
        public int cantHuespedes { get; set; }
        public string ciudad { get; set; }
        public string barrio { get; set; }
        public List<Servicio> servicios { get; set; }
        public int calificacion { get; set; }
    }

}
