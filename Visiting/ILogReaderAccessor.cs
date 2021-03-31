using Logging.LogDeleting;

namespace Logging.Visiting
{
    public interface ILogReaderAccessor
    {
        ILogDeleter Access(ILogReaderVisiter visiter);
    }
}
