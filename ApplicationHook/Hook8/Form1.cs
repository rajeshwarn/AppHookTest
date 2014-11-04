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

namespace Hook8 {
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

        
        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime) {
            try {
                Log.Text += GetActiveWindowTitle() + "\r\n";
            }catch (Exception) {
                Log.Text += "ERROR!";
            }
            //Process process = FindProcess(GetForegroundWindow());
            //Log.Text += processId + "\r\n";
            //Process process = Process.GetProcessById(processId);
            //Log.Text += process.ProcessName + " - " + process.Id + "\r\n" + "\r\n";
            //Process myProcess = Process.GetProcesses().Single(ppp => ppp.Id != 0 && ppp.MainWindowHandle == GetForegroundWindow());
            //Process.GetProcesses();
            //Process.GetProcesses();
        }

        public Process FindProcess(IntPtr handle) {
            ProcessLog.Text = "";
            foreach (Process process in Process.GetProcesses()) {
                ProcessLog.Text += process.ProcessName + " - " + process.Id + "\r\n";
                if (process.MainWindowHandle == handle) {
                    return process;
                }
            } 
            return null;
        }
    }
}
