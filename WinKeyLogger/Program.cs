using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Options;

namespace WinKeyLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool autostart = false;
            string logdir = null;

            var o = new OptionSet() {
                { "l|logdir=", "Logging Directory", v => logdir = v},
                { "a|autostart", "Autostart Logging", v => autostart = v != null},
            };

            o.Parse(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Control(logdir, autostart));
        }
    }
}
