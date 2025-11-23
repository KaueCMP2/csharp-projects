using ComparadorImagemDb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparadorImagemDb
{
    public partial class cadastro : Form
    {
        ArmazenaPikomonEntities2 pik = new ArmazenaPikomonEntities2();

        byte[] pikomonBytes;
        bool fotoPikomonCarregada = false;
        private Image SelecionarImagem()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione o pikomon";
            ofd.Filter = "Imagem Tipo |  *.jpg; *.png;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pikomonBytes = File.ReadAllBytes(ofd.FileName);
                fotoPikomonCarregada = true;
                return Image.FromFile(ofd.FileName);
            }
            return null;
        }
        public cadastro()
        {
            InitializeComponent();
        }


        private void btFotoPik_Click(object sender, EventArgs e)
        {
            Image fotoPikomon = SelecionarImagem();

            if (fotoPikomon != null)
            {
                btFotoPik.BackgroundImage = fotoPikomon;
                btFotoPik.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void savePik_Click(object sender, EventArgs e)
        {
            if (fotoPikomonCarregada == false || string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtFraqueza.Text) ||
                string.IsNullOrWhiteSpace(txtVantagens.Text))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Informe todos os dados do pikomon", "Vai Moscar?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            else if(pik.Pikomon.Any(i => i.Foto == pikomonBytes))
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Ops, Pikomon ja cadastradado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                Pikomon usas = new  Pikomon();
                usas.Foto = pikomonBytes;
                usas.Nome = txtNome.Text;
                usas.tipo = txtTipo.Text;
                usas.Fraqueza = txtFraqueza.Text;
                usas.Vantagem = txtVantagens.Text;

                pik.Pikomon.Add(usas);
                pik.SaveChanges();
                bool pikomonSalvo = true;

                if (pikomonSalvo == true)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Parabens o pikomon ja esta na nuvem KKKKKKK... Ou pikobola!!!");
                    var querSalvarOutro = MessageBox.Show("Só para saber mesmo... Quer salvar outro pokemon?", "AJUDAR MAIS O DEV?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (querSalvarOutro == DialogResult.Yes)
                    {
                        txtNome.Text = " ";
                        txtTipo.Text = " ";
                        txtVantagens.Text = " ";
                        txtFraqueza.Text = " ";

                        pikomonSalvo = false;
                    }
                }
                new Form1().Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
