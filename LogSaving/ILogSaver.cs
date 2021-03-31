using System.Threading.Tasks;

namespace Logging.LogSaving
{
    public interface ILogSaver
    {
        Task SaveLogEntry(LogEntry logEntry);
    }
}
