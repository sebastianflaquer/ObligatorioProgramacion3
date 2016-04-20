using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Auxiliar;

namespace DMDM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool ok = false;

            Producto prod = new Producto();
            prod.Id = 2;
            ok = Utilidades.MapperProducto().Leer(prod);
            Response.Write("Leer prod = " + ok + "</br>");
            Response.Write(prod.ToString());

            //Producto p = new Producto();
            //p.Nombre = "Suavizante Chuavechito";
            //p.Precio = 100.99M;
            //ok = Utilidades.MapperProducto().Guardar(p);
            //Response.Write("Guardar prod = " + ok + "</br>");
            //Response.Write(p.ToString());
        }
    }
}