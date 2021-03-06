﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class baja_alojamiento : System.Web.UI.Page
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
                    CargarAlojamientosDeUsuario();
                }
            }
            else //Si no esta logeado lo redirecciona al login
            {
                Response.Redirect("../Views/sign-up.aspx");
            }
        }

        //CARGA LOS ALOJAMIENTOS DEL USUARIO
        protected void CargarAlojamientosDeUsuario()
        {
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            if (L1.Count == 0)//si no tiene items en la lista
            {
                this.listaSinAnuncios.Visible = true;
                this.formEliminarAlojamiento.Visible = false;
                this.listaSinAnuncios.InnerHtml = "<div class='col-md-12'><h1>Upss!!!</h1><h3>No tienes alojamientos para eliminar</h3><br /><a class='btn btn-warning' href='home.aspx'>Volver al home</a></div>";
            }
            else//si tiene items en la lista
            {
                this.DropDElegirAlojamiento.DataSource = L1;
                this.DropDElegirAlojamiento.DataValueField = "id";
                this.DropDElegirAlojamiento.DataTextField = "nombre";
                this.DropDElegirAlojamiento.DataBind();
            }
        }

        //ELIMINA EL ALOJAMIENTO SELECIONADO
        protected void ConfBajaAlojamiento_Click(object sender, EventArgs e)
        {
            Alojamiento alo = new Alojamiento();
            alo.id = int.Parse(this.DropDElegirAlojamiento.SelectedValue);
            alo.Leer();
            bool ok = alo.Eliminar();  //IMPLEMENTAR
            if (ok)
            {
                //Si pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El Alojamiento fue eliminado</span></div>";

                //carga otra vez el combo con los alojamientos
                CargarAlojamientosDeUsuario();
            }
            else
            {
                //NO pudo Eliminar el Anuncio
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar eliminar el Alojamiento</span></div>";
            }

            CargarAlojamientosDeUsuario();

        }
    }
}