using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BienvenidosUY;

namespace Web.Views
{
    public partial class crear_alojamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es PostBack
            if (IsPostBack)
            {

            }
            else {
                CargarFormularioAlojamiento();
            }
        }


        protected void CargarFormularioAlojamiento(){

            Categoria Cat = new Categoria();
            List<Categoria> L1 = new List<Categoria>();
            L1 = Cat.CargarCategorias();

            CategoriaDropD.Items.Add("Item 1");
            CategoriaDropD.Items.Add("Item 2");
            CategoriaDropD.Items.Add("Item 3");
            CategoriaDropD.Items.Add("Item 4");
            CategoriaDropD.Items.Add("Item 5");
            CategoriaDropD.Items.Add("Item 6");
            CategoriaDropD.Items.Add("Item 7");
            CategoriaDropD.Items.Add("Item 8");
        }

        


        protected void AgregarServicio_Click(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {
                //variables
                bool afectadas;

                //Crea un nuevo objeto Servicio y le carga los campos del formulario
                Servicio serv = new Servicio();
                serv.nombre = this.NomServicio.Text;
                serv.descripcion = this.DscServicio.Text;

                //Carga en afectadas el retorno de Guardar();
                afectadas = serv.Guardar();
                if (afectadas)
                {
                    //LIMPIAR EL FORMULARIO
                    //Categoria.Text = "";
                    TipoHabitacion.Text = "";
                    BanioP.Checked = false;
                    CantHuespedes.Text = "";
                    CiudadAloj.Text = "";
                    BarrioAloj.Text = "";
                    NomServicio.Text = "";
                    DscServicio.Text = "";
                }
                }



            }
    }
}