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
            //Si es PostBack
            if (IsPostBack)
            {

            }
            else {
                CargarAnunciosDeUsuario();
            }
        }

            //CARGA LOS ANUNCIOS DEPENDIENDO EL USUSARIO LOGUEADO
        protected void CargarAnunciosDeUsuario()
        {

            #region ANUNCIOS
            Anuncio anu = new Anuncio();
            List<Anuncio> L1 = new List<Anuncio>();

            L1 = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de alojamientos y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                this.DropDElegirAnuncio.Items.Add(L1[i].nombre);
            }
        }
        #endregion

        protected void ConfBajaAnuncio_Click(object sender, EventArgs e)
        {
            string nomAnuncio = this.DropDElegirAnuncio.SelectedValue;
            Anuncio anu = new Anuncio();
            anu.nombre = nomAnuncio;
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
        }
    }
}