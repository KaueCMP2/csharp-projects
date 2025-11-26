using AxWMPLib;
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
using WMPLib;

namespace TesteVideo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        List<string> Video = new List<string>(); // objeto de lista string com nome video
        int posicao = 0; // seta a posicao como 0
        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none"; // desativa as opcoes de controle do wmp
            this.FormBorderStyle = FormBorderStyle.None; // tira as bordas do form...
            
            Video = Directory.GetFiles("Videos").ToList(); // A lista de string video, recebe o conteudo da pasta video em lista
            posicao = new Random().Next(Video.Count); // posicao agora sera aleatoria
            
            axWindowsMediaPlayer1.URL = Video[posicao]; // diz que oque vai aparecer no wmp e onde esta a posicao na lista de string video
            axWindowsMediaPlayer1.settings.autoStart = true; // inicia automaticamente
            axWindowsMediaPlayer1.settings.playCount = 1; // permite o video rodar apenas uma vez
            axWindowsMediaPlayer1.Ctlcontrols.play(); // da o play no vide selecionado
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e) // mudanca de estado
        {
            if(e.newState == 8) // se video acabar (8)
            {
                Close(); // apenas fecha o form...
            }
        }
    }
}
