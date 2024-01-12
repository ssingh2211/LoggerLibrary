using System.IO;

namespace LoggerLibrary
{
    public interface IFileSink : ISink
    {
        string FilePath { get; }
    }

    public class FileSink : IFileSink
    {
        public List<LogLevel> SupportedLevels { get; } = new List<LogLevel> { LogLevel.FATAL, LogLevel.ERROR };

        public string FilePath { get; }

        public FileSink(string filePath)
        {
            FilePath = filePath;
        }

        public void LogMessage(LogMessage message)
        {
            // Logic to write to the file
            File.AppendAllText(FilePath, $"[{message.Level}] [{message.Namespace}] - {message.Content}\n");
        }
    }
}
