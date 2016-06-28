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
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                //valida que la reserva sea de ese usuario
                Reserva reserva = db.Reservas.Find(id);
                int idRegistrado = (int)Session["id"];
                
                if (reserva == null || reserva.Registrado.Id != idRegistrado)
                {
                    return RedirectToAction("../Reservas");
                    //return HttpNotFound();
                }
                else
                {
                    return View(reserva);
                }
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }

        }

        // GET: Reservas/Create
        public ActionResult Create(int? id)
        {
            //Si esta logeado
            if ((bool)Session["logueado"])
            {
                //Si no hay ningun ID en la URL
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    //Busca todos los anuncios
                    Anuncio anuncio = db.Anuncios.Find(id);
                    //si no encuentra el anuncio tira error
                    if (anuncio == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "Id,FechaInicio,FechaFin,CantHuespedes,TextoConsultas")] Reserva reserva)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                //si todos los campos son validos
                if (ModelState.IsValid)
                {
                    //Si no hay ningun ID en la URL
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    //si hay un id
                    else
                    {
                        //Busca todos los anuncios
                        Anuncio anuncio = db.Anuncios.Find(id);
                        reserva.Anuncio = anuncio;

                        //si no encuentra el anuncio tira error
                        if (anuncio == null)
                        {
                            return HttpNotFound();
                        }
                        //si lo encuentra
                        else
                        {
                            //1 - Ver si el anuncio tiene esas fechas
                            decimal costo = reserva.anuncioTieneFechas(anuncio.RangosFechas, reserva);
                            //Si se puede reservar
                            if (costo != -1)
                            {
                                bool nodisponible = reserva.otraValidacion(anuncio.RangosFechas, reserva);

                                if(nodisponible)
                                {
                                    ModelState.AddModelError("", "Ya hay otra reserva en esta fecha o la cantidad de huespedes es mayor a la permitida");                                    
                                }
                                else
                                {
                                    //crea la reserva
                                    reserva.Registrado = db.Registrados.Find(Session["id"]);
                                    db.Reservas.Add(reserva);
                                    db.SaveChanges();
                                    return RedirectToAction("Index");
                                }
                                
                            }
                            else {
                                ModelState.AddModelError("", "Uno o mas dias dentro del rango de fechas no estan disponibles. Ingrese una nueva consulta");
                            }
                        }
                    }
                }

                return View(reserva);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
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
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaInicio,FechaFin,CantHuespedes,TextoConsultas")] Reserva reserva)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                if (ModelState.IsValid)
                {
                    db.Entry(reserva).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(reserva);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
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
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                Reserva reserva = db.Reservas.Find(id);
                db.Reservas.Remove(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
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
            if ((bool)Session["logueado"]) //Si esta logeado
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
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: Reservas/Cancel/5
        [HttpPost, ActionName("CancelarReserva")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(int id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                Reserva reserva = db.Reservas.Find(id);
                db.Reservas.Remove(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }


        //BUSCAR ANUNCIO
        //public ActionResult BuscarAnuncio(string searchString, string SearchCiudad, string SearchBarrio, string SearchFechaI, string SearchFechaF)
        //{
        //    if ((bool)Session["logueado"]) //Si esta logeado
        //    {
        //        var anuncios = from m in db.Anuncios select m;

        //        var ciudad = SearchCiudad;
        //        var barrio = SearchBarrio;
        //        var fechaI = SearchFechaI;
        //        var fechaF = SearchFechaF;

        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            anuncios = anuncios.Where(s => s.Nombre.Contains(searchString));
        //        }

        //        return View(anuncios.ToList());
        //    }
        //    else //Si no esta logeado
        //    {
        //        return RedirectToAction("../Registrado/Login");
        //    }
        //}

        //CALIFICACION DE RESERVAS
        public ActionResult CalificarReserva(int id)
        {
            if ((bool)Session["logueado"])    //Si esta logueado
            {
                using (var db = new BienvenidosUyContext())
                {
                    ViewBag.Reserva = db.Reservas.Find(id);
                    if (ViewBag.Reserva.ValidarFechaParaCalificar())
                    {
                        if (Reserva.ReservaYaCalificadaPorUsuario(ViewBag.Reserva, (int)Session["id"]) == false)
                        {
                            ModelState.AddModelError("", "La Reserva ya fue calificada por el usuario");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Aun no puede calificar esta Reserva");
                        return View();
                    }
                }
                ModelState.AddModelError("", "Calificacion exitosa");
                return View();//Acá también podrían redirigir a otra página donde se vea la calificación ingresada, etc.
            }
            else     //Si no esta logueado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // POST: 
        [HttpPost]
        public ActionResult CalificarReserva(Calificacion newCalificacion)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
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
                        Registrado reg = db.Registrados.Find(Session["id"]);
                        newCalificacion.Registrado = reg;
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
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }


        public ActionResult DetalleComentarios(int id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
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
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }


        public ActionResult ComentariosDeAlojamiento(int id)
        {
            if ((bool)Session["logueado"]) //Si esta logeado
            {
                //List<Calificacion> listaCalif = new List<Calificacion>();

                Alojamiento a = db.Alojamientos.Find(id);

                //foreach (Calificacion c in db.Calificaciones)
                //{
                //    if (c.Alojamiento.Id == id)
                //    {
                //        listaCalif.Add(c);
                //    }
                //}
                return View(a.Calificaciones.ToList());
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

    }
}
