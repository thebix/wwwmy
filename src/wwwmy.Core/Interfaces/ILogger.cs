using System;

namespace wwwmy.Core
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void LogInfo(string message);
    }
}
