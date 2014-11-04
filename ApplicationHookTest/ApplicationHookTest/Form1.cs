using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.CustomExceptions;
using MouseKeyboardActivityMonitor.WinApi;

namespace ApplicationHookTest {
    public partial class Form1 : Form {

        private readonly KeyboardHookListener m_KeyboardHookManager;
        private readonly MouseHookListener m_MouseHookManager;

        public Form1() {
            InitializeComponent();
            //Process.GetCurrentProcess().MainModule.BaseAddress
            Process process = Process.Start("notepad");
            Thread.Sleep(500);
            if (process == null)
                throw new HookException("Program not started");

            foreach (ProcessThread thread in process.Threads) {
                Log(thread.BasePriority.ToString());
            }
            //process.MainModule.BaseAddress - Det angivne modul blev ikke fundet
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.MainModule.BaseAddress, 0);
            //process.MainModule.EntryPointAddress - Det angivne modul blev ikke fundet
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.MainModule.EntryPointAddress, 0);
            //process.Handle - Det angivne modul blev ikke fundet
            ApplicationHooker applicationHooker = new ApplicationHooker(process.Handle, 0);
            //process.MainWindowHandle - Der kan ikke indstilles en ikke-lokal hook uden en modul-handle
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.MainWindowHandle, 0);
            //process.MaxWorkingSet - Det angivne modul blev ikke fundet
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.MaxWorkingSet, 0);
            //process.MinWorkingSet - Det angivne modul blev ikke fundet
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.MinWorkingSet, 0);
            //process.ProcessorAffinity - Det angivne modul blev ikke fundet
            //ApplicationHooker applicationHooker = new ApplicationHooker(process.ProcessorAffinity, 0);
            Log(process.MainModule.BaseAddress.ToString());
            m_KeyboardHookManager = new KeyboardHookListener(applicationHooker);
            m_KeyboardHookManager.Enabled = true;

            //m_MouseHookManager = new MouseHookListener(applicationHooker);
            //m_MouseHookManager.Enabled = true;

            //m_MouseHookManager.MouseMove += HookManager_MouseMove;
            //m_MouseHookManager.MouseClickExt += HookManager_MouseClick;
            //m_MouseHookManager.MouseUp += HookManager_MouseUp;
            //m_MouseHookManager.MouseDown += HookManager_MouseDown;
            //m_MouseHookManager.MouseDoubleClick += HookManager_MouseDoubleClick;
            //m_MouseHookManager.MouseWheel += HookManager_MouseWheel;
            //m_KeyboardHookManager.KeyDown += HookManager_KeyDown;
            //m_KeyboardHookManager.KeyUp += HookManager_KeyUp;
            //m_KeyboardHookManager.KeyPress += HookManager_KeyPress;
            
        }

        #region Event handlers of particular events. They will be activated when an appropriate check box is checked.
        private void HookManager_KeyDown(object sender, KeyEventArgs e) {
            Log(string.Format("KeyDown \t\t {0}\n", e.KeyCode));
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e) {
            Log(string.Format("KeyUp  \t\t {0}\n", e.KeyCode));
        }


        private void HookManager_KeyPress(object sender, KeyPressEventArgs e) {
            Log(string.Format("KeyPress \t\t {0}\n", e.KeyChar));
        }


        private void HookManager_MouseMove(object sender, MouseEventArgs e) {
            Log(string.Format("x={0:0000}; y={1:0000}", e.X, e.Y));
        }

        private void HookManager_MouseClick(object sender, MouseEventArgs e) {
            Log(string.Format("MouseClick \t\t {0}\n", e.Button));
        }

        private void HookManager_MouseUp(object sender, MouseEventArgs e) {
            Log(string.Format("MouseUp \t\t {0}\n", e.Button));
        }


        private void HookManager_MouseDown(object sender, MouseEventArgs e) {
            Log(string.Format("MouseDown \t\t {0}\n", e.Button));
        }


        private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e) {
            Log(string.Format("MouseDoubleClick \t\t {0}\n", e.Button));
        }


        private void HookManager_MouseWheel(object sender, MouseEventArgs e) {
            Log(string.Format("Wheel={0:000}", e.Delta));
        }

        private void Log(string text) {
            tBoxLog.AppendText(text);
            tBoxLog.ScrollToCaret();
        }
        #endregion
    

    }
}
