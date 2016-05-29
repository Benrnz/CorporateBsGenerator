using System;
using Android.Util;

namespace CorporateBsGenerator.Droid
{
    public class DroidDeviceLogger : IDeviceLogger
    {
        public void LogInfo(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Info(tag, message);
#endif
        }

        public void LogWarn(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Warn(tag, message);
#endif
        }

        public void LogError(string tag, string message)
        {
#if (APPSTORE)
#else
            Log.Error(tag, message);
#endif
        }

        public void LogError(string tag, string message, Exception ex)
        {
#if (APPSTORE)
#else
            Log.Error(tag, $"{message}\n Exception: {ex}");
#endif
        }
    }
}