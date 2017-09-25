using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteBudgShop
{
    public partial class FormSetor : Form
    {
        public FormSetor()
        {
            InitializeComponent();
        }
        public List<Produto> lista = new List<Produto>();
        public SetorDAL setorDAL = new SetorDAL();
        public Setor setor = new Setor();
        private void btInsert_Click(object sender, EventArgs e)
        {
            setor.Nome = txtNome.Text;
            setor.CodigoMercado = Convert.ToInt32(txtCodProduto.Text);
            setor.Produto = lista;
            setorDAL.InsertXML(setor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Nome = txtProduto.Text;
            produto.Preco = Convert.ToDouble(txtPreco.Text);
            produto.Quantidade = Convert.ToInt32(txtQtd.Text);
            produto.Peso = Convert.ToDouble(txtPeso.Text);
            produto.Imagem = txtImagem.Text;
            produto.Promocao = Convert.ToDouble(txtPromocao.Text);
            produto.DataDeInicio = dateTimePicker1.Value;
            produto.DataDeTermino = dateTimePicker2.Value;
            lista.Add(produto);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlWhereSetor where = new SqlWhereSetor();
            SqlCommand comando = where.XmlLike("Nome", "Endorina");
            List<Produto> temp = setorDAL.SelectXML(comando);
            foreach (Produto item in temp)
            {
                txtImagem.Text += (string)item.Nome;
                txtImagem.Text += item.Preco.ToString();
                txtImagem.Text += item.Quantidade.ToString();
                txtImagem.Text += item.Peso.ToString();
                txtImagem.Text += item.Imagem;
                txtImagem.Text += item.Promocao.ToString();
                txtImagem.Text += item.DataDeInicio.ToString();
                txtImagem.Text += item.DataDeTermino.ToString();
            }
        }

        private void FormSetor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setor.Nome = txtNome.Text;
            setor.CodigoMercado = Convert.ToInt32(txtCodProduto.Text);
            setor.Produto = lista;
            SqlCommand comando = new SqlCommand();
            setorDAL.DeleteXMLRow(setor,comando);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
            setor.Nome = txtNome.Text;
            setor.CodigoMercado = Convert.ToInt32(txtCodProduto.Text);
            setor.Produto = lista;
            setorDAL.UpdateXML(setor,comando);
        }
    }
}
