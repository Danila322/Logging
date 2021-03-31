namespace Logging.LogParsing
{
    public interface ILogParser
    {
        LogEntry ParseLog(string log);
    }
}
