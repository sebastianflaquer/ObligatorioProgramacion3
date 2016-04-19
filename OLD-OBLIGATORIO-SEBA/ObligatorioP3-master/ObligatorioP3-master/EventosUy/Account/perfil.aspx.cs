using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_perfil_empresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Boolean)Session["logueado"]) //Si esta logeado
            {
                cargarPerfil();
            }
            else
            {
                Response.Redirect("../Account/Login"); //Si no esta logeado
            }
        }
    }

    private void cargarPerfil()
    {
        if (Convert.ToInt32(Session["idRol"]) == 1)//Admin
        {
            UsuarioEventosUY unUEuy = UsuarioEventosUY.CargarAdminMail(Session["email"].ToString());
            this.AdminNombre.Text = unUEuy.Nombre;
            this.AdminHola.Text = unUEuy.Apellido;
            this.AdminEmail.Text = unUEuy.Email;
            this.AdminTelefono.Text = unUEuy.Telefono;
            this.AdminNroFuncionario.Text = unUEuy.NroFuncionario.ToString();
            this.AdminCargo.Text = unUEuy.Cargo;
            this.adminPerfil.Visible = true;
        }
        else if(Convert.ToInt32(Session["idRol"]) == 2)//Empresa
        {
            Empresa unaEmp = Empresa.cargarEmpresaMail(Session["email"].ToString());
            this.empresaNombre.Text = unaEmp.Nombre;
            this.empresaTelefono.Text = unaEmp.Telefono;
            this.empresaMailPrincipal.Text = unaEmp.MailPublico;
            this.empresaMailsExtras.Text = unaEmp.MailsAdicionales;
            this.empresaURL.Text = unaEmp.Url;
            this.empresaPerfil.Visible = true;
        }
        else{
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }
    }
    protected void btnActualizarDatosEmp(object sender, EventArgs e)
    {
        int afectadas = Empresa.actualizarDatos(
          this.empresaNombre.Text,
          this.empresaTelefono.Text,
          this.empresaMailsExtras.Text,
          this.empresaURL.Text,
          this.Session["email"].ToString()
        );

        if (afectadas == -1){
            this.errorField.Visible = true;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Datos Actualizados</span></div>";
        }else{
            this.errorField.Visible = true;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-worning'><button data-dismiss='alert' class='close' type='button'>×</button><span>No se pudo actualizar los datos</span></div>";
        }
        cargarPerfil();
    }

    protected void btnActualizarDatosAdmin(object sender, EventArgs e)
    {
        //UsuarioEventosUY.actualizarDatos(
        //    AdminNombre.Text,
        //    AdminHola.Text,
        //    AdminEmail.Text,
        //    AdminNroFuncionario.Text,
        //    AdminCargo.Text,
        //    Session["email"].ToString()
        //)
    }

    protected void btnEliminarCuenta(object sender, EventArgs e)
    {
        Empresa unaEmp = Empresa.cargarEmpresaMail(Session["email"].ToString());
        bool borro = Empresa.borrarEmpresa(unaEmp.idEmpresa,unaEmp.idUsuario);
        if (borro)
        {
            Session["logueado"] = false;
            Session["email"] = "";
            Session["idRol"] = -1;
            Response.Redirect("/");
        }
        else {
            this.errorField.Visible = true;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>No se pudo eliminar</span></div>";
        }
        cargarPerfil();

    }
    

}