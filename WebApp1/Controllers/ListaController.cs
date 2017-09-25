using BudgShopAPP;
using BusinessLogicalLayer;
using DataAccessLayer;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using GoogleMaps.LocationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Comparar(string listaFinal, string localizacao)
        {
            string endereco = "";
            while (string.IsNullOrWhiteSpace(endereco))
            {
                try
                {
                    string url = "https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyA-sAUEFZVEDmzTx4DYXxwoEusdL7IsGSc&latlng=" + localizacao.Split(',')[0] + "," + localizacao.Split(',')[1] + "&sensor=false";
                    JObject jsonEndereco = getJsonByUrl(url);
                    JArray jarrayEndereco = (JArray)jsonEndereco.SelectToken("results");
                    endereco = (string)jarrayEndereco[0].SelectToken("formatted_address");
                }
                catch
                {
                }
            }
            string json = Server.UrlDecode(listaFinal);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            List<Item> itens = root.value.items;
            SupermercadoBLL bll = new SupermercadoBLL();
            List<Supermercado> supermercados = bll.selecionaTodosSupermercado();
            List<MercadoViewModels> lista = new List<MercadoViewModels>();
            GoogleLocationService locationSvc = new GoogleLocationService("AIzaSyA-sAUEFZVEDmzTx4DYXxwoEusdL7IsGSc");
            AddressData enderecoCliente = new AddressData();
            enderecoCliente.Address = endereco;

            foreach (Supermercado supermercado in supermercados)
            {
                MercadoViewModels Mercado = new MercadoViewModels();
                double Preco = 0;
                List<Item> itensMercado = new List<Item>();
                foreach (Item item in itens)
                {
                    Item itemMercado = new Item();
                    itemMercado.amount = SetorBLL.TrazPreco(item, supermercado.ID);
                    if (itemMercado.amount != 0)
                    {
                        itemMercado = item;
                        Preco += itemMercado.amount * itemMercado.quantity;
                        itensMercado.Add(itemMercado);
                    }
                }
                Mercado.Itens = itensMercado;
                Mercado.ItensNaoEncontrados = itens.Except(Mercado.Itens).ToList();
                Mercado.PrecoFinal = Preco;
                Mercado.SuperMercado = supermercado;
                lista.Add(Mercado);
                AddressData enderecoMercado = new AddressData();
                enderecoMercado.Address = supermercado.Endereco;
                Directions directions = new Directions();
                while (directions.Distance == null)
                {
                    try
                    {
                        directions = locationSvc.GetDirections(enderecoCliente, enderecoMercado);
                    }
                    catch (Exception)
                    {
                    }
                }
                Mercado.Proximidade = Convert.ToDouble(directions.Distance.Split(' ')[0], new CultureInfo("en-us"));
            }
            ComparadorMercadosViewModels Comparador = new ComparadorMercadosViewModels();
            Comparador.OutrosMercados = lista;
            Comparador.MercadosMenorPreco = lista.FindAll(o => o.ItensNaoEncontrados.Count() == 0).ToList().OrderBy(o => o.PrecoFinal).Take(3).ToList();
            Comparador.OutrosMercados = Comparador.OutrosMercados.Except(Comparador.MercadosMenorPreco).ToList();
            Comparador.MercadosMaisProximos = lista.FindAll(o => o.ItensNaoEncontrados.Count() == 0).ToList().OrderBy(o => o.Proximidade).Take(3).ToList();
            Comparador.OutrosMercados = Comparador.OutrosMercados.Except(Comparador.MercadosMaisProximos).ToList();
            try
            {
                Comparador.MercadoNossaSugestao = (MercadoViewModels)lista.FindAll(o => o.ItensNaoEncontrados.Count() == 0).ToList().OrderBy(o => (o.Proximidade * 0.3 + o.PrecoFinal * 0.7)).ToArray()[0];
            }
            catch { }
            Comparador.OutrosMercados.Remove(Comparador.MercadoNossaSugestao);

            return View(Comparador);
        }

        public ActionResult Comparar()
        {
            return RedirectToAction("Index", "Home");
        }

        public static JObject getJsonByUrl(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader streamreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        JObject o = JObject.Parse(streamreader.ReadToEnd());
                        return o;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}