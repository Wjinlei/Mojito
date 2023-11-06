namespace Mojito.SimpleLogging.Loggers;

public class FileLogger : Logger
{
    private readonly string logPath;

    public FileLogger(string path)
    {
        logPath = path;
    }

    public override void Debug(string message)
    {
        File.AppendAllText(logPath, message + Environment.NewLine);
    }

    public override void Info(string message)
    {
        File.AppendAllText(logPath, message + Environment.NewLine);
    }

    public override void Warn(string message)
    {
        File.AppendAllText(logPath, message + Environment.NewLine);
    }

    public override void Error(string message)
    {
        File.AppendAllText(logPath, message + Environment.NewLine);
    }

    public override void Fatal(string message)
    {
        File.AppendAllText(logPath, message + Environment.NewLine);
    }
}
