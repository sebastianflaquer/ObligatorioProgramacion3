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

        //CARGA LOS ALOJAMIENTOS DEPENDIENDO EL USUSARIO LOGUEADO al iniciar la pagina
        protected void CargarAlojamientosDeUsuario()
        {
            #region alojamientos
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de categorias y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                ElejAlojamientoDropD.Items.Add(L1[i].nombre);
            }
            #endregion
        }


        protected void MostrarFormAModificar_Click(object sender, EventArgs e)
        {
            #region MostrarCampos
            //muestra div del contenedor
            this.contentModificar.Visible = true;
            #endregion

            cargarAlojamiento();

        }

        //CARGAR DATOS DEL ALOJAMIENTO SELECCIONADO
        private void cargarAlojamiento()
        {
            Alojamiento aloj = new Alojamiento();
            aloj.nombre = this.ElejAlojamientoDropD.SelectedValue;    
            bool existe = aloj.Leer();                                

            //Cargamos el form con los datos del alojamiento
            this.NombreModAlojamiento.Text = aloj.nombre;

            Categoria cat = new Categoria();
            cat.id = aloj.categoria.id;
            cat.Leer();
            this.CategoriaDropD.Items.Add(cat.nombre);
            this.TipoHabitacionDropD.Items.Add(aloj.tipoHabitacion);
            this.TipoBanioDropD.Items.Add(aloj.banioPrivado.ToString());
            this.CantHuespedes.Text = aloj.cantHuespedes.ToString();

            Ciudad ciud = new Ciudad();
            ciud.id = aloj.ciudad.id;
            ciud.Leer();
            this.CiudadDropD.Items.Add(ciud.nombre);
            this.BarrioAloj.Text = aloj.barrio;

            //Carga los servicios
            #region Servicios
            Servicio serv = new Servicio();
            this.ModServiciosListBox.DataSource = serv.CargarServiciosPorAlojamiento(aloj.id);   //ARREGLAR PARA QUE TOME EL ID
            this.ModServiciosListBox.DataValueField = "Id";
            this.ModServiciosListBox.DataTextField = "Nombre";
            this.ModServiciosListBox.DataBind();
            #endregion

        }
    }
}