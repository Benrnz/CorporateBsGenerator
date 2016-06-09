using System;
using System.Diagnostics;

namespace CorporateBsGenerator.Uwp
{
    public class UwpDeviceLogger : IDeviceLogger
    {
        private readonly string appName;

        public UwpDeviceLogger(string appName)
        {
            this.appName = appName;
        }

        public void LogInfo(string tag, string message)
        {
            Debug.WriteLine("INFO {0}, {1}.{2}, {3}", DateTime.UtcNow, this.appName, tag, message);
        }

        public void LogWarn(string tag, string message)
        {
            Debug.WriteLine("WARN {0}, {1}.{2}, {3}", DateTime.UtcNow, this.appName, tag, message);
        }

        public void LogError(string tag, string message)
        {
            Debug.WriteLine("ERROR {0}, {1}.{2}, {3}", DateTime.UtcNow, this.appName, tag, message);
        }

        public void LogError(string tag, string message, Exception ex)
        {
            Debug.WriteLine("ERROR {0}, {1}.{2}, {3}", DateTime.UtcNow, this.appName, tag, message);
            Debug.WriteLine(ex);
        }
    }
}
