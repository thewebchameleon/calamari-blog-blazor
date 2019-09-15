using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalamariBlog.Infrastructure.Logging
{
    public class LoggerService : ILoggerService
    {
        private ILogger _logger;

        public LoggerService()
        {
            _logger = Log.Logger;
        }
        /// <summary>
        /// Log debug information
        /// </summary>
        /// <param name="debug"></param>
        /// <param name="objects">objects to format into debug message</param>
        public void LogDebug(string debug, params object[] objects)
        {
            var message = FormatMessage(debug, objects);
            var args = GetLogArguments();

            _logger.Debug(message, args);
        }

        /// <summary>
        /// Log general information
        /// </summary>
        /// <param name="info"></param>
        /// <param name="objects">objects to format into info message</param>
        public void LogInformation(string info, params object[] objects)
        {
            var message = FormatMessage(info, objects);
            var args = GetLogArguments();

            _logger.Information(message, args);
        }

        /// <summary>
	    /// Log warning information
	    /// </summary>
	    /// <param name="info"></param>
        /// <param name="objects">objects to format into info message</param>
        public void LogWarning(string warn, params object[] objects)
        {
            var message = FormatMessage(warn, objects);
            var args = GetLogArguments();

            _logger.Warning(message, args);
        }

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="error"></param>
        /// <param name="objects">objects to format into error message</param>
        public void LogError(Exception ex, string error, params object[] objects)
        {
            var message = FormatMessage(error, objects);
            var args = GetLogArguments();

            _logger.Error(ex, message, args);
        }

        /// <summary>
        /// Get all the arguments that we want to send to our log provider
        /// </summary>
        /// <returns></returns>
        private object[] GetLogArguments()
        {
            var resultList = new List<object>();

            // todo: add extra fields

            return resultList.ToArray();
        }

        /// <summary>
        /// Formats the `message` with extra objects supplied
        /// </summary>
        /// <param name="message">Format of the message</param>
        /// <param name="objects">Actual values for formatting</param>
        /// <returns></returns>
        private string FormatMessage(string message, params object[] objects)
        {
            if (objects != null && objects.Length > 0)
            {
                var jsonObjects = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();
                message = string.Format(message + "{0}", jsonObjects).Replace("{", "{{").Replace("}", "}}");
            }
            return message;
        }
    }

}
