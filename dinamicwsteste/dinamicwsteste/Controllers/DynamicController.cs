using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dinamicwsteste.Controllers
{
    public class DynamicController : Controller
    {
        // GET: Dynamic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Teste()
        {
            return View();
        }
    }
}