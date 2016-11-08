using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Solitare
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string s;
            if (args.Length == 0)
                s = "";
            else
                s = args[0];
            Application.Run(new Form1(s));
        }
    }
}
