using ListagemDeNotificacoes2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListagemDeNotificacoes2
{
    public partial class Form1 : Form
    {
        Sessao5Entities ctx = new Sessao5Entities();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Notificacoes";
            flowLayoutPanel1.AutoScroll = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            var notificacao = ctx.Notificacoes.ToList();
            foreach (var item in notificacao)
            {
                flowLayoutPanel1.Controls.Add(new NotificacaoControl(item));
            }
        }
    }
}
