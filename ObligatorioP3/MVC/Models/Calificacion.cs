using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public string Comentario { get; set; }
        public virtual Alojamiento Alojamiento { get; set; }
        public virtual Registrado Registrado { get; set; }
    }
}