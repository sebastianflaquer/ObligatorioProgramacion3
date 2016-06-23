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
    public class ReservasController : Controller
    {
        private BienvenidosUyContext db = new BienvenidosUyContext();

        // GET: Reservas
        public ActionResult Index()
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                ViewBag.Logeado = true;
                ViewBag.Mail = Session["mail"].ToString();
                
                string idsesion = Session["mail"].ToString();
                var res = db.Reservas.Where(r => r.Registrado.Mail == idsesion).ToList();

                return View(res.ToList());               

            }
            else //Si no esta logeado
            {
                return RedirectToAction("Registrado/Login");
            }
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "Id,FechaInicio,FechaFin,CantHuespedes,TextoConsultas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Anuncio anuncio = db.Anuncios.Find(id);
                //si no encuentra el anuncio tira error
                if (anuncio == null)
                {
                    return HttpNotFound();
                }
                reserva.Anuncio = anuncio;
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaInicio,FechaFin,CantHuespedes,TextoConsultas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Reservas/Cancel/5
        public ActionResult CancelarReserva(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            if (reserva.ValidarFechaParaCancelar() == true)
            {
                db.Reservas.Remove(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Reservas/Cancel/5
        [HttpPost, ActionName("CancelarReserva")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

        public ActionResult BuscarAnuncio(string searchString, string SearchCiudad, string SearchBarrio, string SearchFechaI, string SearchFechaF)
        {
            var anuncios = from m in db.Anuncios select m;

            var ciudad = SearchCiudad;
            var barrio = SearchBarrio;
            var fechaI = SearchFechaI;
            var fechaF = SearchFechaF;

            if (!String.IsNullOrEmpty(searchString))
            {
                anuncios = anuncios.Where(s => s.Nombre.Contains(searchString));
            }

            return View(anuncios.ToList());
        }






        //CALIFICACION DE RESERVAS
        public ActionResult CalificarReserva(int id)
        {
            using (var db = new BienvenidosUyContext())
            {                
                ViewBag.Reserva = db.Reservas.Find(id);
                if (ViewBag.Reserva.ValidarFechaParaCalificar())
                {
                    return View();
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult CalificarReserva(Calificacion newCalificacion)
        {
            try
            {
                //obtenemos el id de la Reserva Comentada
                var ReservaId = int.Parse(Request["ReservaID"]);

                using (var db = new BienvenidosUyContext())
                {
                    //buscamos la Reserva y le agregamos la calificacion al alojamiento
                    Reserva res = db.Reservas.Find(ReservaId);
                    newCalificacion.Alojamiento = res.Anuncio.Alojamiento;
                    db.Calificaciones.Add(newCalificacion);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DetalleComentarios(int id)
        {
            List<Calificacion> listaCalif = new List<Calificacion>();
            Reserva res = db.Reservas.Find(id);
            int idAloj = res.Anuncio.Alojamiento.Id;

            foreach (Calificacion c in db.Calificaciones)
            {
                if (c.Alojamiento.Id == idAloj)
                {
                    listaCalif.Add(c);
                }
            }
            return View(listaCalif.ToList());
        }



    }
}
