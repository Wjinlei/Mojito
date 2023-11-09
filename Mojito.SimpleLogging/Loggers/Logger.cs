namespace Mojito.SimpleLogging.Loggers;

public abstract class Logger
{
    public abstract void Log(string message, LogLevel level);

    public virtual bool IsWriteable(LogLevel level)
    {
        return LogConfigHelper.GetLogLevel() switch
        {
            "debug" => true,
            "info" => level >= LogLevel.Info,
            "warn" => level >= LogLevel.Warn,
            "error" => level >= LogLevel.Error,
            "fatal" => level >= LogLevel.Fatal,
            _ => true,
        };
    }
}