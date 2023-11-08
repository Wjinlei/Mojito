using Mojito.SimpleLogging.Loggers;

namespace Mojito.SimpleLogging;

public static class LogHelper
{
    private static readonly LoggerDecorator consoleLogger;
    private static readonly LoggerDecorator fileLogger;

    static LogHelper()
    {
        consoleLogger = new LoggerDecorator(new ConsoleLogger());
        fileLogger = new LoggerDecorator(new FileLogger());
    }

    /// <summary>
    /// 获得日志记录器
    /// </summary>
    private static Logger GetLogger()
    {
        return LogConfigHelper.GetLogTarget() switch
        {
            "console" => consoleLogger,
            "file" => fileLogger,
            _ => consoleLogger,
        };
    }

    public static void Debug(string message)
    {
        GetLogger().Log(message, LogLevel.Debug);
    }

    public static void Info(string message)
    {
        GetLogger().Log(message, LogLevel.Info);
    }

    public static void Warn(string message)
    {
        GetLogger().Log(message, LogLevel.Warn);
    }

    public static void Error(string message)
    {
        GetLogger().Log(message, LogLevel.Error);
    }

    public static void Fatal(string message)
    {
        GetLogger().Log(message, LogLevel.Fatal);
    }
}
