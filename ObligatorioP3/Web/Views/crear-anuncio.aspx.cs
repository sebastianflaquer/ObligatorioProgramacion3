using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class crear_anuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es PostBack
            if (IsPostBack)
            {

            }
            else {
                CargarAlojamientosDeUsuario();
                Session["listaRangoFechas"] = new List<RangoFechas>();
            }
        }

        //CARGA LOS ALOJAMIENTOS DEPENDIENDO EL USUSARIO LOGUEADO
        protected void CargarAlojamientosDeUsuario()
        {

            #region alojamientos
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de alojamientos y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                this.DropDElegirAloj.Items.Add(L1[i].nombre);
            }
        }
            #endregion


        //CREAR Y AGREGAR RANGO FECHAS
        protected void CrearYagregarRango_Click(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {
                //variables
                //bool afectadas;

                //Crea un nuevo objeto RangoFechas y le carga los campos del formulario
                RangoFechas rangoF = new RangoFechas();
                string txtDesde = this.fchaIniAnuncio.Text;
                string txtHasta = this.fchaFinAnuncio.Text;
                rangoF.fechaInicio = DateTime.Parse(txtDesde);
                rangoF.fechaFin = DateTime.Parse(txtHasta);
                rangoF.precio = decimal.Parse(this.PrecioRango.Text);

                List<RangoFechas> listaRF = Session["listaRangoFechas"] as List<RangoFechas>;
                listaRF.Add(rangoF);


                //Carga en afectadas el retorno de Guardar();
                //afectadas = rangoF.Guardar();
                //if (afectadas)
                //{
                    //LIMPIAR 
                    fchaIniAnuncio.Text = "";
                    fchaFinAnuncio.Text = "";
                    PrecioRango.Text = "";
               // }
            }
        }

        protected void ConfAnuncio_Click(object sender, EventArgs e)
        {
            bool ok = false;
            Anuncio anu = new Anuncio();
            anu.nombre = this.NombreAnuncio.Text;
            Alojamiento aloj = new Alojamiento();
            aloj.id = 8;                             //ARREGLAR
                string pru = this.DropDElegirAloj.SelectedValue;
            anu.alojamiento = aloj;
            anu.descripcion = this.DscAnuncio.Text;
            anu.direccion1 = this.Dir1Anuncio.Text;
            anu.direccion2 = this.Dir2Anuncio.Text;
            //anu.fotos = this.FotosAnuncio;
            anu.precioBase = decimal.Parse(this.PrecioBaseAnuncio.Text);
            Registrado reg = new Registrado();
            reg.id = int.Parse(Session["Id"].ToString());
            anu.registrado = reg;
            anu.rangosFechas = Session["listaRangoFechas"] as List<RangoFechas>;

            ok = anu.Guardar();

            if (ok)
            {
                //Si pudo guardar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Anuncio se creó con exito.</span></div>";
            }
            else
            {
                //NO pudo guardar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar crear el Anuncio</span></div>";
            }
        }
    }
}