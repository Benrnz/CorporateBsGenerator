using System;

namespace CorporateBsGenerator.iOS
{
    public class IosDeviceLogger : IDeviceLogger
    {
        private readonly string appName;

        public IosDeviceLogger(string appName)
        {
            this.appName = appName;
        }

        public void LogInfo(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"INFO {DateTime.UtcNow}, {this.appName}.{tag}, {message}");
#endif
        }

        public void LogWarn(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"WARN {DateTime.UtcNow}, {this.appName}.{tag}, {message}");
#endif
        }

        public void LogError(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"ERROR {DateTime.UtcNow}, {this.appName}.{tag}, {message}");
#endif
        }

        public void LogError(string tag, string message, Exception ex)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"ERROR {DateTime.UtcNow}, {this.appName}.{tag}, {message}, {ex}");
#endif
        }
    }
}