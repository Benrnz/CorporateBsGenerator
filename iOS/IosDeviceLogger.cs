using System;

namespace CorporateBsGenerator.iOS
{
    public class IosDeviceLogger : IDeviceLogger
    {
        public void LogInfo(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"INFO {DateTime.UtcNow}, {tag}, {message}");
#endif
        }

        public void LogWarn(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"WARN {DateTime.UtcNow}, {tag}, {message}");
#endif
        }

        public void LogError(string tag, string message)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"ERROR {DateTime.UtcNow}, {tag}, {message}");
#endif
        }

        public void LogError(string tag, string message, Exception ex)
        {
#if (APPSTORE)
#else
            Console.WriteLine($"ERROR {DateTime.UtcNow}, {tag}, {message}, {ex}");
#endif
        }
    }
}