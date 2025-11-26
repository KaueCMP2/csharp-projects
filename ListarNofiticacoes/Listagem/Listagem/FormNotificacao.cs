using Listagem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listagem
{
    public partial class FormNotificacao : parent
    {
        public FormNotificacao()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            this.Text = "Notificacoes | Jogos";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var notficacao = ctx.Notificacoes.ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var item in notficacao)
            {
                flowLayoutPanel1.Controls.Add(new NotificacaoControl(item));
            }
        }
    }
}
