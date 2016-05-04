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
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                //Si es PostBack
                if (IsPostBack)
                {

                }
                else
                {
                    CargarAlojamientosDeUsuario();
                    Session["listaServicios"] = new List<Servicio>();
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }

        //CARGA LOS ALOJAMIENTOS DEPENDIENDO EL USUSARIO LOGUEADO al iniciar la pagina
        protected void CargarAlojamientosDeUsuario()
        {
            #region alojamientos
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            this.ElejAlojamientoDropD.DataSource = L1;
            this.ElejAlojamientoDropD.DataValueField = "id";
            this.ElejAlojamientoDropD.DataTextField = "nombre";
            this.ElejAlojamientoDropD.DataBind();
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
            aloj.id = int.Parse(this.ElejAlojamientoDropD.SelectedValue);    
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
            this.ModServiciosListBox.DataSource = serv.CargarServiciosPorAlojamiento(aloj.id); 
            this.ModServiciosListBox.DataValueField = "Id";
            this.ModServiciosListBox.DataTextField = "Nombre";
            this.ModServiciosListBox.DataBind();
            #endregion

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Alojamiento alo = new Alojamiento();
            alo.id = int.Parse(this.ElejAlojamientoDropD.SelectedValue);
            alo.nombre = this.NombreModAlojamiento.Text;
            alo.categoria.id = int.Parse(this.CategoriaDropD.SelectedValue);
            alo.tipoHabitacion = this.TipoHabitacionDropD.SelectedValue;
            alo.banioPrivado = bool.Parse(this.TipoBanioDropD.SelectedValue);
            alo.cantHuespedes = int.Parse(this.CantHuespedes.Text);
            alo.ciudad.id = int.Parse(this.CiudadDropD.SelectedValue);
            alo.barrio = this.BarrioAloj.Text;
            alo.servicios = Session["listaServicios"] as List<Servicio>;
            //alo.registrado.id = int.Parse(Session["id"].ToString());

            bool ok = alo.Modificar();

            if (ok)
            {
                // Si pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Alojamiento se modificó con exito.</span></div>";
            }
            else
            {
                //NO pudo guardar el Alojamiento
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar modificar el Alojamiento</span></div>";
            }

        }
    }
}