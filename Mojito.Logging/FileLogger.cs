namespace Mojito.Logging;

public class FileLogger : Logger
{
    private readonly string filePath = @"log.txt";

    public override void Debug(string message)
    {
        File.WriteAllText(filePath, message + Environment.NewLine);
    }

    public override void Info(string message)
    {
        File.WriteAllText(filePath, message + Environment.NewLine);
    }

    public override void Warn(string message)
    {
        File.WriteAllText(filePath, message + Environment.NewLine);
    }

    public override void Error(string message)
    {
        File.WriteAllText(filePath, message + Environment.NewLine);
    }

    public override void Fatal(string message)
    {
        File.WriteAllText(filePath, message + Environment.NewLine);
    }
}
