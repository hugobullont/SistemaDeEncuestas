using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestasWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Encuestas UPC";

            return View();
        }
        public ActionResult Analista()
        {
            return View();
        }

        public ActionResult Administrador()
        {
            return View();
        }

        public ActionResult Docente()
        {
            return View();
        }

        public ActionResult Alumno()
        {
            return View();
        }

        public ActionResult Administrativo()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}