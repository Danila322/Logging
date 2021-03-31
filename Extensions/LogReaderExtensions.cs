using Logging.Decorators;
using Logging.Factories;
using Logging.LogReading;

namespace Logging.Extensions
{
    public static class LogReaderExtensions
    {
        public static ILogReader WithDeleting(this ILogReader reader)
        {
            return new DeletingLogReader(reader, LogDeleterFactory.Instance.GetLogDeleter(reader));
        }
    }
}
