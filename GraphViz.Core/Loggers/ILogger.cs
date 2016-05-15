namespace GraphViz.Core.Loggers
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel = LogLevel.Info);
    }
}