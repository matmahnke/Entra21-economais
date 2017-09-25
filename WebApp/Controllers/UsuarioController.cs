using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult PainelControle()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }
    }
}