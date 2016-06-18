using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual Alojamiento Alojamiento { get; set; }
        public string Descripcion { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Fotos { get; set; }
        public decimal PrecioBase { get; set; }
        public List<RangoFechas> RangosFechas { get; set; }
        public virtual Registrado Registrado { get; set; }
    }
}