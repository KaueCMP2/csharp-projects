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

namespace Notificacao3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";
        }

        List<string> Video = new List<string>();
        int posicao = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Video = Directory.GetFiles("Videos").ToList();
            posicao = new Random().Next(Video.Count);

            axWindowsMediaPlayer1.URL = Video[posicao];
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.settings.playCount = 1;  
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                FormNotificaView formNotif = new FormNotificaView(this);
                formNotif.Show();
                Hide();
            }
        }
    }
}
