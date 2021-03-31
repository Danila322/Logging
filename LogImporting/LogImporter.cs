using Logging.LogReading;
using Logging.LogSaving;
using System.Threading.Tasks;

namespace Logging.LogImporting
{
    public class LogImporter : ILogImporter
    {
        private readonly ILogReader logReader;
        private readonly ILogSaver logSaver;

        public LogImporter(ILogReader logReader, ILogSaver logSaver)
        {
            this.logReader = logReader;
            this.logSaver = logSaver;
        }

        private Task ImportLog(LogEntry logEntry) => logSaver.SaveLogEntry(logEntry);

        public async Task ImportLogs()
        {
            await foreach (var log in logReader.ReadLogs())
            {
                await ImportLog(log);
            }
        }
    }
}
