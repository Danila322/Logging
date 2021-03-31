using System.Threading.Tasks;

namespace Logging.LogImporting
{
    public interface ILogImporter
    {
        Task ImportLogs();
    }
}
