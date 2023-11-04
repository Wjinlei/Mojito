namespace Mojito.Logging;

public enum LogTarget
{
    Console,
    File
}

public enum LogLevel
{
    Debug,
    Info,
    Warn,
    Error,
    Fatal
}

public abstract class Logger
{
    public abstract void Debug(string message);
    public abstract void Info(string message);
    public abstract void Warn(string message);
    public abstract void Error(string message);
    public abstract void Fatal(string message);
}