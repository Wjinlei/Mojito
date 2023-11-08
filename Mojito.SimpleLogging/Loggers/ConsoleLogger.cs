namespace Mojito.SimpleLogging.Loggers;

public class ConsoleLogger : Logger
{
    public override void Log(string message, LogLevel level)
    {
        if (Writeable(level))
            Console.WriteLine(message);
    }
}
