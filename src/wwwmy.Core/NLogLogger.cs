using System;
using System.IO;
using wwwmy.Core.Interfaces;
using NLog;
using NLog.Config;

namespace wwwmy.Core
{
    public class NLogLogger : ICustomLogger
    {
        private LogFactory _factory;
        private Lazy<NLog.Logger> _logger;
        protected NLog.Logger CurrentLogger
        {
            get
            {
                try
                {
                    return _logger.Value;
                }
                catch
                {
                    return null;
                }
            }
        }

        #region Конструкторы
        public NLogLogger (/*IHostingEnvironment env, ILoggerFactory loggerFactory*/)
        {
        }

        public NLogLogger (string config)
        {
            var path1 = Path.Combine(Directory.GetCurrentDirectory(), config);

            if (!File.Exists(path1))
            {
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "bin", config);

                if (!File.Exists(path2))
                {
                    return;
                }
                path1 = path2;
            }

            try
            {
                _factory = new LogFactory(new XmlLoggingConfiguration(path1));
            }
            catch
            {
                _factory = new LogFactory();
            }

            _logger = new Lazy<NLog.Logger>(() => _factory.GetCurrentClassLogger(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        
        #endregion

        #region Методы логгирования
        public void LogInfo(string message, params object[] args)
        {
            Log(LogLevel.Info, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            Log(LogLevel.Debug, message, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log(LogLevel.Error, message, args);
        }

        public void LogException(Exception ex)
        {
            Log(LogLevel.Fatal, ex.ToString());
        }

        public void LogException(Exception ex, string message, params object[] args)
        {
            Log(LogLevel.Fatal, message, args);
            LogException(ex);
        }
        #endregion

        #region Вспомогательные методы
        private void Log(LogLevel level, string message, params object[] args)
        {
            if(CurrentLogger == null || level == null || !CurrentLogger.IsEnabled(level))
                return;
            
            if(args == null || args.Length == 0)
                CurrentLogger.Log(level, message);
            else 
            {
                try 
                {
                    CurrentLogger.Log(level, string.Format(message, args));
                } 
                catch (Exception ex)
                {
                    CurrentLogger.Error(string.Format("Ошибка при логгировании, ex=", ex.InnerException));
                }
            } 
        } 
        #endregion
    }
}