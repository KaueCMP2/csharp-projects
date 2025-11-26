using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notificacao3
{
    public partial class FormNotificaView : Form
    {
        Form _formAnterior;
        public FormNotificaView(Form formAnterior)
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            _formAnterior = formAnterior;
        }

        private void FormNotificaView_Load(object sender, EventArgs e)
        {
            
        }

        private void FormNotificaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
