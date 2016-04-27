using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class modificar_alojamiento : System.Web.UI.Page
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

        //CARGA LOS ALOJAMIENTOS DEPENDIENDO EL USUSARIO LOGUEADO
        protected void CargarAlojamientosDeUsuario()
        {

            #region alojamientos
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            //L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de categorias y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                ElejAlojamientoDropD.Items.Add(L1[i].nombre);
            }
        }
        #endregion

        protected void MostrarFormAModificar_Click(object sender, EventArgs e)
        {
            this.lblModAlojamiento.Visible = true;
            this.NombreModAlojamiento.Visible = true;
            this.lblModCat.Visible = true;
            this.CategoriaDropD.Visible = true;
            this.lblModTipoHab.Visible = true;
            this.TipoHabitacionDropD.Visible = true;
            this.lblModTipoBano.Visible = true;
            this.TipoBanioDropD.Visible = true;
            this.lblModCantHuesp.Visible = true;
            this.CantHuespedes.Visible = true;
            this.lblModCiud.Visible = true;
            this.CiudadDropD.Visible = true;
            this.lblModBarrio.Visible = true;
            this.BarrioAloj.Visible = true;
            this.ModServiciosListBox.Visible = true;
            this.btnActAloj.Visible = true;
            this.lblModServ.Visible = true;

            cargarAlojamiento();

        }

        //CARGAR DATOS DEL ALOJAMIENTO SELECCIONADO
        private void cargarAlojamiento()
        {
            Alojamiento aloj = new Alojamiento();
            aloj.nombre = this.ElejAlojamientoDropD.SelectedValue;    // TIENE QUE AGARRAR EL ID!!!!!
            bool existe = aloj.Leer();                                //IMPLEMENTAR LEER

            //Cargamos el form con los datos del alojamiento
            this.NombreModAlojamiento.Text = aloj.nombre;
            this.CategoriaDropD.Items.Add(aloj.categoria.ToString());
            this.TipoHabitacionDropD.Items.Add(aloj.tipoHabitacion.ToString());
            this.TipoBanioDropD.Items.Add(aloj.banioPrivado.ToString());
            this.CantHuespedes.Text = aloj.cantHuespedes.ToString();
            this.CiudadDropD.Items.Add(aloj.ciudad.ToString());
            this.BarrioAloj.Text = aloj.barrio;

            //Carga los servicios
            #region Servicios
            Servicio serv = new Servicio();
            //this.ModServiciosListBox.DataSource = serv.CargarServiciosPorAlojamiento(aloj.id);   //ARREGLAR PARA QUE TOME EL ID
            this.ModServiciosListBox.DataValueField = "Nombre";
            //this.ServiciosListBox.DataTextField = "Listado";
            this.ModServiciosListBox.DataBind();
            #endregion

        }
    }
}