
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Teste()
        {
            return View();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        //Retorna a View de cadastro de cliente
        //GET
        public ActionResult Cadastrar()
        {
            return View();
        }

        //Só é executado quando o botão da View for clicado
        [HttpPost]
        public ActionResult Cadastrar(ClienteViewModel viewModel)
        {
            return View();
        }
    }
}