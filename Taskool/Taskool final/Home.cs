using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Taskool_final
{
    public partial class Home : Parent
    {
        string _nome;
        byte[] _fotoUser;
        Form _formAnterior;
        public Home(Form formAnterior, string nome, byte[] fotoUser)
        {
            InitializeComponent();
            _nome = nome;
            _fotoUser = fotoUser;
            _formAnterior = formAnterior;

            label1.Text = DateTime.Now.ToString("HH:mm");
            sauda();

            pictureBox1.BackgroundImage = TrataImagem.ConverterImagem(_fotoUser);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            
            var json = File.ReadAllText("mensagens.json");
            var frases = new JavaScriptSerializer().Deserialize<Frase[]>(json);

            var f = frases[new Random().Next(frases.Length)];
            label2.Text = $"\"{f.Mensagem}\"\n\n-{f.Autor}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _formAnterior.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm");
        }

        public void sauda()
        {
            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                label2.Text = $"Boa Tarde {_nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 24)
            {
                label2.Text = $"Boa noite {_nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 12)
            {
                label2.Text = $"Bom dia {_nome}";
                return;
            }

            label2.Text = $"Boa madrugada {_nome}";
            return;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            _formAnterior.Show();
            this.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formAnterior.Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            groupBox2.Visible=false;    
        }


        public class Frase  
        {
            public string Mensagem { get; set; }
            public string Autor { get; set; }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
