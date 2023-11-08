namespace Mojito.SimpleLogging.Loggers;

public class ConsoleLogger : Logger
{
    public override void WriteLog(string message)
    {
        Console.WriteLine(message);
    }
}
