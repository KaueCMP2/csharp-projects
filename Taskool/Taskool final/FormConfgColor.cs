using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskool_final.Model;

namespace Taskool_final
{
    public partial class FormConfgColor : Parent
    {
        Form _formAnterior;
        dbTarefasEntities ctx = new dbTarefasEntities();
        public FormConfgColor(Form formAnterior)
        {
            InitializeComponent();
            this.Text = "Configurar Cor | Taskool";
            maskedTextBox1.Text = "255255255";
            maskedTextBox1.Mask = "RGB(000,000,000)";
            maskedTextBox1.TextChanged += maskedTextBox1_TextChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Color corSelecionada = dlg.Color;

                    int r = corSelecionada.R;
                    int g = corSelecionada.G;
                    int b = corSelecionada.B;

                    Color c = Color.FromArgb(r, g, b);

                    textBox1.Text = ColorTranslator.ToHtml(c);
                    maskedTextBox1.Text = $"{r:d3}{g:d3}{b:d3}";
                    this.BackColor = c;

                    return;
                }
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] p = maskedTextBox1.Text.Replace("RGB(", "").Replace(")", "").Trim().Split('.');

                int r = p.Length > 0 && p[0].Trim().Length == 3 ? int.Parse(p[0]) : 0;
                int g = p.Length > 1 && p[1].Trim().Length == 3 ? int.Parse(p[1]) : 0;
                int b = p.Length > 2 && p[2].Trim().Length == 3 ? int.Parse(p[2]) : 0;

                Color cor = Color.FromArgb(r, g, b);
                this.BackColor = cor;

                textBox1.Text = ColorTranslator.ToHtml(cor);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usas = ctx.Usuario.FirstOrDefault(u => u.Codigo == User.id);

            if (usas == null)
            {
                "Erro ao encontrar usuario".Alert();
                return;
            }

            if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.Text.Length <= 7)
            {
                User.senha = textBox1.Text.ToString();
                string cor = textBox1.Text.ToString();
                usas.Senha = $"{cor}";           
                ctx.SaveChanges();


                Close();
                return;
            } 

            else
            {
                "nao foi possivel salvar a cor".Alert();
                return;
            }
        }
    }
}