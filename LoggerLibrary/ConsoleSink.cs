using System;

namespace LoggerLibrary
{
    public interface IConsoleSink : ISink { }

    public class ConsoleSink : IConsoleSink
    {
        public List<LogLevel> SupportedLevels { get; } = new List<LogLevel> { LogLevel.ERROR, LogLevel.INFO, LogLevel.DEBUG };

        public void LogMessage(LogMessage message)
        {
            Console.WriteLine($"[{message.Level}] [{message.Namespace}] - {message.Content}");
        }
    }
}
