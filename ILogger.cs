using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
        Task Log(LogType logType, string message);
    }
}
