using System;

namespace wwwmy.Core.Interfaces
{
    public interface ICustomLogger
    {
        void LogInfo(string message, params object[] args);
        void LogDebug(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogException(Exception ex);
        void LogException(Exception ex, string message, params object[] args);
    }
}
