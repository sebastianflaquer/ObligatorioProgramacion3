using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntreLibros.Models;
using System.Web.Mvc;
using System.Web;

namespace EntreLibros.ViewModels
{
    public class LibroViewModel
    {
        public Libro UnLibro { get; set; }
        public SelectList TodosLosTemas { get; set; }
        public MultiSelectList TodosLosAutores { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public int IdTemaSeleccionado { get; set; }
        public int[] IdsAutoresSeleccionados { get; set; }
        public LibroViewModel()
        {
            this.UnLibro = new Libro();
            cargarTemas();
            cargarAutores();
        }




        private void cargarTemas()
        {
            EntreLibrosContext db = new EntreLibrosContext();
            this.TodosLosTemas = new SelectList(db.Temas, "Id", "Nombre");
        }

        private void cargarAutores()
        {
            EntreLibrosContext db = new EntreLibrosContext();
            this.TodosLosAutores = new MultiSelectList(db.Autores, "Id", "Nombre");
        }


        public bool Mapear()
        {
            if (this.Archivo != null)
            {
                if (guardarArchivo(Archivo))
                {
                    this.UnLibro.NombreArchivoPortada = Archivo.FileName;

                    using (EntreLibrosContext db = new EntreLibrosContext())
                    {
                        this.UnLibro.MiTema = db.Temas.Find(this.IdTemaSeleccionado);

                        this.UnLibro.Autores = new List<Autor>();
                        foreach (int idAutor in this.IdsAutoresSeleccionados)
                        {
                            this.UnLibro.Autores.Add(db.Autores.Find(idAutor));
                        }
                    }
                    return true;
                }
            }
            return false;
        }




        private bool guardarArchivo(HttpPostedFileBase archivo)
        {
            if (archivo != null)
            {
                string ruta = System.IO.Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, "Images/fotos");
                if (!System.IO.Directory.Exists(ruta))
                    System.IO.Directory.CreateDirectory(ruta);

                ruta = System.IO.Path.Combine(ruta, archivo.FileName);
                archivo.SaveAs(ruta);
                return true;
            }
            else return false;
        }




    }
}
