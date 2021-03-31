using System.Collections.Generic;

namespace Logging.LogReading
{
    public interface ILogReader
    {
        IAsyncEnumerable<LogEntry> ReadLogs();
    }
}
