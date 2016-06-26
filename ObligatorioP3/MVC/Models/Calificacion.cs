using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        [Required]
        [Range(1,5)]
        public int Puntaje { get; set; }
        [Required]
        public string Comentario { get; set; }
        public virtual Alojamiento Alojamiento { get; set; }
        public virtual Registrado Registrado { get; set; }
    }
}