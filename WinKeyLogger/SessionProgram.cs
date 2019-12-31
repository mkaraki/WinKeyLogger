using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinKeyLogger
{
    internal class SessionProgram
    {
        public IntPtr hWnd { get; set; }

        public string WindowName { get; set; }

        public int ProcessId { get; set; }

        public string ProcessName { get; set; }

        public bool Equals(SessionProgram obj)
        {
            return (hWnd == obj.hWnd && WindowName == obj.WindowName && ProcessId == obj.ProcessId && ProcessName == obj.ProcessName);
        }

        public SessionProgram Clone()
        {
            return new SessionProgram { 
                hWnd = hWnd,
                WindowName = WindowName,
                ProcessId = ProcessId,
                ProcessName = ProcessName
            };
        }
    }
}
