namespace Mojito.SimpleLogging.Loggers;

public class ConsoleLogger : Logger
{
    public override void Log(string message, LogLevel level)
    {
        Console.ForegroundColor = level switch
        {
            LogLevel.Debug => ConsoleColor.DarkGreen,
            LogLevel.Info => ConsoleColor.Gray,
            LogLevel.Warn => ConsoleColor.DarkYellow,
            LogLevel.Error => ConsoleColor.DarkRed,
            LogLevel.Fatal => ConsoleColor.Magenta,
            _ => ConsoleColor.White
        };

        if (IsWriteable(level))
            Console.WriteLine(message);

        Console.ResetColor(); // finally reset
    }
}
