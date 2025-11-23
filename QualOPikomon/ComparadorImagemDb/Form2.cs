using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparadorImagemDb
{
    public partial class Form2 : Form
    {
        CPikomon cpik = new CPikomon();
        public Form2()
        {
            InitializeComponent();

            txtNome.Text = cpik.Nome;
            txtTipo.Text = cpik.Tipo;
            txtVant.Text = cpik.Vantagem;
            txtFraq.Text = cpik.Fraqueza;
            imgPik.BackgroundImage = cpik.FotoPik;
        }

        private void btOp_Click(object sender, EventArgs e)
        {
            pnOp.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
    }
}
