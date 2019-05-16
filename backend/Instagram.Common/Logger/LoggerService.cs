using Instagram.Common.Logger.Interfaces;
using NLog;

namespace Instagram.Common.Logger
{
    /// <summary>
    /// Logger service class using NLog extension
    /// </summary>
    public class LoggerService : ILoggerService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log info messages
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// Log warning messages
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }

        /// <summary>
        /// Log debug messages
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }
        
        /// <summary>
        /// Log error messages
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            Logger.Error(message);
        }
    }
}
