using Listagem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listagem
{
    public partial class NotificacaoControl : UserControl
    {
        Sessao5Entities1 ctx = new Sessao5Entities1();
        public NotificacaoControl()
        {
            InitializeComponent();
        }
        
        public NotificacaoControl(Notificacoes item)
        {
            InitializeComponent();
            Item = item;
            label1.Text = item.Titulo.ToString();
            label2.Text = item.Descricao.ToString();
            label3.Text = item?.DataHoraCadastro.ToString("dd:mm:yyyy HH:mm");
        }
        public Notificacoes Item { get; }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var produtoParaRemover = ctx.Notificacoes.FirstOrDefault(n => n.Id == this.Item.Id);
            if (produtoParaRemover != null)
            {
                ctx.Notificacoes.Remove(produtoParaRemover);
                ctx.SaveChanges();

                this.Parent.Controls.Remove(this);
                this.Dispose();
            }

            else
                MessageBox.Show("erro");
                return;
        }
    }
}
