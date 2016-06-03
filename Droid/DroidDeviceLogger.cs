using System;
using Android.Util;

namespace CorporateBsGenerator.Droid
{
    public class DroidDeviceLogger : IDeviceLogger
    {
        private readonly string appName;

        public DroidDeviceLogger(string appName)
        {
            this.appName = appName;
        }

        public void LogInfo(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Info($"{this.appName}.{tag}", message);
#endif
        }

        public void LogWarn(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Warn($"{this.appName}.{tag}", message);
#endif
        }

        public void LogError(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Error($"{this.appName}.{tag}", message);
#endif
        }

        public void LogError(string tag, string message, Exception ex)
        {
#if (APPSTORE)
#else
            Log.Error($"{this.appName}.{tag}", $"{message}\n Exception: {ex}");
#endif
        }
    }
}