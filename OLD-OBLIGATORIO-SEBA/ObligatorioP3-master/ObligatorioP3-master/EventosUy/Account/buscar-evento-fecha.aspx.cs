using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_buscar_evento_fecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Boolean)Session["logueado"]) //Si esta logeado
        {

        
        }else
        {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }
    }

    //BTN BUSCAR POR FECHA
    protected void BtnBuscarFecha(object sender, EventArgs e)
    {
        List<Evento> EventosListados = new List<Evento>();



    }
}