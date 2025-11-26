using ListagemDeNotificacoes2.Model;
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

namespace ListagemDeNotificacoes2
{
    public partial class AuterarNoti : Form
    {
        Sessao5Entities ctx = new Sessao5Entities();
        int _id;
        public AuterarNoti(int id)
        {
            InitializeComponent();
            _id = id;
        }


        private void AuterarNoti_Load(object sender, EventArgs e)
        {
            var notificacaoProc = ctx.Notificacoes.FirstOrDefault(x => x.Id == _id);
            textBox1.Text = notificacaoProc.Titulo;
            textBox4.Text = notificacaoProc.Descricao;
            textBox5.Text = notificacaoProc.Importancia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var notificacaoProc = ctx.Notificacoes.FirstOrDefault(x => x.Id == _id);
            if (notificacaoProc == null)
                return;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Erro ao adicionar, preencha todos os campos");
                return;
            }

            if (textBox5.Text == "Media" || textBox5.Text == "Média" || textBox5.Text == "Baixa" || textBox5.Text == "Alta")
            {
                notificacaoProc.Titulo = textBox1.Text;
                notificacaoProc.Descricao = textBox4.Text;
                notificacaoProc.Importancia = textBox5.Text;

                ctx.SaveChanges();
                Close();
            }


            else
            {
                MessageBox.Show("Digite o nivel de importancia como: \"Baixo\" \"Medio\" ou \"Alto\"");
                return;
            }
        }
    }
}
