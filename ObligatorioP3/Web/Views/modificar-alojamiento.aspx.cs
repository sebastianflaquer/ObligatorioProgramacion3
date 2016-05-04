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
            this.btnAgregarServicio.Visible = false;
            this.btnAgregarOtros.Visible = true;
            this.btnQuitarServicios.Visible = true;

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
            
            //Carga categorias
            Categoria cat = new Categoria();
            List<Categoria> listaCat = cat.CargarCategorias();
            this.CategoriaDropD.DataSource = listaCat;
            this.CategoriaDropD.DataValueField = "id";
            this.CategoriaDropD.DataTextField = "nombre";
            this.CategoriaDropD.DataBind();
            this.CategoriaDropD.SelectedValue = aloj.categoria.id.ToString();

            //Cargo tipo de Habitacion
            this.TipoHabitacionDropD.Items.Add("Privada");
            this.TipoHabitacionDropD.Items.Add("Compartida");
            this.TipoHabitacionDropD.Items.Add("Completo");
            this.TipoHabitacionDropD.SelectedValue = aloj.tipoHabitacion;


            //cargo tipo de Baño
            this.TipoBanioDropD.Items.Add("Privado");
            this.TipoBanioDropD.Items.Add("Compartido");

            if (aloj.banioPrivado == true)
            {
                this.TipoBanioDropD.SelectedValue = "Privado";
            }
            else
            {
                this.TipoBanioDropD.SelectedValue = "Compartido";
            }
            //this.TipoBanioDropD.Items.Add(aloj.banioPrivado.ToString());

            //cargo cantidad de huespedes
            this.CantHuespedes.Text = aloj.cantHuespedes.ToString();

            //cargo ciudades
            Ciudad ciud = new Ciudad();
            List<Ciudad> listaC = ciud.CargarCiudades();
            this.CiudadDropD.DataSource = listaC;
            this.CiudadDropD.DataValueField = "id";
            this.CiudadDropD.DataTextField = "nombre";
            this.CiudadDropD.DataBind();
            this.CiudadDropD.SelectedValue = aloj.ciudad.id.ToString();

            //Cargo Barrio
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

        private void cargarServicios()
        {
            Servicio serv = new Servicio();
            this.ModServiciosListBox.DataSource = serv.CargarServiciosPorAlojamiento(int.Parse(this.ElejAlojamientoDropD.SelectedValue));
            this.ModServiciosListBox.DataValueField = "Id";
            this.ModServiciosListBox.DataTextField = "Nombre";
            this.ModServiciosListBox.DataBind();
        }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Alojamiento alo = new Alojamiento();
            alo.id = int.Parse(this.ElejAlojamientoDropD.SelectedValue);
            alo.nombre = this.NombreModAlojamiento.Text;
            Categoria cat = new Categoria();
            cat.id = int.Parse(this.CategoriaDropD.SelectedValue);
            alo.categoria = cat;
            alo.tipoHabitacion = this.TipoHabitacionDropD.SelectedValue;

            bool esPrviado;
            if (this.TipoBanioDropD.SelectedValue == "Privado")
            { esPrviado = true; }
            else { esPrviado = false; }

            alo.banioPrivado = esPrviado;
            alo.cantHuespedes = int.Parse(this.CantHuespedes.Text);
            Ciudad c = new Ciudad();
            c.id = int.Parse(this.CiudadDropD.SelectedValue);
            alo.ciudad = c;
            alo.barrio = this.BarrioAloj.Text;
            
            List<Servicio> listaDefinitiva = new List<Servicio>();
            Servicio s = new Servicio();
            listaDefinitiva = s.CargarServiciosPorAlojamiento(alo.id);
            alo.servicios = listaDefinitiva;

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

        private void cargarServiciosQueLeFalta()
        { 
        Servicio s = new Servicio();
        List<Servicio> listaS = new List<Servicio>();
        listaS = s.CargarServiciosQueLeFalta(int.Parse(this.ElejAlojamientoDropD.SelectedValue));
            this.DropDownListServicios.DataSource = listaS;
            this.DropDownListServicios.DataValueField = "id";
            this.DropDownListServicios.DataTextField = "nombre";
            this.DropDownListServicios.DataBind();
        }

        protected void btnAgregarMasServicios_Click(object sender, EventArgs e)
        {
            this.lblListaTodosServicios.Visible = true;
            this.DropDownListServicios.Visible = true;
            this.btnAgregarServicio.Visible = true;
            cargarServiciosQueLeFalta();
        }

        protected void AgregarServicio_Click(object sender, EventArgs e)
        {
            Servicio nuevo = new Servicio();
            nuevo.id = int.Parse(this.DropDownListServicios.SelectedValue);
            int idAloj = int.Parse(this.ElejAlojamientoDropD.SelectedValue);
            bool ok = nuevo.AgregarServicioAlAlojamiento(idAloj);

            if (ok)
            {
                // Si pudo guardar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El servicio fue agregado.</span></div>";
                cargarServicios();
                cargarServiciosQueLeFalta();

            }
            else
            {
                //NO pudo guardar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar agregar el servicio</span></div>";
            }


        }

        protected void btnQuitarServicio_Click(object sender, EventArgs e)
        {
            Servicio s = new Servicio();
            s.id = int.Parse(this.ModServiciosListBox.SelectedValue);
            bool ok = s.QuitarServicioAlAlojamiento();

            if (ok)
            {
                // Si pudo quitar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Se quitó el servicio.</span></div>";
                cargarServicios();
                cargarServiciosQueLeFalta();
            }
            else
            {
                //NO pudo guardar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar quitar el servicio</span></div>";
            }

        }
    }
}