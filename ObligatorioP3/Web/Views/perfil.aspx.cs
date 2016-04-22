using BienvenidosUY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Views
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (!Page.IsPostBack)
                {
                    //CARGAMOS EL PERFIL
                    cargarPerfil();
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }

        //CARGAR PERFIL 
        private void cargarPerfil()
        {
            Registrado reg = new Registrado();
            reg.mail = Session["mail"].ToString();
            bool existe = reg.Leer();

            string ruta = Server.MapPath("~/imagenes/perfil/");
            string rutarelativa = "/imagenes/perfil/";
            string nombrefoto = rutarelativa + reg.foto;

            //Cargamos el form con los datos del usuario
            this.ProfileNombre.Text = reg.nombre;
            this.ProfileApellido.Text = reg.apellido;
            this.ProfileMail.Text = reg.mail;
            this.ProfileDireccion.Text = reg.direccion;
            this.ProfileCelular.Text = reg.celular;
            this.PerfilImagen.ImageUrl = nombrefoto;
            this.ProfileDescripcion.Text = reg.descripcion;
            //this.ProfileName.Text = ;
        }

        //BTN ACTUALIZAR PERFIL
        protected void btnActualizarPerfil(object sender, EventArgs e)
        {

            //VALIDA LA PAGINA
            Page.Validate();

            if (Page.IsValid)
            {
                Registrado reg = new Registrado();
                reg.mail = Session["mail"].ToString();
                reg.Leer();

                string ruta = Server.MapPath("~/imagenes/perfil/");
                string nombrefoto = reg.mail + '-' + this.ProfileFoto.FileName.Replace(" ", "_");

                reg.id = Convert.ToInt32(Session["id"]);
                reg.mail = Session["mail"].ToString();
                reg.nombre = this.ProfileNombre.Text;
                reg.apellido = this.ProfileApellido.Text;
                reg.direccion = this.ProfileDireccion.Text;
                reg.foto = nombrefoto;
                reg.celular = this.ProfileCelular.Text;
                reg.descripcion = this.ProfileDescripcion.Text;

                //Falta la logica de MODIFICAR
                bool modifico = reg.Modificar();

                if (modifico)//si modifico
                {
                    //Guarda la foto en el servidor
                    if (this.ProfileFoto.HasFile)
                    {
                        // Se separa la extensión del nombre del archivo para validarla
                        string[] nomExt = this.ProfileFoto.FileName.Split('.');
                        string tipoFile = nomExt[nomExt.Length - 1].ToLower();
                        //Revisamos si el archivo cuenta con una extension valida, pudiendo agregar o quitar.
                        if ((tipoFile == "jpg") || (tipoFile == "png"))
                        {
                            this.ProfileFoto.SaveAs(Server.MapPath("~/imagenes/perfil/") + nombrefoto);
                        }
                    }
                    else
                    {
                        //Si pudo guardar el usuario
                        this.errorField.Visible = true;
                        this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar guardar la imagen</span></div>";
                    }

                    //Se pudieron modificar los datos
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Los datos se modificaron correctamente.</span></div>";
                }
                else
                {
                    //No se modificaron los datos
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Ocurrio un error al intentar actualizar, intentelo mas tarde.</span></div>";
                }
                //modifique o no modifique cargamos el perfil igual
                cargarPerfil();

            }
        }
    }
}