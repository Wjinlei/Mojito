namespace Mojito.SimpleLogging.Loggers;

public class ConsoleLogger : Logger
{
    private static string GetMessage(string level, string message, string pattern)
    {
        return pattern.Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", level)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);
    }

    public override void Debug(string message, string pattern)
    {
        Console.WriteLine(GetMessage("Debug", message, pattern));
    }

    public override void Info(string message, string pattern)
    {
        Console.WriteLine(GetMessage("Info", message, pattern));
    }

    public override void Warn(string message, string pattern)
    {
        Console.WriteLine(GetMessage("Warn", message, pattern));
    }

    public override void Error(string message, string pattern)
    {
        Console.WriteLine(GetMessage("Error", message, pattern));
    }

    public override void Fatal(string message, string pattern)
    {
        Console.WriteLine(GetMessage("Fatal", message, pattern));
    }
}
