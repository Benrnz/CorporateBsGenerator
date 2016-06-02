using System;

namespace CorporateBsGenerator
{
    /// <summary>
    /// An interface to enable logging to device log files on a specific platform.
    /// Must be implemented by all UI platforms.
    /// </summary>
    public interface IDeviceLogger
    {
        void LogInfo(string tag, string message);

        void LogWarn(string tag, string message);

        void LogError(string tag, string message);

        void LogError(string tag, string message, Exception ex);
    }
}
