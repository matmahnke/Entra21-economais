using DataAccessLayer;
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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        public UsuarioDAL usuarioDAL = new UsuarioDAL();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = (string)txtNome.Text;
            usuario.Sobrenome = (string)txtSobrenome.Text;
            usuario.Senha = (string)txtSenha.Text;
            usuario.Localizacao = (string)txtLocalizacao.Text;
            usuario.ListaFavoritos = (string)txtLista.Text;
            usuario.UltimaLista = (string)txtUltimaLista.Text;
            usuario.Email = (string)textBox1.Text;
            usuarioDAL.Insert(usuario);
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlWhereUsuario where = new SqlWhereUsuario();
            SqlCommand sql = where.verificaLoginUsuario("a","a");
            List<Usuario> usuario = usuarioDAL.GetALL(sql);
            foreach (Usuario item in usuario)
            {
                richTextBox1.Text += " "+ item.ID;
                richTextBox1.Text += " "+ (string)item.Nome;
                richTextBox1.Text += " "+ item.Sobrenome;
                richTextBox1.Text += " "+ (string)item.Senha;
                richTextBox1.Text += " "+ (string)item.Localizacao;
                richTextBox1.Text += " "+ (string)item.ListaFavoritos;
                richTextBox1.Text += " "+ (string)item.UltimaLista;
                richTextBox1.Text += " "+ (string)item.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.ID = Convert.ToInt32(textBox2.Text);
            usuarioDAL.Delete(usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = (string)txtNome.Text;
            usuario.Sobrenome = (string)txtSobrenome.Text;
            usuario.Senha = (string)txtSenha.Text;
            usuario.Localizacao = (string)txtLocalizacao.Text;
            usuario.ListaFavoritos = (string)txtLista.Text;
            usuario.UltimaLista = (string)txtUltimaLista.Text;
            usuario.Email = (string)textBox1.Text;
            usuario.ID = Convert.ToInt32(textBox2.Text);
            usuarioDAL.Update(usuario);
        }
    }
}
