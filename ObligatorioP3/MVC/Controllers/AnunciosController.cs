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
        public ActionResult BuscarAnuncio(string SearchCiudad, string SearchBarrio, string SearchFechaI, string SearchFechaF)
        {

            //CARGA LOS FILTROS
            ViewBag.CategoriaList = new SelectList(db.Categorias, "Id", "Nombre");
            ViewBag.ServiciosList = new SelectList(db.Servicios, "Id", "Nombre");
            //ViewBag.CategoriaList = new SelectList(db.Categorias, "Id", "Nombre");

            var anuncios = from m in db.Anuncios select m;

            if (!String.IsNullOrEmpty(SearchCiudad))
            {
                anuncios = anuncios.Where(s => s.Alojamiento.Ciudad.Nombre.Contains(SearchCiudad));                
            }
            if (!String.IsNullOrEmpty(SearchBarrio))
            {
                anuncios = anuncios.Where(s => s.Alojamiento.Barrio.Contains(SearchBarrio));
            }
            if(!String.IsNullOrEmpty(SearchFechaI) && !String.IsNullOrEmpty(SearchFechaF))
            {
                //traer los anuncios que esten entre esas fechas
                anuncios = Anuncio.traerAnunciosXFecha(anuncios, Convert.ToDateTime(SearchFechaI), Convert.ToDateTime(SearchFechaF));
            }


            //FILTROS
            //if()
            //{

            //}





            return View(anuncios.ToList());
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
