using BienvenidosUY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Views
{
    public partial class registro2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es PostBack
            if(IsPostBack){
                
            }
            else {
               
            }
        }

        //BTN REGISTRO DE USUARIOS
        protected void btnRegistroUsuario(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {

                bool esUsuario = false;
                
                //VALIDA QUE LA PERSONA QUE SE ESTA REGISTRANDO NO ESTE LOGEADA YA
                Registrado reg = new Registrado();
                reg.mail = this.UsuarioMail.Text;
                //LEE USUARIO
                esUsuario = reg.Leer();

                if (esUsuario)//SI YA ES USUARIO
                {
                    //Usuario inexistente
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Ya existe un usuario con ese mail.</span></div>";
                }
                else//SI NO ES USUARIO LO CREA
                {
                    //variables
                    bool afectadas;

                    //Crea un nuevo objeto Registrado y le carga los campos del formulario
                    //Registrado reg = new Registrado();
                    reg.nombre = this.UsuarioNombre.Text;
                    reg.apellido = this.UsuarioApellido.Text;
                    reg.mail = this.UsuarioMail.Text;
                    reg.password = this.UsuarioPassword.Text;
                    reg.celular = this.UsuarioCelular.Text;
                    reg.foto = this.UsuarioFoto.FileContent;
                    reg.descripcion = this.UsuarioDescripcion.Text;
                    reg.direccion = this.UsuarioDireccion.Text;

                    //Carga en afectadas el retorno de Guardar();
                    afectadas = reg.Guardar();

                    if (afectadas) {
                        //Usuario inexistente
                        this.errorField.Visible = true;
                        this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El registro se completo con exito.</span></div>";

                        //LIMPIAR EL FORMULARIO
                        UsuarioNombre.Text="";
                        UsuarioApellido.Text = "";
                        UsuarioMail.Text = "";
                        UsuarioPassword.Text = "";
                        UsuarioPassword.Text = "";
                        UsuarioCelular.Text = "";
                        //UsuarioFoto.FileContent = null;
                        UsuarioDescripcion.Text = "";
                        UsuarioDireccion.Text = "";
                        UsuarioNombre.Text = "";
                        UsuarioNombre.Text = "";
                        UsuarioNombre.Text = "";
                    }
                }
            }
        }
    }
}