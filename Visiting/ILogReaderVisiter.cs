using Logging.LogDeleting;
using Logging.LogReading;

namespace Logging.Visiting
{
    public interface ILogReaderVisiter
    {
        ILogDeleter Visit(FileLogReader reader);
    }
}
