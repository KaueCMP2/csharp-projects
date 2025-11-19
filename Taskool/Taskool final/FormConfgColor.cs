using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taskool_final
{
    public partial class FormConfgColor : Parent
    {
        public FormConfgColor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Color corSelecionada = dlg.Color;

                    int red = corSelecionada.R;
                    int green = corSelecionada.G;
                    int blue = corSelecionada.B;

                    Color c = Color.FromArgb(red, green, blue);

                    textBox1.Text = ColorTranslator.ToHtml(c);
                    this.BackColor = c;
                    return;
                }
            }
        }
    }
}