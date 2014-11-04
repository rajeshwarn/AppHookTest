using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Hooker;

namespace ApplicationHookConsole {
    class Program {

        private static IntPtr hhook = IntPtr.Zero;
        private static NativeMethods.HookProc hhookProc;

        static void Main(string[] args) {
            Process process = Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe");
           // Process process = Process.Start(@"D:\VisualStudioGit\RandomSoftware\ApplicationHook\Dummy\bin\Debug\Dummy.exe");

            try {
                hhookProc += Hook;
                //hhook = NativeMethods.SetWindowsHookEx(HookType.WH_MOUSE, hhookProc, IntPtr.Zero, 0);
                //hhook = process.Handle;
                //Console.WriteLine(hhook);
                //hhook = NativeMethods.SetWindowsHookEx(HookType.WH_MOUSE, hhookProc, process.Handle, 0);
                Console.WriteLine(NativeMethods.SetWindowsHookEx(HookType.WH_MOUSE, hhookProc, process.Handle, 0));
                //hhook = NativeMethods.SetWindowsHookEx(HookType.WH_CBT, hhookProc, process.Handle, 0);


                Console.WriteLine("hhook valid? {0}", hhook != IntPtr.Zero);
                Console.WriteLine("process valid? {0}", process.Handle != IntPtr.Zero);

                while (!process.HasExited)
                    process.WaitForExit(500);

            } finally {
                if (hhook != IntPtr.Zero)
                    NativeMethods.UnhookWindowsHookEx(hhook);
            }
        }

        static int Hook(int nCode, IntPtr wParam, IntPtr lParam) {
            Console.WriteLine("Hook()");
            return NativeMethods.CallNextHookEx(hhook, nCode, wParam, lParam);
        }
    }
}
