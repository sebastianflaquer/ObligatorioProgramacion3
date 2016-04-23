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

            //Carga las ciudades
            #region Servicios
            Servicio serv = new Servicio();
            this.ServiciosListBox.DataSource = serv.CargarServicios();
            this.ServiciosListBox.DataValueField = "Nombre";
            //this.ServiciosListBox.DataTextField = "Listado";
            this.ServiciosListBox.DataBind();
            #endregion

        }
        
        //CREA EL NUEVO ALOJAMIENTO
        protected void btnCrearNuevoAlojamiento(object sender, EventArgs e)
        {
            bool afectadas = false;

            Alojamiento Aloj = new Alojamiento();
            Aloj.nombre = NombreAlojamiento.Text;

            Categoria cat = new Categoria();
            cat.nombre = CategoriaDropD.SelectedValue;
            //CARGA LOS DATOS DE LA CATEGORIA - FALTA COMPLETAR
            cat.Leer();
            Aloj.categoria = cat;

            Aloj.tipoHabitacion = TipoHabitacionDropD.SelectedValue;

            //se fiija si es compartido o no
            if(TipoHabitacionDropD.SelectedValue == "Compartido"){
                Aloj.banioPrivado = false;
            }
            else{
                Aloj.banioPrivado = true;
            }

            Aloj.cantHuespedes = int.Parse(CantHuespedes.Text);

            Ciudad ciu = new Ciudad();
            ciu.nombre = CiudadDropD.SelectedValue;
            ciu.Leer();

            Aloj.ciudad = ciu;

            Aloj.barrio = BarrioAloj.Text;

            Aloj.servicios = new List<Servicio>();
                //ServiciosListBox.SelectedItems;

            //afectadas = Aloj.Guardar();

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
    }
}