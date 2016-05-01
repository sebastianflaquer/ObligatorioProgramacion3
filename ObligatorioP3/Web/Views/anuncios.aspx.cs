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
            Anuncio anu = new Anuncio();
            this.GridAnuncioss.DataSource = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());
            this.GridAnuncioss.DataBind();
        }
    }
}