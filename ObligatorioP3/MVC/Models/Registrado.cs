using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Registrado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
    }
}