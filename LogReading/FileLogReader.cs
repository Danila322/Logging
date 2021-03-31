using Logging.Factories;
using Logging.LogDeleting;
using Logging.LogParsing;
using Logging.Visiting;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Logging.LogReading
{
    public class FileLogReader : ILogReader, ILogReaderAccessor
    {
        private string filepath;
        private StringBuilder logBuilder;
        private char firstLogSymbol = '[';
        private readonly ILogParser logParser;

        public string Filepath => filepath;

        public FileLogReader(string filepath, ILogParser logParser)
        {
            this.filepath = filepath;
            this.logBuilder = new StringBuilder();
            this.logParser = logParser;
        }

        public async IAsyncEnumerable<LogEntry> ReadLogs()
        {
            using(StreamReader reader = new StreamReader(LogFileStreamFactrory.GetReadStream(filepath)))
            {
                while (!reader.EndOfStream)
                {
                    yield return await ReadLog(reader);
                }
            }
        }

        private async Task<LogEntry> ReadLog(StreamReader reader)
        {
            logBuilder.Clear();
            string line = await reader.ReadLineAsync();

            while (reader.Peek() != firstLogSymbol && !reader.EndOfStream)
            {
                logBuilder.AppendLine(line);
                line = await reader.ReadLineAsync();
            }

            logBuilder.Append(line);
            return logParser.ParseLog(logBuilder.ToString());
        }

        ILogDeleter ILogReaderAccessor.Access(ILogReaderVisiter visiter) => visiter.Visit(this);
    }
}
