using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Alojamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string TipoHabitacion { get; set; }
        public bool BanioPrivado { get; set; }
        public int CantHuespedes { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public string Barrio { get; set; }
        public List<Servicio> Servicios { get; set; }
        //public int Calificacion { get; set; }
        public virtual Registrado Registrado { get; set; }
        public virtual ICollection<Calificacion> Calificaciones { get; set; }

    }
}