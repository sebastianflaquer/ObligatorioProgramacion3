using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class baja_alojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es PostBack
            if (IsPostBack)
            {

            }
            else {
                CargarAlojamientosDeUsuario();
            }
        }

        protected void CargarAlojamientosDeUsuario()
        {

            #region ALOJAMIENTOS
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de alojamientos y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                this.DropDElegirAlojamiento.Items.Add(L1[i].nombre);
            }
        }
        #endregion


        protected void ConfBajaAlojamiento_Click(object sender, EventArgs e)
        {
            string nomAlojamiento = this.DropDElegirAlojamiento.SelectedValue;
            Alojamiento alo = new Alojamiento();
            alo.nombre = nomAlojamiento;
            alo.Leer();
            bool ok = alo.Eliminar();  //IMPLEMENTAR
            if (ok)
            {
                //Si pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Alojamiento fue eliminado</span></div>";
            }
            else
            {
                //NO pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar eliminar el Alojamiento</span></div>";
            }
        }
    }
}