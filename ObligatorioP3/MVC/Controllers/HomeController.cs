using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if ((bool)Session["logueado"]) //Si esta logeado
            {
                //ViewBag.Logeado = true;
                //ViewBag.Mail = Session["mail"].ToString();
            }
            else //Si no esta logeado
            {
                
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["logueado"] = false;
            Session["mail"] = "";

            return View("Index");
        }


    }
}