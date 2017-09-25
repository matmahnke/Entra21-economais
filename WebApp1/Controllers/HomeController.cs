using BusinessLogicalLayer;
using DataAccessLayer;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SupermercadoBLL supermercado = new SupermercadoBLL();
            List<Supermercado> lista = supermercado.selecionaTodosSupermercado();
            return View(lista);
        }

        public ActionResult About()
        {
            Cookie.Delete("BudgShopTicket");
            ViewBag.Message = "Your application description page.";
               
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}