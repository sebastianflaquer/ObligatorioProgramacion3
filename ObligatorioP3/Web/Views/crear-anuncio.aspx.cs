﻿using System;
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
            }
        }

        //CARGA LOS ALOJAMIENTOS DEPENDIENDO EL USUSARIO LOGUEADO
        protected void CargarAlojamientosDeUsuario()
        {

            #region alojamientos
            Alojamiento aloj = new Alojamiento();
            List<Alojamiento> L1 = new List<Alojamiento>();

            L1 = aloj.CargarAlojamientosPorUsuario(Session["mail"].ToString());

            //Recorre la lista de categorias y agrega al select
            for (int i = 0; i < L1.Count; i++)
            {
                ElejAlojDropD.Items.Add(L1[i].nombre);
            }
        }
            #endregion

        //CREAR ANUNCIO
        //protected void BtnCrearAnuncio(object sender, EventArgs e)
        //{
        //    //VALIDA LA PAGINA
        //    Page.Validate();

        //    //SI ES VALIDA EJECUTA LA FUNCION
        //    //if (Page.IsValid)
        //    //{
        //    //    //creo un objeto anuncio
        //    //    Anuncio anu = new Anuncio();

        //    //    //anu.nombre = ;
        //    //    //anu.alojamiento = ;
        //    //    //anu.descripcion = ;
        //    //    //anu.direccion1 = ;
        //    //    //anu.direccion2 = ;
        //    //    //anu.fotos = ;
        //    //    //anu.precioBase = ;
        //    //    //anu.rangosFechas = ;
        //    //    //anu.guardar();
        //    //}

        //CREAR Y AGREGAR RANGO FECHAS
        protected void CrearYagregarRango_Click(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {
                //variables
                bool afectadas;

                //Crea un nuevo objeto RangoFechas y le carga los campos del formulario
                RangoFechas rangoF = new RangoFechas();
                string txtDesde = this.fchaIniAnuncio.Text;
                string txtHasta = this.fchaFinAnuncio.Text;
                rangoF.fechaInicio = DateTime.Parse(txtDesde);
                rangoF.fechaFin = DateTime.Parse(txtHasta);
                rangoF.precio = decimal.Parse(this.PrecioRango.Text);

                //Carga en afectadas el retorno de Guardar();
                afectadas = rangoF.Guardar();
                if (afectadas)
                {
                    //LIMPIAR 
                    fchaIniAnuncio.Text = "";
                    fchaFinAnuncio.Text = "";
                    PrecioRango.Text = "";
                }
            }
        }


    }
}