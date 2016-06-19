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
    public class RegistradoController : Controller
    {
        private BienvenidosUyContext db = new BienvenidosUyContext();

        // GET: Registradoes
        public ActionResult Index()
        {
            return View(db.Registrados.ToList());
        }

        // GET: Registradoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrado registrado = db.Registrados.Find(id);
            if (registrado == null)
            {
                return HttpNotFound();
            }
            return View(registrado);
        }

        // GET: Registradoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registradoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Mail,Password,Salt,Direccion,Celular,Foto,Descripcion")] Registrado registrado)
        {
            if (ModelState.IsValid)
            {

                



                if (registrado.validarRegistro())
                {
                    db.Registrados.Add(registrado);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(registrado);
        }

        // GET: Registradoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrado registrado = db.Registrados.Find(id);
            if (registrado == null)
            {
                return HttpNotFound();
            }
            return View(registrado);
        }

        // POST: Registradoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Mail,Password,Salt,Direccion,Celular,Foto,Descripcion")] Registrado registrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrado);
        }

        // GET: Registradoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrado registrado = db.Registrados.Find(id);
            if (registrado == null)
            {
                return HttpNotFound();
            }
            return View(registrado);
        }

        // POST: Registradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registrado registrado = db.Registrados.Find(id);
            db.Registrados.Remove(registrado);
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
    }
}
