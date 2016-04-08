using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{


    //private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    //private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    //private string _antiXsrfTokenValue;

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    // El código siguiente ayuda a proteger frente a ataques XSRF
    //    var requestCookie = Request.Cookies[AntiXsrfTokenKey];
    //    Guid requestCookieGuidValue;
    //    if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
    //    {
    //        // Utilizar el token Anti-XSRF de la cookie
    //        _antiXsrfTokenValue = requestCookie.Value;
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;
    //    }
    //    else
    //    {
    //        // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
    //        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;

    //        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
    //        {
    //            HttpOnly = true,
    //            Value = _antiXsrfTokenValue
    //        };
    //        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
    //        {
    //            responseCookie.Secure = true;
    //        }
    //        Response.Cookies.Set(responseCookie);
    //    }

    //    Page.PreLoad += master_Page_PreLoad;
    //}

    //protected void master_Page_PreLoad(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        // Establecer token Anti-XSRF
    //        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
    //        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
    //    }
    //    else
    //    {
    //        // Validar el token Anti-XSRF
    //        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
    //            || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
    //        {
    //            throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
    //        }
    //    }
    //}
    
    public Label LblEmailMaster
    {
        get { return this.lblEmailMaster; }
        set { lblEmailMaster = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {   
        this.lblEmailMaster.Text = Session["email"].ToString();

        if ((Boolean)Session["logueado"])
        {
            this.divLogin.Visible = false;            
            this.divDatosLogeado.Visible = true;

            string Sidrol = Session["idRol"].ToString();
            int idrol = Convert.ToInt32(Sidrol);

            if (idrol == 1)//Empresa
            {
                this.divMenuLogeado.Visible = true;
            }
            else if (idrol == 2)//Usuario
            {   
                this.divMenuLogeadoUsuario.Visible = true;
            }
        }
        else
        {
            this.divDatosLogeado.Visible = false;
            this.divMenuLogeado.Visible = false;
            this.divLogin.Visible = true;
        }
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["logueado"] = false;
        Session["email"] = "";
        Session["idRol"] = -1;
        Response.Redirect("/");
    }


    //protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    //{
    //    Context.GetOwinContext().Authentication.SignOut();
    //}
}