using LoginCadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCadastro
{
	public partial class Form3 : Parent
	{
		loginCad1Entities ctx = new loginCad1Entities();
		Form _formAnterior;
		int _idUser;
		public Form3(Form formAnterior, int id)
		{
			InitializeComponent();

			_formAnterior = formAnterior;
			_idUser = id;

			var usas = ctx.User1.FirstOrDefault(u => u.Id == id);
			label1.Text = $"Bem Vindo(a) {usas.Apelido}";

			pictureBox1.BackgroundImage = ByteParaFoto(usas.Foto);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}

		public Image ByteParaFoto(byte[] imagem)
		{
			var usas = ctx.User1.FirstOrDefault(u => u.Id == _idUser);
			if (usas.Foto == null)
			return null;

			using(MemoryStream ms = new MemoryStream(imagem))
			{

				return Image.FromStream(ms); 
			}
		}

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
			_formAnterior.Show();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
			groupBox1.Visible = true;
        }

        private void Form3_Click(object sender, EventArgs e)
        {
			groupBox1.Visible = false;
        }
    }

}
