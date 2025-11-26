using ListagemDeNotificacoes2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListagemDeNotificacoes2
{
    public partial class NotificacaoControl : UserControl
    {
        Sessao5Entities ctx = new Sessao5Entities();
        public NotificacaoControl()
        {
            InitializeComponent();
        }

        public NotificacaoControl(Notificacoes item)
        {
            InitializeComponent();
            Item = item;
            label1.Text = item.Titulo;
            label2.Text = item.Descricao;
            label2.Text = item.DataHoraCadastro.ToString("dd/MM/yyyy HH:mm");
        }

        public Notificacoes Item { get; }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var notificaApagar = ctx.Notificacoes.FirstOrDefault(n => n.Id == this.Item.Id);
            if (notificaApagar == null)
            {
                MessageBox.Show("Error");
                return;
            }
            
            ctx.Notificacoes.Remove(notificaApagar);
            ctx.SaveChanges();
            
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuterarNoti Auter = new AuterarNoti(this.Item.Id);
            Auter.ShowDialog();
        }
    }
}
