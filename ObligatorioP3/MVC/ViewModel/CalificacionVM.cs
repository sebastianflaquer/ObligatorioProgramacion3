using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModel
{
    public class CalificacionVM
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public string Comentario { get; set; }
        public virtual Alojamiento Alojamiento { get; set; }
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        public Registrado Registrado { get; set; }
        [Display(Name = "Cantidad de Huéspedes")]
        public int CantHuespedes { get; set; }
        [Display(Name = "Consultas")]
        public string TextoConsultas { get; set; }
        public virtual Anuncio Anuncio { get; set; }
    }
}