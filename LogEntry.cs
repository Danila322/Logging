using System;

namespace Logging
{
    public sealed class LogEntry
    {
        private readonly DateTime dateTime;
        private readonly LogType logType;
        private readonly string message;

        public DateTime DateTime => dateTime;
        public LogType LogType => logType;
        public string Message => message;

        public LogEntry(LogType logType, string message)
        {
            this.dateTime = DateTime.Now;
            this.logType = logType;
            this.message = message;
        }

        public LogEntry(DateTime dateTime, LogType logType, string message)
        {
            this.dateTime = dateTime;
            this.logType = logType;
            this.message = message;
        }

        public override string ToString() => $"[{DateTime}] {LogType}: {Message}";
    }
}
