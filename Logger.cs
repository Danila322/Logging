using Logging.LogSaving;
using System;
using System.Threading.Tasks;

namespace Logging
{
    internal class Logger : ILogger
    {
        private readonly ILogSaver logSaver;

        public Logger(ILogSaver logSaver)
        {
            this.logSaver = logSaver;
        }

        public async Task Log(LogType logType, string message)
        {
            LogEntry logEntry = new LogEntry(logType, message);

            await logSaver.SaveLogEntry(logEntry);
        }
    }
}
