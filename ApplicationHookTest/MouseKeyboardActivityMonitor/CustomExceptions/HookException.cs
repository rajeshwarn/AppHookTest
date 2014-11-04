using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseKeyboardActivityMonitor.CustomExceptions {
    public class HookException : Exception {
        public HookException() { }
        public HookException(string message) : base(message) { }
        public HookException(string message, Exception innerException) : base(message, innerException) { }
    }
}
