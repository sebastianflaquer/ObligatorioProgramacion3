using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

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
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Foto { get; set; }
        
        public string Descripcion { get; set; }


        //GENERA LA SAL
        public string generarSalPass()
        {
            //crea un obketo random y setea el numero del resultado.
            Random r = new Random();
            string retorno = r.Next().ToString();
            return retorno;
        }

        //funciones creadas por nosotros
        public static string EncriptarPass(string passwordIngreso, string salt, string pimienta)
        {
            string hashresult = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordIngreso + salt + pimienta, "SHA1");
            return hashresult;
        }

        //validarLogin
        public bool validarUsuario(){
            return true;
        }

        //PIMIENTA
        public static string getPimienta()
        {
            string pimienta = "p1m13n7a";
            return pimienta;
        }









    }

}