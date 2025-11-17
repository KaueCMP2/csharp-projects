using LoginCadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCadastro
{
    public partial class Form1 : Parent
    {
        loginCad1Entities ctx = new loginCad1Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                $"Todos os campos são obrigatorios".Alert();
                return;
            }

            else if (!ctx.User1.Any(u => u.Email == textBox1.Text.ToLower()))
            {
                "Email ou senha invalidos".Alert();
                return;
            }

            else if (ctx.User1.Any(u => u.Email == textBox1.Text))
            {
                var usas = ctx.User1.FirstOrDefault(u => u.Email == textBox1.Text.ToLower());
                if (usas.Senha != textBox2.Text)
                {
                    "Email ou senha invalidos".Alert();
                    return;
                }

                $"Seja bem vindo {usas.Apelido}".Info();
                Form3 form3 = new Form3(this, usas.Id);
                form3.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parent cad = new Cadastro(this);
            cad.Show();
            this.Hide();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!EmailValido(textBox1.Text))
            {
                "Email invalido".Alert();
                textBox1.Focus();
                return;
            }
        }

        public bool EmailValido(string mail)
        {
            if (mail == null)
                return false;

            string patter = @"^[^@\s]+@[^@\s]+\.[^@\s]^$";
            return Regex.IsMatch(mail, patter);
        }
    }


}
