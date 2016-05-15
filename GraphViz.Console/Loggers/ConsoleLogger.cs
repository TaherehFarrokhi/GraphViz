using System;
using GraphViz.Core.Loggers;

namespace GraphViz.Console.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            System.Console.WriteLine($"{DateTime.Now} - {logLevel} - {message}");
        }
    }
}