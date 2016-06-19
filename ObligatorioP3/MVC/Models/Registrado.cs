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


        
        //VALIDAR REGISTRO
        public bool validarRegistro()
        {
            bool retorno = false;

            //validaMail
            string mail = Mail;
            //no se como consultar a la base de datos para saber si existe
            //valida que ya no exista
            //Registrado registrado = db.Registrados.Find(Mail);


            return retorno;
        }




    }

}