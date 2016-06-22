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
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Mail,Password,Salt,Direccion,Celular,Foto,Descripcion")] Registrado registrado)
        {
            if (ModelState.IsValid)
            {

                //1 - Valida si ese mail ya no esta registrado, (si ya esta tira error)
                //2 - Si no esta registrado, hay que validar que las contraseñas sean igual (password y confirmacion)
                //3 - Hacer toda la parte de encriptacion de contraseña
                //4 - Registrar al usuario
                //5 - Mostrar mensaje de que quedo registrado, redireccional al login

                //Lisatamos todos los registrados
                var reg = db.Registrados.Where(c => c.Mail == registrado.Mail ).FirstOrDefault();
                
                //var reg = db.Registrados.ToList();
                //guardamos en la consulta el usuario que tiene ese mail
                //var query = from unreg in reg
                            //where unreg.Mail == registrado.Mail
                            //select unreg.Mail;

                //var existe = query.ToList();

                //Si es diferente a null, muestra mensaje ya esta registrado
                if (reg != null)
                {
                    ModelState.AddModelError("", "Ya existe un usuario con ese mail");
                }
                //si es nullo crea el registro
                else {
                    string pimienta = "p1m13n7a";
                    registrado.Salt = registrado.generarSalPass();
                    registrado.Password = registrado.EncriptarPass(registrado.Password, registrado.Salt, pimienta);

                    //valida el registro
                    db.Registrados.Add(registrado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
                //    //1 - Buscar el usuario
                //    //2 - chekear que el paswors esta ok
                //    //3 - redireccionar el home y logearlo
                // var reg = db.Registrados.ToList();
                //funcion hasheado pass
                //guardamos en la consulta el usuario que tiene ese mail

                var registrado = db.Registrados.Where(c => c.Mail == InputMail && c.Password == InputPass).FirstOrDefault();
                if(registrado != null)//Loggeo correcto
                {

                }else
                {//incorrecto+

                }
                
                //wRegistrado User = db.Registrados.Find(query);

                //if (true)
                //{
                //    //Le agrega los datos a la Session
                //    Session["logueado"] = true;
                //    Session["mail"] = User.Mail;
                //    Session["id"] = User.Id;
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    //Usuario inexistente o contraseña incorrecta
                //    ModelState.AddModelError("", "Mail o contraseña Incorrectos");
                //}



                //
                //if (IsValid(userr.Mail, userr.Password))
                //{
                //    FormsAuthentication.SetAuthCookie(userr.Mail, false);
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Login details are wrong.");
                //}
            }
            return View(User);
        }

        private bool IsValid(string email, string password)
        {

            return true;
        }
    }
}
