using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class modificar_anuncio : System.Web.UI.Page
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

        protected void MostrarFormAnunModificar_Click(object sender, EventArgs e)
        {
            #region Mostrar Campos
            this.lblModCat.Visible = true;
            this.AlojamientoDropD.Visible = true;
            this.lblModAnuncio.Visible = true;
            this.NombreAnuncioMod.Visible = true;
            this.DscModAnu.Visible = true;
            this.TextBoxDscModAnu.Visible = true;
            this.lblDir1ModAnu.Visible = true;
            this.TextBoxDir1ModAnu.Visible = true;
            this.lblDir2ModAnu.Visible = true;
            this.TextBoxDir2ModAnu.Visible = true;
            this.lblFotosModAnu.Visible = true;
            this.lblPrecioBModAnu.Visible = true;
            this.TextBoxPrecioBase.Visible = true;
            this.lblRangoFechasMod.Visible = true;
            this.ModRangoFechaListBox.Visible = true;
            this.btnActAnu.Visible = true;

            #endregion

            cargarAnuncio();

        }

        //CARGA LOS ANUNCIOS DEL USUSARIO LOGUEADO
        protected void CargarAnunciosDeUsuario()
        {

            #region Anuncios
            Anuncio anu = new Anuncio();
            List<Anuncio> L1 = new List<Anuncio>();

            L1 = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de categorias y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                ElejAnuncioDropD.Items.Add(L1[i].nombre);
            }
        }
        #endregion

        //CARGAR DATOS DEL ANUNCIO SELECCIONADO
        private void cargarAnuncio()
        {
            Anuncio anu = new Anuncio();
            anu.nombre = this.ElejAnuncioDropD.SelectedValue;
            bool existe = anu.Leer();

            //Cargamos el form con los datos del alojamiento
            this.NombreAnuncioMod.Text = anu.nombre;
            this.AlojamientoDropD.Items.Add(anu.alojamiento.nombre);  // QUEDA EN NULL
            this.TextBoxDscModAnu.Text = anu.descripcion;
            this.TextBoxDir1ModAnu.Text = anu.direccion1;
            this.TextBoxDir2ModAnu.Text = anu.direccion2;
            this.TextBoxPrecioBase.Text = anu.precioBase.ToString();

            //Carga los rangos de Fecha
            #region Rangos Fecha
            RangoFechas rf = new RangoFechas();
            this.ModRangoFechaListBox.DataSource = rf.CargarRangosFechaDeAnuncio(anu.id);   
            this.ModRangoFechaListBox.DataValueField = "Id";
            this.ModRangoFechaListBox.DataTextField = "Fecha";   //DEBERIA MOSTRAR FECHAS Y PRECIO
            this.ModRangoFechaListBox.DataBind();
            #endregion

        }
    }
}