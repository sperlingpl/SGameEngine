using System;
using System.Text;

namespace SGameEngine.Log
{
    /// <summary>
    ///     Static logger class for logging.
    /// </summary>
    public static class Logger
    {
        private static ILogger instance;

        private static ILogger Instance
        {
            get
            {
                // If no class logger set then use default DebugLogger.
                if (instance == null)
                {
                    instance = new DebugLogger();
                }

                return instance;
            }
        }

        /// <summary>
        ///     Sets logger class.
        /// </summary>
        /// <param name="loggerType">Logger class.</param>
        public static void SetLogger(Type loggerType)
        {
            if (loggerType == null) throw new ArgumentNullException(nameof(loggerType));

            instance = (ILogger) Activator.CreateInstance(loggerType);
        }

        private static string GetLogType(LogType logType)
        {
            var logTypeString = string.Empty;

            switch (logType)
            {
                case LogType.Info:
                    logTypeString = "INFO";
                    break;
                case LogType.Error:
                    logTypeString = "ERROR";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }

            return logTypeString;
        }

        /// <summary>
        ///     Write log text.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="text">Formatted text to write.</param>
        /// <param name="args">Formatted text arguments.</param>
        public static void Write(LogType logType, string text, params object[] args)
        {
            var outputStringBuilder = new StringBuilder();
            outputStringBuilder.AppendFormat("{0} {1}: ", DateTime.Now, GetLogType(logType));
            outputStringBuilder.Append(text);

            Instance.Write(logType, outputStringBuilder.ToString(), args);
        }

        /// <summary>
        ///     Write log exception.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="exception">Exception to write.</param>
        public static void Write(LogType logType, Exception exception)
        {
            var outputStringBuilder = new StringBuilder();
            outputStringBuilder.AppendFormat("{0} {1}: ", DateTime.Now, GetLogType(logType));
            outputStringBuilder.Append(exception);

            Instance.Write(logType, outputStringBuilder.ToString());
        }
    }
}