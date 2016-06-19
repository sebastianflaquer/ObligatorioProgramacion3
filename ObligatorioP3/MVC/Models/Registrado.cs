using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Registrado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Compare("Password")]
        [MinLength(8)]
        [Display(Name ="Confirmar Password")]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [MinLength(8)]
        public string Celular { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        

    }

}