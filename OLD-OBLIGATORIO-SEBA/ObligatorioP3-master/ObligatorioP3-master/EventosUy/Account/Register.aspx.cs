using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using EventosUy;

public partial class Account_Register : Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            if (Convert.ToInt32(Session["idRol"]) == 2)//Si es un Administrador
            {
                Response.Redirect("../");//No puede registar una empresa
            }
            else {
                //Puede registrar una empresa
            } 
        }
        else //Si no esta logeado
        {
            //Puede registrar una empresa
        }
    }

    protected void btnAltaEmpresa(object sender, EventArgs e)
    {

        // FALTA - hay que validar primero la pagina
        //Page.Validate();

        //if(Page.IsValid)
        //{
        // //validar aca que el mail no se repita
        //}
        
        bool mailUnico = Empresa.ValidarMailUnico(EmpresaMailPublico.Text);

        if (mailUnico)
        {
            int afectadas = Empresa.GuardarEmpresa(
                EmpresaName.Text,
                EmpresaTelefono.Text,
                EmpresaMailPublico.Text,
                EmpresaMailAdicional.Text,
                EmpresaUrl.Text,
                EmpresaPassword.Text
            );
            if (afectadas == -1){
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Empresa registrada con Exito.</span></div>";
            }
        }
        else{
            this.errorField.Visible = true;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Ya existe una empresa con ese Mail Principal, debe utilizar otro.</span></div>";
            this.formMailPrincipal.Attributes.Add("class", "has-error");
        }
    }

}