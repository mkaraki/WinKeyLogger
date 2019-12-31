using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibKeyHook
{
    public class KeyHook
    {
        private IntPtr hookID = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private LowLevelKeyboardProc Callback;

        public KeyHook()
        {
            Callback = HookCallback;
        }

        public IntPtr Start()
        {
            using (var currentProc = Process.GetCurrentProcess())
            using (var currentModule = currentProc.MainModule)
                return hookID = SetWindowsHookEx(13 /* WH_KEYBOARD_LL */, Callback, GetModuleHandle(currentModule.ModuleName), 0);
        }

        public bool Stop()
        {
            return UnhookWindowsHookEx(hookID);
        }

        public bool Stop(IntPtr hookid)
        {
            return UnhookWindowsHookEx(hookid);
        }

        #region Events

        // KeyDown Event
        public delegate void KeyDownEventHandler(object sender, KeyDownEventArgs e);

        public event KeyDownEventHandler KeyDown;

        // KeyUp Event
        public delegate void KeyUpEventHandler(object sender, KeyUpEventArgs e);

        public event KeyUpEventHandler KeyUp;

        #endregion Events

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (wParam == (IntPtr)0x0100/*WM_KEYDOWN*/)
                    KeyDown(this, new KeyDownEventArgs { Key = (Keys)vkCode });
                else if (wParam == (IntPtr)0x0101/*WM_KEYUP*/)
                    KeyUp(this, new KeyUpEventArgs { Key = (Keys)vkCode });
            }

            // Pass through
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
}
