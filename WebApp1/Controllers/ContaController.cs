using BusinessLogicalLayer;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContaController : BaseController
    {
        // GET: Conta
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ContaParceiro()
        {
            string cookieValue = WebApp.Models.Cookie.Get("BudgShopTicket");
            string[] dados = cookieValue.Split(',');
            int id = int.Parse(dados[0]);
            string tipo = dados[1];
            if (tipo == "2")
            {
                //se for Usuario, redireciona
                return new RedirectResult(Url.Action("Login", "Usuario"));
            }
            else
            {
                //se for usuario, retorna view
                SetorDAL dal = new SetorDAL();
                SqlWhereSetor where = new SqlWhereSetor();
                SqlCommand command = where.XmlCod(id);
                List<string> setores = dal.SelectSetores(command);
                ViewBag.setores = setores;
                return View();
            }
        }
        public ActionResult ContaUsuario()
        {
            string cookieValue = WebApp.Models.Cookie.Get("BudgShopTicket");
            string[] dados = cookieValue.Split(',');
            int id = int.Parse(dados[0]);
            string tipo = dados[1];
            if (tipo == "1")
            {
                //se for supermercado, redireciona
                return new RedirectResult(Url.Action("Login", "Usuario"));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ContaUsuario(Usuario user)
        {
            UsuarioBLL atualizarUsuario = new UsuarioBLL();
            string[] array = WebApp.Models.Cookie.Get("BudgShopTicket").Split(',');
            user.ID = Convert.ToInt32(array[0]);
            ViewBag.message = atualizarUsuario.atualizaUsuario(user);

            return View();
        }

        [HttpPost]
        public ActionResult ContaParceiro(HttpPostedFileBase uploadFile, Supermercado supermercado,string xmlsetor,string arraybyte, string setores, string Produtosetores, string NomeDoSetor,
            string ProdutoNome, string ProdutoPreco, string ProdutoQuantidade, string ProdutoPeso, string ProdutoImagem, string ProdutoPromocao, string ProdutoDataDeInicio, string ProdutoDataDeTermino)
        {

            SqlWhereSetor where = new SqlWhereSetor();
            SetorDAL dal = new SetorDAL();
            SupermercadoBLL supermercadoBLL = new SupermercadoBLL();
            string[] array = WebApp.Models.Cookie.Get("BudgShopTicket").Split(',');
            supermercado.ID = Convert.ToInt32(array[0]);

            //Se Post é para importação do xml
            try
            {
                if (!string.IsNullOrWhiteSpace(uploadFile.FileName))
                {
                    try
                    {
                        var xmlPath = Server.MapPath("~/Content" + uploadFile.FileName);
                        uploadFile.SaveAs(xmlPath);
                        XSDProduto xsd = new XSDProduto();
                        Boolean valido = xsd.validaXML(xmlPath);
                        if (valido)
                        {
                            Setor setorxsd = new Setor();
                            setorxsd.CodigoMercado = supermercado.ID;
                            setorxsd.Nome = xmlsetor;
                            XDocument rootNode = XDocument.Load(xmlPath);
                            List<Produto> nodes = rootNode.Descendants("Produto").
                                Select(p => new Produto
                                {
                                    Nome = p.Element("Nome").Value,
                                    Preco = Convert.ToDouble(p.Element("Preco").Value),
                                    Quantidade = Convert.ToInt32(p.Element("Quantidade").Value),
                                    Peso = Convert.ToDouble(p.Element("Peso").Value),
                                    Imagem = p.Element("Imagem").Value,
                                    Promocao = Convert.ToDouble(p.Element("Promocao").Value),
                                    importancia = 0,
                                    Acessos = 0,
                                    DataDeInicio = Convert.ToDateTime(p.Element("DataDeInicio").Value),
                                    DataDeTermino = Convert.ToDateTime(p.Element("DataDeTermino").Value)
                                }).ToList();
                            setorxsd.Produto = nodes;
                            dal.InsertXML(setorxsd);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {
                
            }
            
            //Se Post é para inserir produto
            if(!string.IsNullOrWhiteSpace(ProdutoNome)&& !string.IsNullOrWhiteSpace(ProdutoPreco))
            {
                try
                {
                    List<Produto> listaparainserir = new List<Produto>();
                    Produto produto = new Produto();
                    produto.Nome = ProdutoNome;
                    produto.Preco = Convert.ToDouble(ProdutoPreco);
                    produto.Quantidade = Convert.ToInt32(ProdutoQuantidade);
                    produto.Peso = Convert.ToDouble(ProdutoPeso);
                    produto.Imagem = ProdutoImagem;
                    produto.Promocao = Convert.ToDouble(ProdutoPromocao);
                    produto.DataDeInicio = Convert.ToDateTime(ProdutoDataDeInicio);
                    produto.DataDeTermino = Convert.ToDateTime(ProdutoDataDeTermino);
                    produto.Acessos = 0;
                    produto.importancia = 0;
                    SqlCommand command = where.XmlCodAndSetor(supermercado.ID, Produtosetores);
                    List<Produto> prod = dal.SelectXML(command);
                    try
                    {
                        if (prod.Count > 0)
                        {
                            listaparainserir.AddRange(prod);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        listaparainserir.Add(produto);
                    }
                    catch (Exception)
                    {
                    }
                    Setor setorxml = new Setor();
                    setorxml.CodigoMercado = supermercado.ID;
                    setorxml.Nome = Produtosetores;
                    setorxml.Produto = listaparainserir;
                    setorxml.ID = 0;
                    SqlCommand comando = new SqlCommand();
                    dal.DeleteXMLRow(setorxml, comando);
                    dal.InsertXML(setorxml);
                }
                catch (Exception)
                {
                    ViewBag.ErroInsertProduto = "Erro no cadastro";
                }


                try
                {
                    supermercado.Logo = arraybyte.Split(',')[1];
                }
                catch (Exception)
                {

                }
            }
            //Se post for para atualizar o supermercado
            if (string.IsNullOrWhiteSpace(supermercado.CNPJ))
            {
                ViewBag.message = supermercadoBLL.atualizaSupermercado(supermercado);
            }
            //Se post for para inserir setor
            if (!string.IsNullOrWhiteSpace(NomeDoSetor))
            {
                List<Produto> listavazia = new List<Produto>();
                Setor setor = new Setor();
                setor.Nome = NomeDoSetor;
                setor.CodigoMercado = supermercado.ID;
                setor.Produto = listavazia;
                try
                {
                    dal.InsertXML(setor);
                }
                catch (Exception)
                {
                    ViewBag.InsertSetor = "Erro no cadastro";
                }
            }
            List<Produto> produtos = new List<Produto>();
            try
            {
                SqlCommand comando = where.XmlCod(supermercado.ID);
                List<string> listasetores = dal.SelectSetores(comando);
                SqlCommand command = where.XmlCodAndSetor(supermercado.ID, setores);
                produtos = dal.SelectXML(command);
                ViewBag.setores = listasetores;
            }
            catch (Exception)
            {
            }
            if (!string.IsNullOrWhiteSpace(setores))
            {
                SqlCommand cmd = where.XmlCodAndSetor(supermercado.ID, setores);
                  produtos = dal.SelectXML(cmd);
                
            }
            ViewBag.SetorSelecionado = setores;
            return View(produtos);
        }
    }
}