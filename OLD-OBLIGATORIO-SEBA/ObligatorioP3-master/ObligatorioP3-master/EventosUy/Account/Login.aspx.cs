using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using EventosUy;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if ((Boolean)Session["logueado"]) //Si esta logeado
            {
                Response.Redirect("../");
            }
            else //Si no esta logeado
            {

            }            
        }

        protected void LogIn(object sender, EventArgs e)
        {

            int idrol = UsuarioEventosUY.validarSiesAdminOEmpresa(this.UserName.Text, this.Password.Text);

            //
            //int idrol = unEuy.idRol;

            if (idrol == 1) { //SI ES ADMINISTRADOR
                
                UsuarioEventosUY unEuy = UsuarioEventosUY.CargarAdmin(this.UserName.Text, this.Password.Text);
                Session["logueado"] = true;
                Session["nombre"] = unEuy.Nombre;
                Session["email"] = unEuy.Email;
                Session["idRol"] = idrol;
                Response.Redirect("../");

            }else if(idrol == 2){ //SI ES EMPRESA

                Empresa unaEmpresa = Empresa.cargarEmpresaDatos(this.UserName.Text, this.Password.Text);
                Session["logueado"] = true;
                Session["nombre"] = unaEmpresa.Nombre;
                Session["email"] = unaEmpresa.MailPublico;
                Session["idRol"] = idrol;
                Response.Redirect("../");

            }else{

                //Usuario inexistente
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Usuario inexistente</span></div>";

            }
           
        }
}