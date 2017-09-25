using DataAccessLayer;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TesteBudgShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Usuario a = new Usuario();
            //UsuarioDAL u = new UsuarioDAL();
            //a.ID = 2;
            //a.Nome = "Teste2";
            //a.Sobrenome = "Testex2";
            //a.Senha = "1232";
            //a.Localizacao = "href2";
            //a.ListaFavoritos = "12342";
            //a.Email = "teste@email.com2";
            //a.UltimaLista = "ultima2";
            /*List<Usuario> lista = new List<Usuario>();
            lista = u.GetALL(Usario);
            StringBuilder sb = new StringBuilder();
            foreach (Usuario item in lista)
            {
                sb.AppendLine(item.Nome+" "+item.Senha + " " + item.Sobrenome + " " + item.Localizacao + " " + item.ID + " " + item.ListaFavoritos + " " + item.UltimaLista);
            }
            label1.Text = sb.ToString();*/
            //u.Insert(a);
            //u.Update(a);
            //u.Delete(a);
            /*using (Image image = Image.FromFile(@"C:\Users\moc\Desktop\show"))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    richTextBox1.Text = base64String;

                    //Convert base64 to byte[]

                }
                byte[] imageBytes1 = Convert.FromBase64String(label1.Text);
                using (var ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length))
                {
                    Image image1 = Image.FromStream(ms, true);
                    pictureBox1.Image = image1;
                }
            }*/





            //SetorDAL sd = new SetorDAL();
            /*Setor s = new Setor();
            s.Nome = "Frutas";
            s.CodigoMercado = 5;
            List<Produto> l = new List<Produto>();
            Produto anb = new Produto();
            anb.Nome = "Endorina";
            anb.Peso = 8;
            anb.Imagem = Encoding.ASCII.GetBytes("a");
            anb.Preco = 984;
            anb.Quantidade = 45;
            anb.Promocao = 4;
            anb.DataDeInicio = DateTime.Now;
            anb.DataDeTermino = DateTime.Now;
            Produto and = new Produto();
            and.Nome = "Abacacia";
            and.Peso = 8;
            and.Imagem = Encoding.ASCII.GetBytes("a");
            and.Preco = 984;
            and.Quantidade = 45;
            and.Promocao = 4;
            and.DataDeInicio = DateTime.Now;
            and.DataDeTermino = DateTime.Now;
            l.Add(anb); l.Add(and);

            s.Produto = l;
            sd.UpdateXML(l,s);*/


            /*
          //List<Produto> rw = new List<Produto>();
          //sd.InsertXML(rw);
          Produto anb = new Produto();
          anb.Nome = "Endorina";
          anb.Peso = 8;
          anb.Imagem = Encoding.ASCII.GetBytes("a");
          anb.Preco = 984;
          anb.Quantidade = 45;
          anb.Promocao = 4;
          anb.DataDeInicio = DateTime.Now;
          anb.DataDeTermino = DateTime.Now;

          Produto and = new Produto();
          and.Nome = "Abacacia";
          and.Peso = 8;
          and.Imagem = Encoding.ASCII.GetBytes("a");
          and.Preco = 984;
          and.Quantidade = 45;
          and.Promocao = 4;
          and.DataDeInicio = DateTime.Now;
          and.DataDeTermino = DateTime.Now;

          List<Produto> anc = new List<Produto>();
          anc.Add(and);
          anc.Add(anb);

          Setor s = new Setor();
          s.Nome = "Frutas";
          s.CodigoMercado = 5;
          sd.InsertXML(anc,s);*/

            #region SelectXML
            /*
            List<Produto> anc = sd.SelectXML("WHERE Nome = 'Frutas'");
            Setor s = new Setor();
            s.Nome = "Frutas";
            s.CodigoMercado = 5;
            s.Produto = anc;
            s.ID = 9;
            sd.DeleteXMLRow(s);
            */
            #endregion


            //anc = sd.SelectXML("");
            //MessageBox.Show(anc.ToString());


            SupermercadoDAL dal = new SupermercadoDAL();
            Supermercado s = new Supermercado();
            s.ID = 6;
            s.Nome = "GiassiUP";
            s.RazaoSocial = "Giassi";
            s.Maps = "MapsExample";
            s.CNPJ = "CNPJExample";
            s.Bairro = "Perto da furb";
            s.Telefone = "40028922";
            s.Email = "giassi@giassi.com";
            s.Senha = "123";
            s.Logo = "Image";
            //dal.Insert(s);
             List<Supermercado> lista = dal.GetALL();
            foreach (Supermercado item in lista)
            {
                richTextBox1.Text += item.ID.ToString();
                richTextBox1.Text += item.Nome;
                richTextBox1.Text += item.RazaoSocial;
                richTextBox1.Text += item.Maps;
                richTextBox1.Text += item.CNPJ;
                richTextBox1.Text += item.Bairro;
                richTextBox1.Text += item.Telefone;
                richTextBox1.Text += item.Email;
                richTextBox1.Text += item.Senha;
                richTextBox1.Text += item.Logo.ToString();
            }
        }
    }
}
