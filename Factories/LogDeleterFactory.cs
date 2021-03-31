using Logging.LogDeleting;
using Logging.LogReading;
using Logging.Visiting;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.Factories
{
    public class LogDeleterFactory : ILogReaderVisiter
    {
        private static LogDeleterFactory instance;
        private static object lockObject = new object();

        private LogDeleterFactory() { }

        public static LogDeleterFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            Volatile.Write<LogDeleterFactory>(ref instance, new LogDeleterFactory());
                        }
                    }
                }
                return instance;
            }
        }

        public ILogDeleter GetLogDeleter(ILogReader reader)
        {
            if (reader is ILogReaderAccessor)
            {
                return (reader as ILogReaderAccessor).Access(this);
            }

            return new NullLogDeleter();
        }

        ILogDeleter ILogReaderVisiter.Visit(FileLogReader reader)
        {
            return new FileLogDeleter(reader.Filepath);
        }

        private class NullLogDeleter : ILogDeleter
        {
            public Task DeleteLogs() => Task.CompletedTask;
        }
    }
}
