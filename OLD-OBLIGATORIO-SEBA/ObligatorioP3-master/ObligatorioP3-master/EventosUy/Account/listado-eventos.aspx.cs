using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_listado_eventos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Evento> EventosListados = new List<Evento>();

        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            if (Convert.ToInt32(Session["idRol"]) == 1) //Si es admin
            { 
                EventosListados = Empresa.listarEvento(-1);
                if (EventosListados.Count > 0)
                {
                    //EL GRID LLAMA A LISAT EVENTOS
                    this.gridListarEventos.DataSource = EventosListados;
                    //SE CARGAN LOS DATOS EN EL GRID
                    this.gridListarEventos.DataBind();
                }
                else
                {
                    //Mensaje no hay tantos
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Ohh Margot!  </strong><span>No hay eventos.</span></div>";
                }
            }
            else //Si es Empresa
            {
                Empresa unaEmpresa = Empresa.cargarEmpresaMail(Session["email"].ToString());
                EventosListados = Empresa.listarEvento(unaEmpresa.idEmpresa);
                if (EventosListados.Count > 0)
                {
                    //EL GRID LLAMA A LISAT EVENTOS
                    this.gridListarEventos.DataSource = EventosListados;
                    //SE CARGAN LOS DATOS EN EL GRID
                    this.gridListarEventos.DataBind();
                }
                else
                {
                    //Mensaje no hay tantos
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Ohh Margot!  </strong><span>No hay eventos.</span></div>";
                }
            }
        }
        else
        {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }

    }


    protected void gridListarEventos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<Evento> EventosListados = new List<Evento>();

        if (e.CommandName == "Eliminar")
        {
            GridViewRow fila = this.gridListarEventos.Rows[int.Parse(e.CommandArgument.ToString())];
            bool borro = false;
            string idEventoString = fila.Cells[0].Text; //TOMA EL TITULO DE LA CELLS
            int idEvento = Convert.ToInt32(idEventoString);
            borro = Evento.borrarEvento(idEvento); // LLAMA A BORRAR EVENTO

            if (borro) {
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El evento se elimino con exito.</span></div>";
            }

            if (Convert.ToInt32(Session["idRol"]) == 1)//Si es admin
            {
                EventosListados = Empresa.listarEvento(-1);//si es admin lo cargo con idEmpres -1 para que muestre todos los ventos y no filtre

                if (EventosListados != null)
                {
                    //EL GRID LLAMA A LISAT EVENTOS
                    this.gridListarEventos.DataSource = EventosListados;
                    //SE CARGAN LOS DATOS EN EL GRID
                    this.gridListarEventos.DataBind();
                }
                else
                {
                    //Mensaje no hay tantos
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Ohh Margot!  </strong><span>No hay eventos.</span></div>";
                }
            }
            else
            {
                //Si es Empresa
                Empresa unaEmpresa = Empresa.cargarEmpresaMail(Session["email"].ToString());
                //EL GRID LLAMA A LISAT EVENTOS
                this.gridListarEventos.DataSource = Empresa.listarEvento(unaEmpresa.idEmpresa);
                //SE CARGAN LOS DATOS EN EL GRID
                this.gridListarEventos.DataBind();
            }
        }
    }
}