using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AnunciosController : Controller
    {
        private BienvenidosUyContext db = new BienvenidosUyContext();

        // GET: Anuncios
        public ActionResult Index()
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                return View(db.Anuncios.ToList());
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Anuncio anuncio = db.Anuncios.Find(id);
                if (anuncio == null)
                {
                    return HttpNotFound();
                }
                return View(anuncio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                return View();
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Anuncios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Direccion1,Direccion2,Fotos,PrecioBase")] Anuncio anuncio)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (ModelState.IsValid)
                {
                    db.Anuncios.Add(anuncio);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(anuncio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Anuncio anuncio = db.Anuncios.Find(id);
                if (anuncio == null)
                {
                    return HttpNotFound();
                }
                return View(anuncio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Anuncios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Direccion1,Direccion2,Fotos,PrecioBase")] Anuncio anuncio)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (ModelState.IsValid)
                {
                    db.Entry(anuncio).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(anuncio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Anuncio anuncio = db.Anuncios.Find(id);
                if (anuncio == null)
                {
                    return HttpNotFound();
                }
                return View(anuncio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                Anuncio anuncio = db.Anuncios.Find(id);
                db.Anuncios.Remove(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        //DISPOSE
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //CODIGO NUESTRO
        // GET: Reservas/SearchIndex/
        public ActionResult BuscarAnuncio(string searchString, string SearchCiudad, string SearchBarrio, string SearchFechaI, string SearchFechaFin)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                var anuncios = from m in db.Anuncios select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    anuncios = anuncios.Where(s => s.Nombre.Contains(searchString));
                    anuncios = anuncios.Where(s => s.Nombre.Contains(SearchCiudad));
                    anuncios = anuncios.Where(s => s.Nombre.Contains(SearchBarrio));
                    //anuncios = anuncios.buscarFechas(anuncios);
                    //falta lo de las fechas
                    //Anuncio anuncio = db.Anuncios.Find(id);

                    //var query = (from a in db.Anuncios
                    //             where a.RangosFechas.FechaInicio == SearchFechaI)


                }
                return View(anuncios.ToList());
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }



        //RESERVAR
        public ActionResult Reservar(int idAnuncio)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                Anuncio anuncio = db.Anuncios.Find(idAnuncio);
                if (anuncio == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Create", "ReservasController", new { id = anuncio.Id });
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

    }
}
