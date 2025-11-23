using ComparadorImagemDb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparadorImagemDb
{
    public partial class Form1 : Form
    {

        CPikomon cpik = new CPikomon();

        ArmazenaPikomonEntities2 pik = new ArmazenaPikomonEntities2();
        bool imagemSelecionada = false;
        byte[] imagemBytes;
        private Image SelecionarImagem()
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Title = "Selecionar imagem";
            opf.Filter = "Filtro de Image | *.png;*.jpg;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                imagemSelecionada = true;
                imagemBytes = File.ReadAllBytes(opf.FileName);
                return Image.FromFile(opf.FileName);
            }

            return null;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btSelecionarImg_Click(object sender, EventArgs e)
        {
            Image imagemEscolhida = SelecionarImagem();

            if (imagemEscolhida == null)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Selecione uma imagem");
                imagemEscolhida = SelecionarImagem();
            }
            btSelecionarImg.BackgroundImage = imagemEscolhida;
            btSelecionarImg.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btEncontrar_Click(object sender, EventArgs e)
        {
            var pikomonBuscado = pik.Pikomon.FirstOrDefault(p => p.Foto == imagemBytes);

            if (pikomonBuscado != null)
            {
                cpik.Nome = pikomonBuscado.Nome;
                cpik.Tipo = pikomonBuscado.tipo;
                cpik.Vantagem = pikomonBuscado.Vantagem;
                cpik.Fraqueza = pikomonBuscado.Fraqueza;
                cpik.FotoPik = ;

                cpik.pikemonPesquisado = true;

                if (cpik.pikemonPesquisado != false)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show($"O pikemon é: {cpik.Nome}");
                    new Form2().Show();
                    this.Hide();
                }
            }

            else
            {
                SystemSounds.Beep.Play();
                var pergunta = MessageBox.Show("Pikomon da foto nao foi encontado... Cadastrar descoberta?");

                if (pergunta == DialogResult.OK)
                {
                    new cadastro().Show();
                    this.Hide();
                }
            }
        }

        private void lblCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            new cadastro().Show();
            this.Hide();

        }
    }
}

