using EntreLibros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntreLibros.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            return View();
        }

        // GET: Libros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            return View(new EntreLibros.ViewModels.LibroViewModel());
        }


        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(EntreLibros.ViewModels.LibroViewModel libroVM)
        {
            try
            {
                // 
                if (libroVM.Mapear())
                {
                    Libro libro = libroVM.UnLibro;
                    if (libro != null)
                    {
                        EntreLibrosContext db = new EntreLibrosContext();
                        db.Libros.Add(libro);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(libroVM);
            }
            catch
            {
                return View();
            }
        }


        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
