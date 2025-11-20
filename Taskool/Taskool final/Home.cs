using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Taskool_final.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Taskool_final
{
    public partial class Home : Parent
    {
        Form _formAnterior;
        dbTarefasEntities ctx = new dbTarefasEntities();
        public Home(Form formAnterior)
        {
            InitializeComponent();
            this.Text = "Pagina Principal | Taskool";
            _formAnterior = formAnterior;
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
            User.id = 0;
            User.senha = null;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }


        public class Frase
        {
            public string Mensagem { get; set; }
            public string Autor { get; set; }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            FormConfgColor configColor = new FormConfgColor(this);
            configColor.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            var usas = ctx.Usuario.FirstOrDefault(u => u.Codigo == User.id);
            label1.Text = DateTime.Now.ToString("HH:mm");
            saudaPt();

            pictureBox1.BackgroundImage = TrataImagem.ConverterImagem(usas.Foto);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            if (User.senha == null)
            {
                return;
            }

            Color bckColor1 = ColorTranslator.FromHtml(User.senha);
            this.BackColor = bckColor1;
            return;
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            Color bckColor = ColorTranslator.FromHtml(User.senha);
            this.BackColor = bckColor;

            var json = File.ReadAllText("mensagens.json");
            var frases = new JavaScriptSerializer().Deserialize<Frase[]>(json);

            var f = frases[new Random().Next(frases.Length)];
            label2.Text = $"\" {f.Mensagem} \"";
            label3.Text = $"-{f.Autor}";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saudaPt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saudaIng();

        }

        public void saudaPt()
        {
            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                label6.Text = $"Boa Tarde {User.Nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 24)
            {
                label6.Text = $"Boa noite {User.Nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 12)
            {
                label6.Text = $"Bom dia {User.Nome}";
                return;
            }

            label6.Text = $"Boa madrugada {User.Nome}";
            return;
        }

        public void saudaIng()
        {
            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                label6.Text = $"Good Afternoon {User.Nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 24)
            {
                label6.Text = $"Good Evening {User.Nome}";
                return;
            }
            else if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 12)
            {
                label6.Text = $"Good Morning {User.Nome}";
                return;
            }

            label6.Text = $"Good Morning {User.Nome}";
            return;
        }
    }
}
