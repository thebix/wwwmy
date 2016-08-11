using NLog.Extensions.Logging;
using System;

namespace wwwmy.Core
{
    public class NLogger : ILogger
    {
        public NLogger (/*IHostingEnvironment env, ILoggerFactory loggerFactory*/)
        {
            //add NLog to ASP.NET Core
            // loggerFactory.AddNLog();
            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root
            // env.ConfigureNLog("nlog.config");
        }

        public void LogError(Exception ex)
        {

        }

        public void LogInfo(string message)
        {

        }
    }
}