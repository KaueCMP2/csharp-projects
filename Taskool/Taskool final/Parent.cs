using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Taskool_final.Model;

namespace Taskool_final
{
    public partial class Parent : Form
    {
        dbTarefasEntities ctx = new dbTarefasEntities();
        public Parent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public static class TrataImagem
        {
            public static byte[] SelecionarImagem(byte[] imagemBytes, Button button = null)
            {
                OpenFileDialog opf = new OpenFileDialog();
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    imagemBytes = File.ReadAllBytes(opf.FileName);

                    if (button != null)
                    {
                        button.BackgroundImage = Image.FromFile(opf.FileName);
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    return File.ReadAllBytes(opf.FileName);
                }

                return null;
            }

            public static Image ConverterImagem(byte[] imagemBytes)
            {
                if (imagemBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }

                return null;
            }
        }
    }
}
