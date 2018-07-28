using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MemoryGameForm MemoryGameForm = new MemoryGameForm();
        }
    }
}
