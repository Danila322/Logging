using Logging.LogImporting;

namespace Logging.Factories
{
    public interface ILogImporterFactory
    {
        ILogImporter ToFileLogImporter(string filepath);
    }
}
