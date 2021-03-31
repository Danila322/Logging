using Logging.LogDeleting;
using Logging.LogReading;
using System.Collections.Generic;

namespace Logging.Decorators
{
    public class DeletingLogReader : LogReaderDecorator
    {
        private ILogDeleter logDeleter;

        public DeletingLogReader(ILogReader logReader, ILogDeleter logDeleter) : base(logReader)
        {
            this.logDeleter = logDeleter;
        }


        public async override IAsyncEnumerable<LogEntry> ReadLogs()
        {
            await foreach(var log in logReader.ReadLogs())
            {
                yield return log;
            }

            await logDeleter.DeleteLogs();
        }
    }
}
