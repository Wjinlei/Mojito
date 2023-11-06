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
        var newMessage = GetMessage("Debug", message, pattern);
        Console.WriteLine(newMessage);
    }

    public override void Info(string message, string pattern)
    {
        var newMessage = GetMessage("Info", message, pattern);
        Console.WriteLine(newMessage);
    }

    public override void Warn(string message, string pattern)
    {
        var newMessage = GetMessage("Warn", message, pattern);
        Console.WriteLine(newMessage);
    }

    public override void Error(string message, string pattern)
    {
        var newMessage = GetMessage("Error", message, pattern);
        Console.WriteLine(newMessage);
    }

    public override void Fatal(string message, string pattern)
    {
        var newMessage = GetMessage("Fatal", message, pattern);
        Console.WriteLine(newMessage);
    }
}
