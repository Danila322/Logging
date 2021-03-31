using System.IO;

namespace Logging.Factories
{
    public static class LogFileStreamFactrory
    {
        private static int bufferSize = 4096;

        public static FileStream GetReadStream(string filepath)
        {
            return new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Write, LogFileStreamFactrory.bufferSize, FileOptions.Asynchronous);
        } 

        public static FileStream GetWriteStream(string filepath)
        {
            return new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.Read, LogFileStreamFactrory.bufferSize, FileOptions.Asynchronous);
        }
    }
}
