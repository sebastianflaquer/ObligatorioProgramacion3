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

            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            this.DropDElegirAloj.DataSource = L1;
            this.DropDElegirAloj.DataTextField = "nombre";
            this.DropDElegirAloj.DataValueField = "id";
            this.DropDElegirAloj.DataBind();

        }
        
        //CREAR Y AGREGAR RANGO FECHAS
        protected void CrearYagregarRango_Click(object sender, EventArgs e)
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
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El rango de fechas se guardo con exito</span></div>";
                }

            }
        }

        //CONFIRMAR ANUNCIO
        protected void ConfAnuncio_Click(object sender, EventArgs e)
        {
            bool ok = false;
            Anuncio anu = new Anuncio();
            anu.nombre = this.NombreAnuncio.Text;
            Alojamiento aloj = new Alojamiento();
            aloj.id = int.Parse(this.DropDElegirAloj.SelectedValue);
            aloj.Leer();
            anu.alojamiento = aloj;
            anu.descripcion = this.DscAnuncio.Text;
            anu.direccion1 = this.Dir1Anuncio.Text;
            anu.direccion2 = this.Dir2Anuncio.Text;
            //anu.fotos = this.FotosAnuncio;
            anu.precioBase = decimal.Parse(this.PrecioBaseAnuncio.Text);
            Registrado reg = new Registrado();
            reg.id = int.Parse(Session["Id"].ToString());

            reg.mail = (Session["mail"].ToString());
            anu.registrado = reg;
            anu.rangosFechas = Session["listaRangoFechas"] as List<RangoFechas>;


            //FOTOS

            string ruta = Server.MapPath("~/imagenes/anuncios/");
            string nombreFoto1Anuncio = reg.mail + "-1-" + this.Foto1Anuncio.FileName.Replace(" ", "_");
            string nombreFoto2Anuncio = reg.mail + "-2-" + this.Foto2Anuncio.FileName.Replace(" ", "_");
            string nombreFoto3Anuncio = reg.mail + "-3-" + this.Foto3Anuncio.FileName.Replace(" ", "_");
            anu.fotos = nombreFoto1Anuncio + ";" + nombreFoto2Anuncio + ";" + nombreFoto3Anuncio;

            if (this.Foto1Anuncio.HasFile && this.Foto2Anuncio.HasFile && this.Foto3Anuncio.HasFiles)

            {
                // Se separa la extensión del nombre del archivo para validarla
                string[] nomExt1 = this.Foto1Anuncio.FileName.Split('.');
                string[] nomExt2 = this.Foto2Anuncio.FileName.Split('.');
                string[] nomExt3 = this.Foto3Anuncio.FileName.Split('.');

                string tipoFile1 = nomExt1[nomExt1.Length - 1];
                string tipoFile2 = nomExt2[nomExt2.Length - 1];
                string tipoFile3 = nomExt3[nomExt3.Length - 1];

                //Revisamos si el archivo cuenta con una extension valida, pudiendo agregar o quitar.
                if ((tipoFile1 == "jpg") || (tipoFile1 == "png") && (tipoFile2 == "jpg") || (tipoFile2 == "png") && (tipoFile3 == "jpg") || (tipoFile3 == "png"))
                {
                    this.Foto1Anuncio.SaveAs(Server.MapPath("~/imagenes/anuncios/") + nombreFoto1Anuncio);
                    this.Foto2Anuncio.SaveAs(Server.MapPath("~/imagenes/anuncios/") + nombreFoto2Anuncio);
                    this.Foto3Anuncio.SaveAs(Server.MapPath("~/imagenes/anuncios/") + nombreFoto3Anuncio);
                }
                else
                {
                    //extension de archivo no valido
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Alguno de los archivos tiene una extensión no válida</span></div>";
                }
            }
            else
            {
                //No se cargaron la 3 fotos obligatorias 
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Debe seleccionar al menos 3 fotos de Anuncio</span></div>";
            }



            //COMPRUEBA QUE NO SE REPITA EL NOMBRE DE ANUNCIO PARA ESTE USUARIO
            if (anu.ComprobarNombreAnuncio(anu.nombre, int.Parse(Session["id"].ToString())))
            {
                //NO pudo guardar el Alojamiento
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Nombre de Anuncio repetido </span></div>";
            }
            else
            {
                ok = anu.Guardar();

                if (ok)
                {
                    //Si pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Anuncio se creó con exito.</span></div>";
                }
                else
                {
                    //NO pudo guardar el Alojamiento
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar crear el Anuncio</span></div>";
                }
            }
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

    }
}