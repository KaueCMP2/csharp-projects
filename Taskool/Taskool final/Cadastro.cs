using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskool_final.Model;

namespace Taskool_final
{
    public partial class Cadastro : Parent
    {
        dbTarefasEntities ctx = new dbTarefasEntities();
        Form _formAnterior;
        byte[] imagemBytes;
        public Cadastro(Form formAnterior)
        {
            InitializeComponent();
            _formAnterior = formAnterior;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Adicione seu nome e sobreno");
                return;
            }

            string[] partesNome = textBox1.Text.Split(' ');

            if (partesNome.Length > 1)
            {
                string nickname = $"{partesNome[0]}.{partesNome[partesNome.Length - 1]}{dateTimePicker1.Value.ToString("yy")}";

                if (partesNome.Length < 2)
                {
                    MessageBox.Show("Erro ao gerar");
                    return;
                }

                else if (ctx.Usuario.Any(n => n.Usuario1 == nickname))
                {
                    nickname = $"{partesNome[0]}.{partesNome[partesNome.Length - 2]}{dateTimePicker1.Value.ToString("yy")}";
                }
                textBox4.Text = nickname.ToLower();
                return;
            }
                MessageBox.Show("Adicione seu nome e sobreno");
                return;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
               || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
               || string.IsNullOrEmpty(textBox4.Text)) return;

            else if (ctx.Usuario.Any(n => n.Usuario1 == textBox4.Text))
                return;

            Usuario usas = new Usuario();
            usas.Nome = textBox1.Text;
            usas.Email = textBox2.Text;
            usas.Telefone = textBox3.Text;
            usas.Usuario1 = textBox4.Text;
            usas.Foto = imagemBytes;

            ctx.Usuario.Add(usas);
            ctx.SaveChanges();

            _formAnterior.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagemBytes = TrataImagem.SelecionarImagem(imagemBytes, button1);
        }

        private void Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formAnterior.Show();
        }
    }
}
