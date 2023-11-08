using Mojito.SimpleLogging.Loggers;

namespace Mojito.SimpleLogging;

public static class LogHelper
{
    private static readonly ConsoleLogger consoleLogger;
    private static readonly FileLogger fileLogger;

    static LogHelper()
    {
        consoleLogger = new ConsoleLogger();
        fileLogger = new FileLogger();
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

    /// <summary>
    /// 根据日志的pattern，重新生成消息
    /// </summary>
    /// <param name="level">日志级别</param>
    /// <param name="message">原始消息</param>
    /// <returns></returns>
    private static string GetMessage(string level, string message)
    {
        return LogConfigHelper.GetLogPattern().Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", level)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);
    }

    public static void Debug(string message)
    {
        var newMessage = GetMessage("Debug", message);
        GetLogger().Log(newMessage, LogLevel.Debug);
    }

    public static void Info(string message)
    {
        var newMessage = GetMessage("Info", message);
        GetLogger().Log(newMessage, LogLevel.Info);
    }

    public static void Warn(string message)
    {
        var newMessage = GetMessage("Warn", message);
        GetLogger().Log(newMessage, LogLevel.Warn);
    }

    public static void Error(string message)
    {
        var newMessage = GetMessage("Error", message);
        GetLogger().Log(newMessage, LogLevel.Error);
    }

    public static void Fatal(string message)
    {
        var newMessage = GetMessage("Fatal", message);
        GetLogger().Log(newMessage, LogLevel.Fatal);
    }
}
