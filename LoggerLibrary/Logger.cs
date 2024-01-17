using System;
using System.Collections.Generic;

namespace LoggerLibrary
{
    public interface ILogger
    {
        void LogMessage(string content, LogLevel level, string namespaceValue);
    }

    public interface ISink
    {
        List<LogLevel> SupportedLevels { get; }
        void LogMessage(LogMessage message);
    }

    public class Logger : ILogger
    {
        private readonly List<ISink> sinks;
        private readonly object lockObject = new object();

        public Logger(List<ISink> sinks)
        {
            this.sinks = sinks;
        }

        public void LogMessage(string content, LogLevel level, string namespaceValue)
        {
            var message = new LogMessage
            {
                Content = content,
                Level = level,
                Namespace = namespaceValue
            };

            // Asynchronously log messages to all sinks
            foreach (var sink in sinks)
            {
                Task.Run(() => LogToSink(sink, message));
            }
        }

        private void LogToSink(ISink sink, LogMessage message)
        {
            try
            {
                lock (lockObject)
                {
                    if (sink.SupportedLevels.Contains(message.Level))
                    {
                        sink.LogMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions during logging (e.g., log to another sink)
                Console.WriteLine($"Error logging to {sink.GetType().Name}: {ex.Message}");
            }
        }
    }

    public class LogMessage
    {
        public string? Content { get; set; }
        public LogLevel Level { get; set; }
        public string? Namespace { get; set; }
    }

    public enum LogLevel
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}
