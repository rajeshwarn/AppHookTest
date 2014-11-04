using System;

namespace MouseKeyboardActivityMonitor.Exceptions {
    public class HookException: Exception {
        public HookException() { }
        public HookException(string message): base(message) { }
        public HookException(string message, Exception innerException) : base(message, innerException) { }
    }
}
