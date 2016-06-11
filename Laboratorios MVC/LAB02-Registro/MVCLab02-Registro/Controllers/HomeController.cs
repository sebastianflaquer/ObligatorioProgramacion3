using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLab02_Registro.Models;

namespace MVCLab02_Registro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Home/
        [HttpPost]
        public ActionResult Index(Usuario u)
        {
            if (ModelState.IsValid)
                return (RedirectToAction("RegistroOk", u));
            else
                return View(u);
        }

        public ActionResult RegistroOk(Usuario usr)
        {
            @ViewBag.Mensaje = "Gracias por registrarse " + usr.Nombre + " su email es: " + usr.Email;
            return View();

        }


    }
}