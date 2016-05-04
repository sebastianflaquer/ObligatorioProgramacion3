using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class anuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (!Page.IsPostBack)
                {   
                    Anuncio anu = new Anuncio();
                    List<Anuncio> L1 = new List<Anuncio>();
                    L1 = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());

                    if (L1.Count == 0)//si no tiene items en la lista
                    {
                        this.listaSinAnuncios.Visible = true;
                        this.GridAnuncioss.Visible = false;
                        this.listaSinAnuncios.InnerHtml = "<div class='col-md-12'><h1>Upss!!!</h1><h3>No tienes anuncios</h3><br /><a class='btn btn-warning' href='home.aspx'>Volver al home</a></div>";
                    }
                    else//si tiene items en la lista
                    {
                        this.GridAnuncioss.DataSource = L1;
                        this.GridAnuncioss.DataBind();
                    }
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }
    }
}