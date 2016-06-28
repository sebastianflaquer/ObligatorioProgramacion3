using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Models
{
    [Bind(Exclude = "ConfirmPassword")]
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
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Celular { get; set; }
        public string Foto { get; set; }
        
        public string Descripcion { get; set; }
        [NotMapped]
        public HttpPostedFileBase Archivo { get; set; }


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

        //MAPEA EL NOMBRE DE LA FOTO
        public bool Mapear()
        {
            if (this.Archivo != null)
            {
                if (guardarArchivo(Archivo))
                {
                    this.Foto = this.Mail + "-" + Archivo.FileName.ToLower().Replace(" ", "_");
                    //BienvenidosUyContext db = new BienvenidosUyContext();
                    //this.UnLibro.MiTema = db.Temas.Find(this.IdTemaSeleccionado);
                    return true;
                }
            }
            return false;
        }

        //GUARDA LA FOTO
        private bool guardarArchivo(HttpPostedFileBase archivo)
        {
            if (archivo != null)
            {
                string ruta = System.IO.Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, "Imagenes/Usuarios");
                if (!System.IO.Directory.Exists(ruta))
                    System.IO.Directory.CreateDirectory(ruta);

                ruta = System.IO.Path.Combine(ruta, this.Mail + "-" + archivo.FileName.ToLower().Replace(" ", "_"));
                archivo.SaveAs(ruta);
                return true;
            }
            else return false;
        }

    }

}