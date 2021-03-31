using System;
using System.Threading.Tasks;

namespace Logging.Extensions
{
    public static class LoggerExtensions
    {
        public static async Task Log(this ILogger logger, Exception exception)
        {
            await logger.Log(LogType.Error, exception.GetType().Name + ": " + exception.Message);
        }

        public static async Task Log(this ILogger logger, string message)
        {
            await logger.Log(LogType.Debug, message);
        }
    }
}
