using BusinessLogicalLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    //FormsAuthenticationTicket + MVC + Authorize
    public static class Cookie
    {
        private const string CookieSetting = "Cookie.Duration";
        private const string CookieIsHttp = "Cookie.IsHttp";
        private static HttpContext _context { get { return HttpContext.Current; } }
        static Cookie()
        {
        }

        public static string GetUserName()
        {
            try
            {
                string retorno;
                string data = Get("BudgShopTicket");
                if (data == null)
                {
                    return null;
                }
                string[] dados = data.Split(',');
                if (dados[1] == "1")
                {
                    SupermercadoBLL bll = new SupermercadoBLL();
                    Supermercado supermercado = bll.selecionaSupermercado(Convert.ToInt32(dados[0]));
                    retorno = supermercado.Nome;
                }
                else
                {
                    UsuarioBLL bll = new UsuarioBLL();
                    Usuario usuario = bll.selecionarPorID(Convert.ToInt32(dados[0]));
                    retorno = usuario.Nome;
                }

                return retorno;
            }
            catch (Exception)
            {

            return null;
            }
        }

        public static void Set(string key, string value)
        {
            var c = new HttpCookie(key)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true
            };
            _context.Response.Cookies.Add(c);
        }

        public static string Get(string key)
        {
            var value = string.Empty;

            var c = _context.Request.Cookies[key];
            return c != null
                    ? _context.Server.HtmlEncode(c.Value).Trim()
                    : value;
        }

        public static bool Exists(string key)
        {
            return _context.Request.Cookies[key] != null;
        }

        public static void Delete(string key)
        {
            if (Exists(key))
            {
                var c = new HttpCookie(key) { Expires = DateTime.Now.AddDays(-1) };
                _context.Response.Cookies.Add(c);
            }
        }

        public static void DeleteAll()
        {
            for (int i = 0; i <= _context.Request.Cookies.Count - 1; i++)
            {
                if (_context.Request.Cookies[i] != null)
                    Delete(_context.Request.Cookies[i].Name);
            }
        }
    }
}