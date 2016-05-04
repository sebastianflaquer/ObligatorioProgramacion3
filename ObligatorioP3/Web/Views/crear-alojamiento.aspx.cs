using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class crear_alojamiento : System.Web.UI.Page
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
                    CargarFormularioAlojamiento();
                    Session["listaServicios"] = new List<Servicio>();
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }

        //CARGA EL FORMULARIO DE ALOJAMIENTO
        protected void CargarFormularioAlojamiento(){

            //carga las categorias
            #region categoria
            Categoria Cat = new Categoria();
            List<Categoria> L1 = new List<Categoria>();
            L1 = Cat.CargarCategorias();

            this.CategoriaDropD.DataSource = L1;
            this.CategoriaDropD.DataTextField = "nombre";
            this.CategoriaDropD.DataValueField = "id";
            this.CategoriaDropD.DataBind();
            #endregion

            //Carga el tipo de habitacion
            #region tipohabitacion
            TipoHabitacionDropD.Items.Add("Completo");
            TipoHabitacionDropD.Items.Add("Privada");
            TipoHabitacionDropD.Items.Add("compartida");
            #endregion

            //Carga el tipo de habitacion
            #region tipobanio
            TipoBanioDropD.Items.Add("Compartido");
            TipoBanioDropD.Items.Add("Privado");
            #endregion

            //Carga las ciudades
            #region Ciudad

            Ciudad Ciu = new Ciudad();
            List<Ciudad> L2 = new List<Ciudad>();
            L2 = Ciu.CargarCiudades();

            this.CiudadDropD.DataSource = L2;
            this.CiudadDropD.DataValueField = "id";
            this.CiudadDropD.DataTextField = "nombre";
            this.CiudadDropD.DataBind();
            #endregion

            //Carga los servicios
            #region Servicios
            Servicio serv = new Servicio();
            this.ServiciosListBox.DataSource = serv.CargarServicios();
            this.ServiciosListBox.DataValueField = "Id";
            this.ServiciosListBox.DataTextField = "Nombre";
            this.ServiciosListBox.DataBind();
            #endregion

        }
        
        //CREA EL NUEVO ALOJAMIENTO
        protected void btnCrearNuevoAlojamiento(object sender, EventArgs e)
        {
            bool ok = false;

            Alojamiento Aloj = new Alojamiento();
            string nomAloj = NombreAlojamiento.Text;
            Aloj.nombre = nomAloj;

            Categoria cat = new Categoria();
            cat.id = int.Parse(CategoriaDropD.SelectedValue);
            
            //CARGA LOS DATOS DE LA CATEGORIA - FALTA COMPLETAR
            cat.Leer();
            Aloj.categoria = cat;
            
            //TIPO HABITACION - se fiija si es compartido o no
            Aloj.tipoHabitacion = TipoHabitacionDropD.SelectedValue;
            if (TipoHabitacionDropD.SelectedValue == "Compartido"){
                Aloj.banioPrivado = false;
            }
            else{
                Aloj.banioPrivado = true;
            }

            // CANTIDAD HUESPEDES
            Aloj.cantHuespedes = int.Parse(CantHuespedes.Text);
            
            //CIUDAD - LEE LA CIUDAD SELECCIONADA
            Ciudad ciu = new Ciudad();
            ciu.id = int.Parse(CiudadDropD.SelectedValue);
            ciu.Leer();
            Aloj.ciudad = ciu;

            //BARRIO - LEE EL BARRIO SELECCIONADO
            Aloj.barrio = BarrioAloj.Text;

            //CARGO LOS SERVICIOS AGREGADOS A LA LISTA
            Aloj.servicios = Session["listaServicios"] as List<Servicio>;
            //ServiciosListBox.SelectedItems;

            //A QUE USUARIO PRETENECE
            Registrado reg2 = new Registrado();
            reg2.id = int.Parse(Session["Id"].ToString());
            reg2.mail = Session["mail"].ToString();
            reg2.Leer();
            Aloj.registrado = reg2;


            //COMPRUEBA QUE NO SE REPITA EL NOMBRE DE ALOJAMIENTO PARA ESTE USUARIO
            if (Aloj.ComprobarNombreAlojamiento(nomAloj, int.Parse(Session["id"].ToString())))
            {
                //NO pudo guardar el Alojamiento
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Nombre de Alojamiento repetido </span></div>";
            }
            else
            {
                ok = Aloj.Guardar();

                if (ok)
                {
                    //Si pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Alojamiento se creó con exito.</span></div>";
                }
                else
                {
                    //NO pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar crear el Alojamiento</span></div>";
                }
            }

        }


        //AGREGAR SERVICIOS A LA LISTA
        protected void incluirServicio_Click(object sender, EventArgs e)
        {
            //Oculta los mensajes de errores que se estan mostrando
            this.errorField.Visible = false;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span></span></div>";

            List<Servicio> listaServicios = Session["listaServicios"] as List<Servicio>;

            if (ServiciosListBox.SelectedValue == "") {

                //NO selecciono ningun servicio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Debe seleccionar un servicio</span></div>";
            }
            else{
                int idServ = int.Parse(this.ServiciosListBox.SelectedValue);

                //cuando ya tiene items en la lista
                if (listaServicios.Count != 0)
                {
                    bool encuentra = false;
                    int i = 0;
                    while (!encuentra && i < listaServicios.Count){
                        if(listaServicios[i].id != idServ)
                        {
                            i++;
                        }
                        else
                        {
                            encuentra = true;
                        }
                    }
                    if (encuentra)
                    {
                        //volvio a seleccionar el mismo servicio
                        this.errorField.Visible = true;
                        this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Este servicio ya fue agregado</span></div>";
                    }
                    else
                    {
                        Servicio serv = new Servicio();
                        serv.id = idServ;
                        serv.Leer();
                        listaServicios.Add(serv);
                        this.lblListaServicios.InnerHtml += "<span class='label label-default'>" + listaServicios[i].nombre + "</span> ";
                    }
                }
                else // no tiene items en la lista
                {
                    Servicio serv = new Servicio();
                    serv.id = idServ;
                    serv.Leer();
                    listaServicios.Add(serv);
                    this.lblListaServicios.InnerHtml += "<span class='label label-default'>" + serv.nombre + "</span> ";

                    //El item se agrego correctamente
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Se agrego el servicio correctamente</span></div>";

                }

            }
            
            //this.msjIncServ.Text = "Servicio agregado!";
        }



    }
}