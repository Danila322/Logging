using Logging.LogImporting;
using Logging.LogReading;
using Logging.LogSaving;

namespace Logging.Factories
{
    public class FileLogImporterFactory : ILogImporterFactory
    {
        private readonly ILogReader reader;

        public FileLogImporterFactory(ILogReader reader) => this.reader = reader;

        public ILogImporter ToFileLogImporter(string filepath) => new LogImporter(reader, new FileLogSaver(filepath));
    }
}
