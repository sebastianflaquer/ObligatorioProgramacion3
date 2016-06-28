using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Web.Security;

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
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Mail,Password,Salt,Direccion,Celular,Foto,Descripcion,Archivo")] Registrado registrado)
        {
            if (ModelState.IsValid)
            {
                
                //Busca si hay un usuaurio con ese mail
                var reg = db.Registrados.Where(c => c.Mail == registrado.Mail).FirstOrDefault();

                //si existe un usuario con ese mail
                if(reg != null){
                    ModelState.AddModelError("", "Ya existe un usuario con ese mail");
                }
                //si NO existe un usuario con ese mail
                else
                {
                    registrado.Salt = registrado.generarSalPass();
                    registrado.Password = Registrado.EncriptarPass(registrado.Password, registrado.Salt, Registrado.getPimienta());

                    if (registrado.Mapear())
                    {
                        //valida el registro
                        db.Registrados.Add(registrado);
                        db.SaveChanges();
                        return RedirectToAction("../Home/Index");
                    }
                }
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

        // GET: Registrado/Login        
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost, ActionName("Login")]
        public ActionResult Login(string InputMail, string InputPass)
        {
            if (ModelState.IsValid)
            {
                //Busca si existe un objeto con ese mail y ese password
                var reg = db.Registrados.Where(c => c.Mail == InputMail).FirstOrDefault();
                
                //Si el Loggeo es correcto
                if (reg != null)
                {
                    if (reg.Password == Registrado.EncriptarPass(InputPass, reg.Salt, Registrado.getPimienta()))
                    {
                        //Le agrega los datos a la Session
                        Session["logueado"] = true;
                        Session["mail"] = reg.Mail;
                        Session["id"] = reg.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Contraseña Incorrecta");
                        return View();
                    }
                    
                }
                //Si el Loggeo es incorrecto
                else
                {
                    ModelState.AddModelError("", "Mail o contraseña Incorrectos");
                    return View();
                }
            }
            return View(User);
        }

        private bool IsValid(string email, string password)
        {

            return true;
        }
    }
}
