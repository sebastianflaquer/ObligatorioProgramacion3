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
            //Si es PostBack
            if (IsPostBack)
            {
                
            }
            else {
                CargarFormularioAlojamiento();
                Session["listaServicios"] = new List<Servicio>();
            }
        }

        //CARGA EL FORMULARIO DE ALOJAMIENTO
        protected void CargarFormularioAlojamiento(){

            //carga las categorias
            #region categoria
            Categoria Cat = new Categoria();
            List<Categoria> L1 = new List<Categoria>();
            L1 = Cat.CargarCategorias();

            //Recorre la lista de categorias y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                CategoriaDropD.Items.Add(L1[i].nombre);
            }
            #endregion

            //Carga el tipo de habitacion
            #region tipohabitacion
            TipoHabitacionDropD.Items.Add("Todo el alojamiento");
            TipoHabitacionDropD.Items.Add("Habitacion Privada");
            TipoHabitacionDropD.Items.Add("Habitacion compartida");
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

            for (int i = 0; i < L2.Count; i++)
            {
                CiudadDropD.Items.Add(L2[i].nombre);
            }
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
            cat.nombre = CategoriaDropD.SelectedValue;
            
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
            ciu.nombre = CiudadDropD.SelectedValue;
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

        //MUESTRA LOS CAMPOS
        protected void NuevoServicio_Click(object sender, EventArgs e)
        {
            this.NomServicio.Visible = true;
            this.lblDscServ.Visible = true;
            this.lblNomServ.Visible = true;
            this.DscServicio.Visible = true;
            this.btnAgrServ.Visible = true;

            //VALIDA LA PAGINA
            //Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            //if (Page.IsValid)
            //{

            //variables
            //bool afectadas;

            //Crea un nuevo objeto Servicio y le carga los campos del formulario
            //Servicio serv = new Servicio();
            //serv.nombre = this.NomServicio.Text;
            //serv.descripcion = this.DscServicio.Text;

            //Carga en afectadas el retorno de Guardar();
            //afectadas = serv.Guardar();
            //if (afectadas)
            //{
            //LIMPIAR EL FORMULARIO
            //Categoria.Text = "";
            //BanioP.Checked = false;
            //CantHuespedes.Text = "";
            //CiudadAloj.Text = "";
            //BarrioAloj.Text = "";
            //NomServicio.Text = "";
            //DscServicio.Text = "";
            //}
            //}

        }

        //CREA UN NUEVO SERVICIO
        protected void btnAgrServ_Click(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {

                //variables
            bool afectadas;

                //Crea un nuevo objeto Servicio y le carga los campos del formulario
                Servicio serv = new Servicio();
                serv.nombre = this.NomServicio.Text;
                serv.descripcion = this.DscServicio.Text;

                //Carga en afectadas el retorno de Guardar();
                afectadas = serv.Guardar();
                if (afectadas)
                {
                  //  LIMPIAR EL FORMULARIO
                    //Categoria.Text = "";
                    //BanioP.Checked = false;
                    //CantHuespedes.Text = "";
                    //CiudadAloj.Text = "";
                    //BarrioAloj.Text = "";
                    //NomServicio.Text = "";
                    //DscServicio.Text = "";
                }
            }
        }


        //AGREGAR SERVICIOS A LA LISTA
        protected void incluirServicio_Click(object sender, EventArgs e)
        {
            List<Servicio> listaServicios = Session["listaServicios"] as List<Servicio>;
            int idServ = int.Parse(this.ServiciosListBox.SelectedValue);
            Servicio serv = new Servicio();
            serv.id = idServ;
            serv.Leer();
            listaServicios.Add(serv);
            this.msjIncServ.Text = "Servicio agregado!";
        }



    }
}