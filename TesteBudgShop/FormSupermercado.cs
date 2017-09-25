using BusinessLogicalLayer;
using DataAccessLayer.Infrastructure;
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
    public partial class FormSupermercado : Form
    {
        public FormSupermercado()
        {
            InitializeComponent();
        }
        public SupermercadoDAL supermercadoDAL = new SupermercadoDAL();

        private void txtLogo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlCommand comando = new SqlCommand();
            //List<Supermercado> lista = supermercadoDAL.GetALL(comando);
            //foreach (Supermercado item in lista)
            //{
            //    richTextBox1.Text += " "+ item.ID;
            //    richTextBox1.Text += " "+ item.Nome;
            //    richTextBox1.Text += " "+ item.RazaoSocial;
            //    richTextBox1.Text += " "+ item.Maps;
            //    richTextBox1.Text += " "+ item.CNPJ;
            //    richTextBox1.Text += " "+ item.Bairro;
            //    richTextBox1.Text += " "+ item.Telefone;
            //    richTextBox1.Text += " "+ item.Email;
            //    richTextBox1.Text += " "+ item.Senha;
            //    richTextBox1.Text += " "+ item.Logo;
            //}
            LoginBLL bll = new LoginBLL();
            object objeto = bll.verificaLogin(txtNome.Text, txtRazaoSocial.Text);
            LoginBLL loginbll = new LoginBLL();
            try
            {
                if (objeto.GetType() == typeof(Usuario))
                {
                    MessageBox.Show("funcionou");
                }
                else
                {

                    MessageBox.Show("funcionou");
                }
            }
            catch (Exception)
            {
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Supermercado supermercado = new Supermercado();
            supermercado.Nome = txtNome.Text;
            supermercado.RazaoSocial = txtRazaoSocial.Text;
            supermercado.Maps = txtMaps.Text;
            supermercado.CNPJ = txtCNPJ.Text;
            supermercado.Endereco = txtBairro.Text;
            supermercado.Telefone = txtTelefone.Text;
            supermercado.Email = txtEmail.Text;
            supermercado.Senha = txtSenha.Text;
            supermercado.Logo = txtLogo.Text;
            supermercado.ID = Convert.ToInt32(txtID.Text);
            supermercadoDAL.Update(supermercado);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supermercado supermercado = new Supermercado();
            supermercado.ID = Convert.ToInt32(txtID.Text);
            supermercadoDAL.Delete(supermercado);
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            Supermercado supermercado = new Supermercado();
            supermercado.Nome = txtNome.Text;
            supermercado.RazaoSocial = txtRazaoSocial.Text;
            supermercado.Maps = txtMaps.Text;
            supermercado.CNPJ = txtCNPJ.Text;
            supermercado.Endereco = txtBairro.Text;
            supermercado.Telefone = txtTelefone.Text;
            supermercado.Email = txtEmail.Text;
            supermercado.Senha = txtSenha.Text;
            supermercado.Logo = txtLogo.Text;
            supermercadoDAL.Insert(supermercado);
        }

        private void FormSupermercado_Load(object sender, EventArgs e)
        {

        }
    }
}
