using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class HolaController : Controller
    {
        // GET: Hola
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HolaMundo()
        {
            return View();
        }

    }
}