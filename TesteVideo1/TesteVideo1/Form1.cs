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

        List<string> Video = new List<string>();
        int posicao = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.enableContextMenu = false;

            this.FormBorderStyle = FormBorderStyle.None;
            
            Video = Directory.GetFiles("Videos").ToList();
            posicao = new Random().Next(Video.Count);
            
            axWindowsMediaPlayer1.URL = Video[posicao];
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.playCount = 1;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                Close();
            }
        }
    }
}
