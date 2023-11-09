namespace Mojito.SimpleLogging.Loggers;

public class ConsoleLogger : Logger
{
    public override void Log(string message, LogLevel level)
    {
        if (IsWriteable(level))
            Console.WriteLine(message);
    }
}
