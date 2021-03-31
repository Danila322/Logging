using Logging.Factories;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Logging.LogSaving
{
    internal class FileLogSaver : ILogSaver
    {
        private string filepath;

        public FileLogSaver(string filepath)
        {
            this.filepath = filepath;
        }

        public async Task SaveLogEntry(LogEntry logEntry)
        {
            using (FileStream file = LogFileStreamFactrory.GetWriteStream(filepath))
            {
                var data = SerializeLogEntry(logEntry);
                await file.WriteAsync(data);
            }
        }

        private ReadOnlyMemory<byte> SerializeLogEntry(LogEntry logEntry)
        {
            return new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(logEntry.ToString() + Environment.NewLine));
        }
    }
}
