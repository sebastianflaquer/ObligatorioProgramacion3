using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABMVC07_EvaluacionParametros.Controllers
{
    public class Parametros01Controller : Controller
    {
        // GET: Parametros01
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult evaluarParametro(int? cantidad)
        {
            if (cantidad != null)
                return View(cantidad);
            else
                return View(100);
        }


    }
}