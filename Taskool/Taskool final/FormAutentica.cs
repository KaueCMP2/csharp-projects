using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskool_final.Model;

namespace Taskool_final
{
    public partial class FormAutentica : Parent
    {
        dbTarefasEntities ctx = new dbTarefasEntities();
        byte[] imagemBytes;
        public FormAutentica()
        {
            InitializeComponent();
            this.Text = "Autenticação | Taskool";
            textBox1.ShortcutsEnabled = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("osk.exe");
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagemBytes = TrataImagem.SelecionarImagem(imagemBytes, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
                return;

            var usas = ctx.Usuario.FirstOrDefault(u => u.Usuario1 == textBox1.Text);

            if (usas == null)
            {
                gerarPasta();
                return;
            }

            else if (usas.Usuario1 == textBox1.Text)
            {
                if (imagemBytes == null)
                {
                    "Imagem invalida".Alert();
                    return;

                   
                  
                }
                else if (!usas.Foto.SequenceEqual(imagemBytes))
                {
                    "Dados Incorretos".Alert();

                    return;
                }

                byte[] imagemBanco = usas.Foto;
                if (imagemBanco.SequenceEqual(imagemBytes))
                {
                    User.id = usas.Codigo;
                    User.senha = usas.Senha;
                    User.Nome = usas.Nome;

                    Home pagInicial = new Home(this);
                    pagInicial.Show();
                    this.Hide();
                    return;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastro paginaCadastro = new Cadastro(this);
            paginaCadastro.Show();
            this.Hide();
        }

        public string pegarIp()
        {
            string ip = Dns.GetHostAddresses(Dns.GetHostName())
                .First(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .ToString();
            return ip.ToString();
        }

        public void gerarPasta()
        {
            Random random = new Random();
            int id = random.Next(0, 1000);

            string pasta = @"C:\USER_LOG";
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string caminhoArquivo = Path.Combine(pasta, $"{textBox1.Text}{id}.txt");
            bool novoArquivo = !File.Exists(caminhoArquivo);

            using (StreamWriter sw = new StreamWriter(caminhoArquivo, true))
            {
                sw.WriteLine("Data;Hora;Usuario;IP ");

                sw.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy")};{DateTime.Now.ToString("hh:mm")};{textBox1.Text};{pegarIp()}");
            }
        }

        private void FormAutentica_Activated(object sender, EventArgs e)
        {
            button1.BackgroundImage = null;
        }
    }
}
