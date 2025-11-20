using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taskool_final
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
            Application.Run(new FormAutentica());
        }
    }
    public static class me
    {
        public static DialogResult Alert(this string message)
        {
            return MessageBox.Show(message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Conf(this string message)
        {
            return MessageBox.Show(message, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Info(this string message)
        {
            return MessageBox.Show(message, "informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
