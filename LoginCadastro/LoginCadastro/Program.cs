using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCadastro
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class Me
    {
        public static DialogResult Alert(this string text)
        {
            return MessageBox.Show(text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Conf(this string text)
        {
            return MessageBox.Show(text, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Info(this string text)
        {
            return MessageBox.Show(text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
