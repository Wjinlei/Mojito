namespace Mojito.SimpleLogging.Loggers;

public abstract class Logger
{
    public abstract void Debug(string message, string pattern);
    public abstract void Info(string message, string pattern);
    public abstract void Warn(string message, string pattern);
    public abstract void Error(string message, string pattern);
    public abstract void Fatal(string message, string pattern);
}