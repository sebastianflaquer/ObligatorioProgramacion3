using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using BienvenidosUY;


namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Persistente.StringConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["logueado"] = false;
            Session["nombre"] = "";
            Session["email"] = "";
            Session["idRol"] = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}