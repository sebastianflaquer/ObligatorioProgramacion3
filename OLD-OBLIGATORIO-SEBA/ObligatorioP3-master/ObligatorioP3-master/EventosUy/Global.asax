<%@ Application Language="C#" %>
<%@ Import Namespace="EventosUy" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    //void Session_Start(object sender, EventArgs e)
    //{
    //    Session["carritoCompra"] = new List<Articulo>();
    //    Session["logueado"] = false;
    //    Session["nombre"] = "";
    //    Session["email"] = "";
    //    Session["tipo"] = Cliente.tipoUsuario.Cliente;
    //}

    void Session_Start(object sender, EventArgs e)
    {
        Session["logueado"] = false;
        Session["nombre"] = "";
        Session["email"] = "";
        Session["idRol"] = "";
    }
</script>
