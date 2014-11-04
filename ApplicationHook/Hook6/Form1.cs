using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hook6 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            WinEventDelegate dele = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle() {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return null;
        }

        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime) {
            Log.Text += GetActiveWindowTitle() + "\r\n";
            Process p = Process.GetProcessById(GetProcessId(GetForegroundWindow()));
            Log.Text += GetForegroundWindow() + " - " + GetProcessId(GetForegroundWindow()) + "\r\n";

            //Process myProcess = Process.GetProcesses().Single(ppp => ppp.Id != 0 && ppp.MainWindowHandle == GetForegroundWindow());
            //Debug.WriteLine("MYPROCESS: " + myProcess.ProcessName);
            uint processId;
            GetWindowThreadProcessId(GetForegroundWindow(), out processId);
            Log.Text += "ProcessId: " + processId + "\r\n";

            Process pp = Process.GetProcesses().SingleOrDefault(q => q.Id == processId);
            //if (pp != null) {
            //    Debug.WriteLine(pp.ProcessName + " - " + pp.MainWindowTitle);
            //} else {
            //    Debug.WriteLine("Failed to find Process");
            //}
            int i = 1;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    }
}
