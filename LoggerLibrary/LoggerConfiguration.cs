using System.Collections.Generic;

namespace LoggerLibrary
{
    public class LoggerConfiguration
    {
        public List<ISink> Sinks { get; } = new List<ISink>();

        public void AddConsoleSink()
        {
            Sinks.Add(new ConsoleSink());
        }

        public void AddFileSink(string filePath)
        {
            Sinks.Add(new FileSink(filePath));
        }
    }
}
