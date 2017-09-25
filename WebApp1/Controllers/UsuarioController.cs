using BusinessLogicalLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string senha)
        {
            //string cookieValue = Cookie.Get("BudgShopTicket");
            //string[] dados = cookieValue.Split(',');
            //int id = int.Parse(dados[0]);
            //string tipo = dados[1];
            //if(tipo == "1")
            //{
            //
            //}
            //else
            //{
            //
            //}

            LoginBLL loginbll = new LoginBLL();
            try
            {
                dynamic objeto = loginbll.verificaLogin(username, senha);
                if (objeto.GetType() == typeof(Supermercado))
                {
                    Cookie.Set("BudgShopTicket", objeto.ID.ToString() + "," + "1");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Cookie.Set("BudgShopTicket", objeto.ID.ToString() + "," + "2");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                ViewBag.Erro = "Usuário e/ou senha inválidos";
            }

            return View();
        }

        public ActionResult PainelControle()
        {
            return View();
        }

        public ActionResult Deslogar()
        {
            string get = WebApp.Models.Cookie.Get("BudgShopTicket");
            if (!string.IsNullOrEmpty(get))
            {
                try
                {
                    string[] vetor = get.Split(',');
                    if (Convert.ToInt32(vetor[0]) > 0)
                    {
                        WebApp.Models.Cookie.Delete("BudgShopTicket");
                    }
                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registrar(Usuario user)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            ViewBag.Message = usuarioBLL.inseriUsuario(user);
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Supermercado supermercado, string NomeUser, string SobrenomeUser,
            string EmailUser, string LocalizacaoUser, string SenhaUser, string arraybyte)
        {
            try
            {
                supermercado.Logo = arraybyte.Split(',')[1];
            }
            catch (Exception)
            {
                
            }

            string login;
            string senha;
            //Base64Converter base64 = new Base64Converter();
            Usuario user = new Usuario();
            //byte[] array = (byte[])conversor.ConvertTo(file, typeof(byte[]));
            //MemoryStream memstr = new MemoryStream(array);
            //System.Drawing.Image img = System.Drawing.Image.FromStream(memstr);
            //base64.ImageToBase64();
            user.Nome = NomeUser;
            user.Sobrenome = SobrenomeUser;
            user.Email = EmailUser;
            user.Senha = SenhaUser;
            user.Localizacao = LocalizacaoUser;
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            ViewBag.Message1 = usuarioBLL.inseriUsuario(user);

            SupermercadoBLL supermercadoBLL = new SupermercadoBLL();
            ViewBag.Message2 = supermercadoBLL.inseriSupermercado(supermercado);

            LoginBLL loginbll = new LoginBLL();
            if (string.IsNullOrEmpty(user.Email))
            {
                login = supermercado.CNPJ;
                senha = supermercado.Senha;
                Login(login, senha);
            }
            else
            {
                login = user.Email;
                senha = user.Senha;
                Login(login, senha);
            }
            //dynamic objeto = loginbll.verificaLogin(login, senha);
            //if (objeto.GetType() == typeof(Supermercado))
            //{
            //    Cookie.Set("BudgShopTicket", objeto.ID.ToString() + "," + "1");
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    Cookie.Set("BudgShopTicket", objeto.ID.ToString() + "," + "2");
            //    return RedirectToAction("Index", "Home");
            //}

            return View();
        }

    }
}