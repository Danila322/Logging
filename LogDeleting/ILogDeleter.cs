using System.Threading.Tasks;

namespace Logging.LogDeleting
{
    public interface ILogDeleter
    {
        Task DeleteLogs();
    }
}
