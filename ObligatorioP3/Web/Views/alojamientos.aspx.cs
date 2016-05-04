using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class alojamientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (!Page.IsPostBack)
                {
                    Alojamiento Aloj = new Alojamiento();
                    this.GridAlojamientos.DataSource = Aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());
                    this.GridAlojamientos.DataBind();

                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }
    }
}