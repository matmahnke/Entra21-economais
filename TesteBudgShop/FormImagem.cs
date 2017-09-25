using BusinessLogicalLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteBudgShop
{
    public partial class FormImagem : Form
    {
        public FormImagem()
        {
            InitializeComponent();
        }
        public string base64;
        Base64Converter conversor = new Base64Converter();

        private void button1_Click(object sender, EventArgs e)
        {
            base64 =conversor.ImageFileToBase64(textBox1.Text);
            richTextBox1.Text = base64;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image a;
            a = conversor.Base64ToImage(base64);
            pictureBox1.Image = a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image a = pictureBox1.Image;
            richTextBox2.Text = conversor.ImageToBase64(a);

        }
    }
}
