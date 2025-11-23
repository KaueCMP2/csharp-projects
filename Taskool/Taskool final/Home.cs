using MediaPlayer;
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
using WMPLib;
using static System.Net.Mime.MediaTypeNames;

namespace Taskool_final
{
    public partial class Home : Parent
    {
        // instanciar objeto do wmp...
        WindowsMediaPlayer media = new WindowsMediaPlayer();

        Form _formAnterior;
        dbTarefasEntities ctx = new dbTarefasEntities();
        public Home(Form formAnterior)
        {
            InitializeComponent();
            this.Text = "Pagina Principal | Taskool";
            _formAnterior = formAnterior;
        }

        //--------------------------------------------------------------------------------------------------------------------
        // tratamento hora na label
        //--------------------------------------------------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm");
        }
        //--------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------
        // Tratamento foto perfil...
        //--------------------------------------------------------------------------------------------------------------------
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
        //--------------------------------------------------------------------------------------------------------------------

        // Abre o gpBox com as opcoes
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            FormConfgColor configColor = new FormConfgColor(this);
            configColor.Show();
        }

        // label sair do gp...
        private void label5_Click(object sender, EventArgs e)
        {
            _formAnterior.Show();
            this.Close();
        }

        // Fecha o gpBox que abre ao clicar na foto de perfil
        private void Home_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        //--------------------------------------------------------------------------------------------------------------------
        // Inicia o tratamente para desserializar e imprimir as imagens
        //--------------------------------------------------------------------------------------------------------------------
        public class Frase // classe para guardar as mensagens e autores do json mensagens
        {
            public string Mensagem { get; set; }
            public string Autor { get; set; }
        }
        //--------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------
        // Tratamenot musica inicial
        //--------------------------------------------------------------------------------------------------------------------

        List<string> musicas = new List<string>(); // Instancia uma lista de string com nome musica
        int posicao = 0; // Cria variavel posicao que incia como 0
        private void Home_Load(object sender, EventArgs e)
        {
            musicas = Directory.GetFiles("musicas").ToList(); // A lista musicas recebe o conteudo da pasta musicas
            posicao = new Random().Next(musicas.Count); // posicao agora recebe um valor aleatorio da lista de musicas

            media.URL = musicas[posicao]; // indica que o local da musica é o valor da variavel posicao dentro da lista de musicas
            label7.Text = Path.GetFileName(musicas[posicao]); // O nome da musica aparece naa label7

            media.PlayStateChange += media_playstateChange; // se o estado de media mudar... chama o metodo media_playstatechange
                                                            // que eu criei usando o (ctrl + .)
            media.controls.stop(); // inicia como stop, para a musica nao comecar ja tocando.

            //--------------------------------------------------------------------------------------------------------------------
            //tratamento Configurar inicio de hora e idioma
            //--------------------------------------------------------------------------------------------------------------------

            label1.Text = DateTime.Now.ToString("HH:mm"); // Ja  inicia a label1 com a hora para nao ter delay.
            saudaPt(); // Por padrao a saudacao ja vem em portugues

            //--------------------------------------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------------------------------------
            // tratamento foto de perfil
            //--------------------------------------------------------------------------------------------------------------------

            var usas = ctx.Usuario.FirstOrDefault(u => u.Codigo == User.id); // guarda na variavel usuario os dados do usuario
                                                                             // cadastrado no banco cujo o codigo e igual ao user.id

            pictureBox1.BackgroundImage = TrataImagem.ConverterImagem(usas.Foto); // A imagem do icone do perfil e a mesma que esta                                                                                  // no banco de dados
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch; // Arruma o formato da foto para caber na box.

            //--------------------------------------------------------------------------------------------------------------------                       
        }

        // Metodo que é chamado quando o media muda de estado
        private void media_playstateChange(int NewState)
        {
            if (NewState == 8) // se o novo estado for 8 ou seja, que a musica acabou
            {
                posicao = (posicao + 1) % musicas.Count; // E incrementado 1 na posicao e logo depois pega o resto da divisao pelo total de musicas.
                                                         // Que faz o indice voltar a 0 quando chega no final.              

                media.URL = musicas[posicao]; // a musica que toca agora e igual a posicao que a variavel posica se encontra
                label7.Text = Path.GetFileName(musicas[posicao]); // O nome da musica que a posicao esta e escrita na label 7

            }
        }

        // bt play
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Play") // if o texto do botao for play
            {
                button3.Text = "Pause"; // o texto vira pause e...
                media.controls.play(); // da play na musica
                return; // retorna para nao precisar escrever else
            }

            // se nao, no caso se for Pause
            button3.Text = "Play"; // o texto vira play e... 
            media.controls.pause(); // a musica pausa
            return;
        }

        //--------------------------------------------------------------------------------------------------------------------


        // Metodo para quando o form for ativado... oque e quase a mesma coisa que ser carregado (load)...
        private void Home_Activated(object sender, EventArgs e)
        {
            // esse metodo eu coloquei para que quando eu mudasse a cor de fundo e saisse do ConfCollors, a cor desse form mudaria...
            Color bckColor = ColorTranslator.FromHtml(User.senha);  // converte string em cor...
            this.BackColor = bckColor; // aplica a cor no fundo do form

            //  em apenas uma linha, desserializa e guarda como lista na classe frase as mensagens e autores,
            //  de todo o texto do arquivo mensagens.json
            var frases = new JavaScriptSerializer().Deserialize<Frase[]>(File.ReadAllText("mensagens.json"));

            if (frases.Length > 0) // if basico so para nao quebrar a aplicacao
            {
                var f = frases[new Random().Next(frases.Length)]; // seleciona aleatoriamente uma frase e seu autor e guarda em f...                       
                label2.Text = $"\" {f.Mensagem} \"";
                label3.Text = f.Autor;
            }
        }

        // bt ingles
        private void button1_Click_1(object sender, EventArgs e)
        {
            saudaIng();
        }

        // bt portugues
        private void button2_Click(object sender, EventArgs e)
        {
            saudaPt();

        }

        // se o form estiver fechando
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formAnterior.Show(); // volta ao anterior
            User.id = 0; // sem id na classe user
            User.senha = null; // sem senha na classe user
            media.controls.stop(); // para a musica ao fechar o form.
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
