using LoginCadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCadastro
{
    public partial class Cadastro : Parent
    {       
        loginCad1Entities ctx = new loginCad1Entities();
        Form _formAnterior;
        byte[] imagemBytes;
        public Cadastro(Form formAnterior)
        {
            InitializeComponent();

            _formAnterior = formAnterior;
        }

        private void Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formAnterior.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!email.EmailValido(textBox1.Text))
            {
                "Email invalido".Alert();
                textBox1.Focus();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
               || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || imagemBytes == null)
            {
                "Todos os campos sao obrigatorios".Alert();
                return;
            }

            else if (ctx.User1.Any(u => u.Apelido == textBox3.Text))
            {
                "Ops... apelido ja esta em uso".Info();
                textBox3.Focus();
                return;
            }

            User1 usas = new User1();       
            
            usas.Email = textBox1.Text.ToLower();
            usas.Senha = textBox2.Text;
            usas.Apelido = textBox3.Text;
            usas.TimeFavorito = textBox4.Text;
            usas.CorFavorita = textBox5.Text;
            usas.DatNascimento = dateTimePicker1.Value;
            usas.Foto = imagemBytes;

            ctx.User1.Add(usas);
            ctx.SaveChanges();
            "Cadastrado com sucesso".Info();
            
            _formAnterior.Show();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            imagemBytes = foto.SelecionarImagem(imagemBytes, pictureBox1);
        }
    }
    public static class email
    {
        public static bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }
    }
    public static class foto
    {
        public static byte[] SelecionarImagem(byte[] bytes, PictureBox pic) {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione uma imagem";
            ofd.Filter = "Tipo Imagem | *.jpg; *.png;";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pic.BackgroundImage = Image.FromFile(ofd.FileName);
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                bytes = File.ReadAllBytes(ofd.FileName);
                return bytes;
            }
            return null;
        }
    }
}
