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
                //validar aca que el mail no se repita
            }

            bool ok = false;

            Registrado reg = new Registrado();
            reg.nombre = this.UsuarioNombre.Text;
            reg.apellido = this.UsuarioApellido.Text;
            reg.mail = this.UsuarioApellido.Text;
            reg.password = this.UsuarioPassword.Text;
            reg.celular = this.UsuarioCelular.Text;
            reg.descripcion = this.UsuarioDescripcion.Text;
            reg.direccion = this.UsuarioDireccion.Text;

            ok = reg.Guardar();
        }





    }
}