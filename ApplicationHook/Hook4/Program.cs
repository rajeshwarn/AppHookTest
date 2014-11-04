using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Hook4 {
    class Program {
        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT tme);
        public const uint TME_CANCEL = 0x80000000;
        public const int TME_HOVER = 0x00000001;
        public const int TME_LEAVE = 0x2;
        public const int TME_NONCLIENT = 0x10;
        public const int TME_QUERY = 0x40000000;

        static void Main(string[] args) {
            Process process = Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe");
            IntPtr handle = GetForegroundWindow();
            Console.WriteLine(GetActiveWindowTitle());
            Thread t = new Thread(() => GetMouseWindow(handle));
            t.Start();
            Console.ReadLine();
        }

        public static void GetMouseWindow(IntPtr handle) {
            TRACKMOUSEEVENT msevnt = new TRACKMOUSEEVENT();
            msevnt.cbSize = (uint)Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
            msevnt.dwFlags = TME_HOVER; //0x1
            msevnt.hwndTrack = handle;
            msevnt.dwHoverTime = 0;
            while (true) {
                bool called = TrackMouseEvent(ref msevnt);  
                Console.WriteLine(msevnt.hwndTrack);
                Console.WriteLine(called);
                Thread.Sleep(2000);    
            }     
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle() {
            const int nChars=256;
            StringBuilder Buff=new StringBuilder(nChars);
            IntPtr handle=GetForegroundWindow();

            if(GetWindowText(handle, Buff, nChars)>0) {
                return Buff.ToString();
            }
            return null;
        }
    

        [StructLayout(LayoutKind.Sequential)]
        public struct TRACKMOUSEEVENT {
            public UInt32 cbSize;
            public UInt32 dwFlags;
            public IntPtr hwndTrack;
            public UInt32 dwHoverTime;
        }

    }
}
