using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BienvenidosUY;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Registrado Registrado { get; set; }

        [Range (1,10)]
        [DataType(DataType.Currency)]
        public int CantHuespedes { get; set; }

        [Required]
        [StringLength(250)]
        public string TextoConsultas { get; set; }

    }
}