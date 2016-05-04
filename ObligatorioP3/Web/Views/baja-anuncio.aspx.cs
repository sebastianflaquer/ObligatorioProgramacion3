using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class baja_anuncio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {

                if ((bool)Session["logueado"]) //Si esta logeado
                {
                    //Si es PostBack
                    if (IsPostBack)
                    {

                    }
                    else
                    {
                        CargarAnunciosDeUsuario();
                    }
                }
                else //Si no esta logeado lo redirecciona al login
                {
                    Response.Redirect("../Views/sign-up.aspx");
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }

            //CARGA LOS ANUNCIOS DEPENDIENDO EL USUSARIO LOGUEADO
        protected void CargarAnunciosDeUsuario()
        {

            this.errorField.Visible = false;

            Anuncio anu = new Anuncio();
            List<Anuncio> L1 = new List<Anuncio>();

            L1 = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());

            if(L1.Count == 0)//si no tiene items en la lista
            {
                this.listaSinAnuncios.Visible = true;
                this.formEliminarAnuncio.Visible = false;
                this.listaSinAnuncios.InnerHtml = "<div class='col-md-12'><h1>Upss!!!</h1><h3>No tienes anuncios para eliminar</h3><br /><a class='btn btn-warning' href='home.aspx'>Volver al home</a></div>";
            }
            else//si tiene items en la lista
            {
                this.listaSinAnuncios.Visible = false;
                this.formEliminarAnuncio.Visible = true;
                this.DropDElegirAnuncio.DataSource = L1;
                this.DropDElegirAnuncio.DataValueField = "id";
                this.DropDElegirAnuncio.DataTextField = "nombre";
                this.DropDElegirAnuncio.DataBind();
            }
        }


        protected void ConfBajaAnuncio_Click(object sender, EventArgs e)
        {
            Anuncio anu = new Anuncio();
            anu.id = int.Parse(this.DropDElegirAnuncio.SelectedValue);
            anu.Leer();
            bool ok = anu.Eliminar();  //IMPLEMENTAR
            if (ok)
            {
                //Si pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Anuncio fue eliminado</span></div>";
            }
            else
            {
                //NO pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar eliminar el Anuncio</span></div>";
            }

            CargarAnunciosDeUsuario();

        }
    }
}