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

        }


        protected void btnRegistroUsuario(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                bool esUsuario = false;
                
                //validar aca que el mail no se repita
                Registrado reg = new Registrado();
                reg.mail = this.UsuarioMail.Text;
                esUsuario = reg.Leer();

                if (esUsuario)//si ya es usuario
                {
                    //Usuario inexistente
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Ya existe un usuario con ese mail.</span></div>";
                }
                else//si no es usuario lo crea
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
                }
            }
        }
    }
}