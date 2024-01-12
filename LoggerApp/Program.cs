using LoggerLibrary;

class Program
{
    static void Main()
    {
        // Referenced the compiled LoggerLibrary.dll in this project

        // Configure logger
        var loggerConfig = new LoggerConfiguration();
        loggerConfig.AddConsoleSink();
        loggerConfig.AddFileSink("log.txt");

        // Create logger
        var logger = new Logger(loggerConfig.Sinks);

        // Log messages
        logger.LogMessage("This is an error message", LogLevel.ERROR, "Namespace1");
        logger.LogMessage("This is an info message", LogLevel.INFO, "Namespace2");
        logger.LogMessage("This is a debug message", LogLevel.DEBUG, "Namespace3");

        Console.WriteLine("Logging complete. Check the log.txt file for file logs.");
        Console.ReadLine(); // To keep the console window open for demonstration

    }
}
