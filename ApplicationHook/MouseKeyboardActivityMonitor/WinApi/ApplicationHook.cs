using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MouseKeyboardActivityMonitor.Exceptions;

namespace MouseKeyboardActivityMonitor.WinApi {
    class ApplicationHook : Hooker {

        IntPtr hMod;
        int dwThreadId;

        public ApplicationHook(IntPtr hMod, int dwThreadId) {
            this.hMod = hMod;
            this.dwThreadId = dwThreadId;
        }
        /// <summary>
        /// Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure. 
        /// </summary>
        internal const int WH_MOUSE = 7;

        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure. 
        /// </summary>
        internal const int WH_KEYBOARD = 2;

        internal override int Subscribe(int hookId, HookCallback hookCallback) {
            if (hMod == IntPtr.Zero || dwThreadId == 0) {
                throw new HookException(String.Format("Missing Values hMod: {0} or dwThreadId: {1}", hMod, dwThreadId));
            }
            int hookHandle = SetWindowsHookEx(
                hookId,
                hookCallback,
                hMod,
                dwThreadId);

            if (hookHandle == 0) {
                ThrowLastUnmanagedErrorAsException();
            }

            return hookHandle;
        }

        internal override bool IsGlobal {
            get { return false; }
        }

        /// <summary>
        /// Retrieves the unmanaged thread identifier of the calling thread.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetCurrentThreadId();

    }
}
