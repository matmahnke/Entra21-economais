using BudgShopAPP;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            List<Produto> lista = new List<Produto>();
            ProdutosBLL bll = new ProdutosBLL();
            lista = bll.BuscarTudo();
            lista = lista.OrderBy(o => o.Nome).ToList();
            lista = lista.Distinct(new BudgShopAPP.ProdutosBLL.ProdutosComparer()).ToList();
            return View(lista);
        }

        [HttpPost]
        public ActionResult Buscar(string busca)
        {
            List<Produto> lista = new List<Produto>();
            ProdutosBLL bll = new ProdutosBLL();
            lista = bll.Buscar(busca);
            lista = lista.OrderBy(o => o.Nome).ToList();
            lista = lista.Distinct(new ProdutosBLL.ProdutosComparer()).ToList();
            return View(lista);
        }

        public ActionResult Buscar()
        {
            return RedirectToAction("Index");
        }
    }
}