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
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                //Si es PostBack
                if (IsPostBack)
                {

                }
                else
                {
                    CargarAnunciosDeUsuario();
                    Session["listaRangoFechas"] = new List<RangoFechas>();
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
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
            Anuncio anu = new Anuncio();
            List<Anuncio> L1 = new List<Anuncio>();
            
            L1 = anu.CargarAnunciosPorUsuario(Session["mail"].ToString());

            if (L1.Count == 0)//si no tiene items en la lista
            {
                this.listaSinAnuncios.Visible = true;
                this.formModificar.Visible = false;
                this.listaSinAnuncios.InnerHtml = "<div class='col-md-12'><h1>Upss!!!</h1><h3>No tienes anuncios</h3><br /><a class='btn btn-warning' href='home.aspx'>Volver al home</a></div>";
            }
            else//si tiene items en la lista
            {
                this.ElejAnuncioDropD.DataSource = L1;
                this.ElejAnuncioDropD.DataValueField = "id";
                this.ElejAnuncioDropD.DataTextField = "nombre";
                this.ElejAnuncioDropD.DataBind();
            }
        }


        //CARGAR DATOS DEL ANUNCIO SELECCIONADO
        private void cargarAnuncio()
        {
            Anuncio anu = new Anuncio();
            anu.id = int.Parse(this.ElejAnuncioDropD.SelectedValue);
            bool existe = anu.Leer();

            //Cargamos el form con los datos del alojamiento
            this.NombreAnuncioMod.Text = anu.nombre;
            Alojamiento alo = new Alojamiento();
            alo.id = anu.alojamiento.id;
            alo.Leer();
            List<Alojamiento> lista = new List<Alojamiento>();
            lista = alo.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            this.AlojamientoDropD.DataSource = lista;
            this.AlojamientoDropD.DataValueField = "id";
            this.AlojamientoDropD.DataTextField = "nombre";
            this.AlojamientoDropD.DataBind();
            this.AlojamientoDropD.SelectedValue = alo.id.ToString();

            this.TextBoxDscModAnu.Text = anu.descripcion;
            this.TextBoxDir1ModAnu.Text = anu.direccion1;
            this.TextBoxDir2ModAnu.Text = anu.direccion2;
            this.TextBoxPrecioBase.Text = anu.precioBase.ToString();

            //Carga los rangos de Fecha
            #region Rangos Fecha
            cargarListBoxConFR();
            #endregion

        }

        protected void btnMstAgrRf_Click(object sender, EventArgs e)
        {
            this.mostrarCamposAgrRF.Visible = true;
        }

        protected void btnConfRF_Click(object sender, EventArgs e)
        {
            //Crea un nuevo objeto RangoFechas y le carga los campos del formulario
            RangoFechas rangoF = new RangoFechas();
            string txtDesde = this.fchaIniAnuncio.Text;
            string txtHasta = this.fchaFinAnuncio.Text;
            rangoF.fechaInicio = DateTime.Parse(txtDesde);
            rangoF.fechaFin = DateTime.Parse(txtHasta);

            rangoF.precio = decimal.Parse(this.PrecioRango.Text);

            List<RangoFechas> listaRF = Session["listaRangoFechas"] as List<RangoFechas>;

            if (rangoF.fechaFin < rangoF.fechaInicio)
            {
                //Rango  no valido
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Rango no es válido</span></div>";

            }
            else
            {
                if (yaEstaRangoF(rangoF.fechaInicio, rangoF.fechaFin, listaRF) || fechaValida(rangoF) == false)
                {
                    //NO pudo guardar el rango
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar agregar al rango de fechas o el año no es válido</span></div>";
                }
                else
                {
                    listaRF.Add(rangoF);
                    //LIMPIAR 
                    fchaIniAnuncio.Text = "";
                    fchaFinAnuncio.Text = "";
                    PrecioRango.Text = "";

                    //Si pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El rango de fechas se guardó con exito</span></div>";
                    cargarListBoxConFR();
                }

            }
        }

        protected void cargarListBoxConFR()
        {
            RangoFechas rf = new RangoFechas();
            this.ModRangoFechaListBox.DataSource = rf.CargarRangosFechaDeAnuncio(int.Parse(this.ElejAnuncioDropD.SelectedValue));
            this.ModRangoFechaListBox.DataValueField = "Id";
            this.ModRangoFechaListBox.DataTextField = "Listado";
            this.ModRangoFechaListBox.DataBind();
        }

        //VALIDACIONES DE RANGO DE FECHAS
        protected bool yaEstaRangoF(DateTime fIni, DateTime fFin, List<RangoFechas> lista)
        {
            bool ok = false;

            if (lista.Count == 0)
            {
                return ok;
            }
            else
            {
                int i = 0;
                //SI NO ESTA VACÍA..RECORRELA
                while (i < lista.Count && ok == false)
                {
                    if (fIni >= lista[i].fechaInicio && fIni <= lista[i].fechaFin || fFin <= lista[i].fechaFin && fFin >= lista[i].fechaInicio)
                    {
                        ok = true;
                    }
                    else
                    {
                        i++;
                    }
                }
                return ok;
            }
        }

        //VALIDA LAS FECHAS
        protected bool fechaValida(RangoFechas rango)
        {
            bool ok = false;

            if (rango.fechaInicio.Year == DateTime.Today.Year && rango.fechaFin.Year == DateTime.Today.Year)
            {
                ok = true;
            }
            return ok;
        }

        protected void btnActAnu_Click(object sender, EventArgs e)
        {
            Anuncio anu = new Anuncio();
            anu.id = int.Parse(this.ElejAnuncioDropD.SelectedValue);
            anu.nombre = this.NombreAnuncioMod.Text;
            Alojamiento a = new Alojamiento();
            a.id = int.Parse(this.AlojamientoDropD.SelectedValue);
            anu.alojamiento = a;
            anu.descripcion = this.TextBoxDscModAnu.Text;
            anu.direccion1 = this.TextBoxDir1ModAnu.Text;
            anu.direccion2 = this.TextBoxDir2ModAnu.Text;
            //anu.fotos =    ESTO FALTA
            anu.precioBase = decimal.Parse(this.TextBoxPrecioBase.Text);
            anu.rangosFechas = Session["listaRangoFechas"] as List<RangoFechas>;

            bool ok = anu.Modificar();

            if (ok)
            {
                // Si pudo quitar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Anuncio se modificó con exito</span></div>";
            }
            else
            {
                //NO pudo guardar el Servicios
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar modificar el Anuncio</span></div>";
            }

        }
    }
}