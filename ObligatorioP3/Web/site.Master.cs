using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                this.lblEmailMaster.Text = Session["mail"].ToString();
                this.divMenuLogeado.Visible = true;
                this.divMenuDeslogeado.Visible = false;

            }
            else //Si no esta logeado
            {
                this.divMenuLogeado.Visible = false;
                this.divMenuDeslogeado.Visible = true;
            }
        }

        //BTN CERRAR SESION
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["logueado"] = false;
            Session["mail"] = "";
            Response.Redirect("/Views/sign-up.aspx");
        }
    }

}