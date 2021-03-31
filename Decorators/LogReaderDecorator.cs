using Logging.LogReading;
using System.Collections.Generic;

namespace Logging.Decorators
{
  public abstract class LogReaderDecorator : ILogReader
  {
    protected ILogReader logReader;

        protected LogReaderDecorator(ILogReader logReader)
        {
            this.logReader = logReader;
        }

        public abstract IAsyncEnumerable<LogEntry> ReadLogs();
  }
}
