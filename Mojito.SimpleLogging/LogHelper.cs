using Microsoft.Extensions.Configuration;
using Mojito.SimpleLogging.Loggers;

namespace Mojito.SimpleLogging;

public static class LogHelper
{
    private static readonly IConfigurationRoot configuration;

    private static readonly ConsoleLogger consoleLogger;

    static LogHelper()
    {
        consoleLogger = new ConsoleLogger();

        configuration = new ConfigurationBuilder()
            .AddXmlFile("App.config", optional: true, reloadOnChange: true)
            .Build();
    }

    /// <summary>
    /// 获得日志记录器
    /// </summary>
    /// <param name="currentLevel">当前的日志记录级别，用来判断是否应该返回给你日志器</param>
    /// <returns></returns>
    private static Logger? GetLogger(LogLevel currentLevel)
    {
        var target = configuration["logging:target:value"] ??= "File";
        var file = configuration["logging:target:file"] ??= "Mojito.log";
        var maxFile = configuration["logging:target:max"] ??= "";
        var rollSizeInKb = configuration["logging:target:rollSizeInKb"] ??= "";
        var rollTimeInMinutes = configuration["logging:target:rollTimeInMinutes"] ??= "";
        var level = configuration["logging:level:value"] ??= "Info";

        Logger logger = target.ToLower() switch
        {
            "console" => consoleLogger,
            "file" => new FileLogger(file, maxFile, rollSizeInKb, rollTimeInMinutes),
            _ => consoleLogger,
        };

        // 根据当前的日志记录级别，判断是否应该返回给你日志器
        return level.ToLower() switch
        {
            "debug" => logger,
            "info" => currentLevel > LogLevel.Debug ? logger : null,
            "warn" => currentLevel > LogLevel.Info ? logger : null,
            "error" => currentLevel > LogLevel.Warn ? logger : null,
            "fatal" => currentLevel > LogLevel.Error ? logger : null,
            _ => logger,
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
        var pattern = configuration["logging:pattern:value"] ??= "%date %level %message%newline";
        return pattern.Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", level)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);
    }

    public static void Debug(string message)
    {
        var newMessage = GetMessage("Debug", message);
        GetLogger(LogLevel.Debug)?.WriteLog(newMessage);
    }

    public static void Info(string message)
    {
        var newMessage = GetMessage("Info", message);
        GetLogger(LogLevel.Info)?.WriteLog(newMessage);
    }

    public static void Warn(string message)
    {
        var newMessage = GetMessage("Warn", message);
        GetLogger(LogLevel.Warn)?.WriteLog(newMessage);
    }

    public static void Error(string message)
    {
        var newMessage = GetMessage("Error", message);
        GetLogger(LogLevel.Error)?.WriteLog(newMessage);
    }

    public static void Fatal(string message)
    {
        var newMessage = GetMessage("Fatal", message);
        GetLogger(LogLevel.Fatal)?.WriteLog(newMessage);
    }
}
