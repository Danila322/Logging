using System;

namespace Logging.LogParsing
{
    public class LogParser : ILogParser
    {
        private char close = ']';
        private char colon = ':';

        public LogEntry ParseLog(string log)
        {
            int index = 1;
            int step = 2;

            int length = log.IndexOf(close, index) - index;
            string dateTime = log.Substring(index, length);

            index += length + step;
            length = log.IndexOf(colon, index) - index;
            string logType = log.Substring(index, length);

            index += length + step;
            string message = log.Substring(index);

            return new LogEntry(DateTime.Parse(dateTime), 
                                (LogType)Enum.Parse(typeof(LogType), logType), 
                                message);
        }
    }
}
