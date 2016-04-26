using BienvenidosUY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Web.Views
{
    public partial class sign_up : System.Web.UI.Page
    {
        //PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                Response.Redirect("../Views/home.aspx");
            }
            else //Si no esta logeado
            {

            }
        }

        //PASAR A HASH
        protected string pasarAHash(string password)
        {
            string hashresult = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            return hashresult;
        }

        //LOGIN
        protected void BtnLogIn(object sender, EventArgs e)
        {
            Registrado reg = new Registrado();
            reg.mail = this.TxtMail.Text;
            bool existe = reg.Leer();

            if (existe)
            {
                string retornoPass = reg.ComprobarPass();
                string password = this.TxtPassword.Text;
                string salt = "10";
                string passConHash = pasarAHash(password).ToLower()+salt;

                //string passHash = password + salt;

                if (passConHash == retornoPass) {
                    //Le agrega los datos a la Session
                    Session["logueado"] = true;
                    Session["mail"] = reg.mail;
                    Session["id"] = reg.id;
                    Response.Redirect("../Views/home.aspx");
                }
                else{
                    //Usuario inexistente
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Contraseña incorrecto</span></div>";
                }
            }
            else {

                //Usuario inexistente
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Usuario inexistente, o incorrecto</span></div>";
            }

            //int idrol = Registrado.ExisteUsuario(this.UserName.Text, this.Password.Text);
            //if (idrol == 1)
            //{
            //    //Empresa unaEmpresa = new Empresa();
            //    //unaEmpresa = Empresa.Instancia.cargarDatosEmpresa(this.UserName.Text);
            //    Session["logueado"] = true;
            //    //Session["nombre"] = unaEmpresa.Nombre;
            //    //Session["email"] = unaEmpresa.MailPublico;
            //    Session["idRol"] = idrol;
            //    Response.Redirect("../");
            //}
            //else if (idrol == 2)
            //{
            //    //UsuarioEventosUY unUsuarioEventoUy = new UsuarioEventosUY();
            //    //unUsuarioEventoUy = UsuarioEventosUY.Instancia.cargarDatosUsuario(this.UserName.Text);
            //    Session["logueado"] = true;
            //    //Session["nombre"] = unUsuarioEventoUy.Nombre;
            //    //Session["email"] = unUsuarioEventoUy.Email;
            //    Session["idRol"] = idrol;
            //    Response.Redirect("../");
            //}
            //else
            //{
            //    //Usuario inexistente
            //    this.errorField.Visible = true;
            //    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Usuario inexistente, o incorrecto</span></div>";
            //}

        }
        
    }
}