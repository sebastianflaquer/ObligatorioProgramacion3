﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [Display(Name ="Fecha Inicio")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        public Registrado Registrado { get; set; }
        [Display(Name = "Cantidad de Huéspedes")]
        public int CantHuespedes { get; set; }
        [Display(Name = "Consultas")]
        public string TextoConsultas { get; set; }
        public Anuncio Anuncio { get; set; }


        public bool funciontest() {
            return true;
        }










    }
}