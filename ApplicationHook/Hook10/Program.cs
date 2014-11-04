using System;
using System.Diagnostics;
using System.Threading;
using MouseKeyboardActivityMonitor.WinApi;

namespace Hook10 {
    class Program {
        static void Main(string[] args) {

            Hooker hooker = new AppHooker();
            //SpecificAppHooker  specificAppHooker = new 
            while (true) {
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }


    }
}
