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
            try // tenta
            {
                // guardar em p, o texto da makedTextBox1 sem RGB() e dividido apartir dos (.)
                string[] p = maskedTextBox1.Text.Replace("RGB(", "").Replace(")", "").Trim().Split('.');


                int r = p.Length > 0 && p[0].Trim().Length == 3 ? int.Parse(p[0]) : 0;
                int g = p.Length > 1 && p[1].Trim().Length == 3 ? int.Parse(p[1]) : 0;
                int b = p.Length > 2 && p[2].Trim().Length == 3 ? int.Parse(p[2]) : 0;

                this.BackColor = Color.FromArgb(r, g, b); // muda a cor do fundo para a cor escrita na maskedTextBox1
                textBox1.Text = ColorTranslator.ToHtml(BackColor); // escreve em Hex, a cor que esta no fundo
            }
            catch { } // execao nao faz nada.
        }

        // botao de salvar
        private void button1_Click(object sender, EventArgs e)
        {
            // carrega o usuario do banco pelo id
            var usas = ctx.Usuario.FirstOrDefault(u => u.Codigo == User.id);

            // se usuario for null
            if (usas == null)
            {
                "Erro ao encontrar usuario".Alert();
                return;
            }

            // se nao verifica se tem algo na textbox1 e se e menor ou igual a 7, maximo de caracteres para um hex de cor
            else if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.Text.Length <= 7)
            {
                string cor = textBox1.Text.ToString();
                User.senha = cor; // Atualiza a senha da classe User
                usas.Senha = $"{cor}"; // defini a senha do usuario cadastrada no banco como o conteudo da text box em string (cor)

                // Confirma as alteracoes
                var pergunta = $"{usas.Nome} quer mesmo salvar essa cor?".Conf();
                if (pergunta == DialogResult.Yes)
                {
                    ctx.SaveChanges(); // salva no banco
                    Close(); // fecha o form;
                    return;
                }

                return;
            }

            // se algo der errado:
            else
            {
                "nao foi possivel salvar a cor".Alert();
                return;
            }
        }
    }
}