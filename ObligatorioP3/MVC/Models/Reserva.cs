using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BienvenidosUY;

namespace MVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public Anuncio Anuncio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Registrado Registrado { get; set; }
        public int CantHuespedes { get; set; }
        public string TextoConsultas { get; set; }



    }
}